using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstChatBot
{
    public partial class PersonCreator : Form
    {
        BindingSource b;
        BindingSource b1;

        bool select = false;
        public PersonCreator(bool select)
        {
            InitializeComponent();
            

            b = new BindingSource();
            b1 = new BindingSource();

            b1.DataSource = Form1.freePersons;
            freeGrid.DataSource = b1;

            b.DataSource = b1;
            b.DataMember = "Contacts";
            contList.DataSource = b;
            contList.DisplayMember = "Login";

            this.select = select;
            selectB.Visible = select;
        }      

        private void button1_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            p.name = "новый персонаж";
            p.Contacts = new List<Contact>();
            Form1.freePersons.Add(p);
        }

        private void PersonCreator_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText("freePersons.prs", JsonConvert.SerializeObject(Form1.freePersons));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Добавьте логин контактёра!");
                return;
            }

            int sel = contList.SelectedIndex;

            b.Add(new Contact(textBox1.Text));

            contList.SelectedIndex = sel;
            if (sel == -1)
                contList.SelectedIndex = 0;

            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sel = contList.SelectedIndex;
            if (sel == -1)
                return;
            b.RemoveAt(sel);
          
            if (sel > 0)
                contList.SelectedIndex = sel - 1;

            if (sel == 0 && b.Count > 0)
                contList.SelectedIndex = sel;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog sd = new OpenFileDialog();
            sd.RestoreDirectory = true;
            sd.Filter = "Текстовый файл(*.txt) | *.txt";
            sd.InitialDirectory = Directory.GetCurrentDirectory() + "\\contacts";
            sd.Title = "Открыть файл со списком контактёров";

            if (sd.ShowDialog() == DialogResult.Cancel)
                return;

            string path = sd.FileName;

            List<string> cnt = File.ReadAllLines(path).ToList();

            foreach(string line in cnt)
                b.Add(new Contact(line));
            if (cnt.Count > 0)
                contList.SelectedIndex = 0;
        }

        private void selectB_Click(object sender, EventArgs e)
        {
            Project p = ProjectCreator.b.Current as Project;
            if (p == null)
                Close();
            foreach (DataGridViewRow x in freeGrid.SelectedRows)
            {
                int sel = x.Index;
                Form1.freePersons[sel].proj = p;
                p.Persons.Add(Form1.freePersons[sel]);
                Form1.freePersons.RemoveAt(sel);
            }
            b.ResetCurrentItem();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog sd = new OpenFileDialog();
            sd.RestoreDirectory = true;
            sd.Filter = "Текстовый файл(*.txt) | *.txt";
            sd.InitialDirectory = Directory.GetCurrentDirectory() + "\\contacts";
            sd.Title = "Открыть файл со списком персонажей";

            if (sd.ShowDialog() == DialogResult.Cancel)
                return;

            string path = sd.FileName;

            foreach(string line in File.ReadAllLines(path))
            {
                try
                {
                    string[] x = line.Split(':');
                    Person p = new Person();
                    p.name = x[0];
                    p.Login = x[0];
                    p.Password = x[1];
                    p.Contacts = new List<Contact>();
                    Form1.freePersons.Add(p);
                }
                catch { continue; }
            }
        }
    }
}
