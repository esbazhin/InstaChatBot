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
    public partial class ProjectCreator : Form
    {
        List<string> contacts;

        public static BindingSource b;
        BindingSource b1;
        public ProjectCreator()
        {

            b = new BindingSource();
            b1 = new BindingSource();

            if (!Directory.Exists("./contacts"))
                Directory.CreateDirectory("./contacts");

            if (!Directory.Exists("./projects"))
                Directory.CreateDirectory("./projects");

            InitializeComponent();

            contacts = new List<string>();

            b.DataSource = Form1.projects;

            b1.DataSource = b;
            b1.DataMember = "Persons";

            projList.DataSource = b;
            projList.DisplayMember = "name";

            if (Form1.projects.Count > 0)
                projList.SelectedIndex = 0;

            persList.DataSource = b1;
            persList.DisplayMember = "name";


            nameText.DataBindings.Add("Text", b, "name");
            clientText.DataBindings.Add("Text", b, "Client");
            selLabel.DataBindings.Add("Text", b, "Dialog");
        }

        private void projectAddB_Click(object sender, EventArgs e)
        {
            //if(!isSelected)
            //{
            //    MessageBox.Show("Не выбран диалог!");
            //    //return;
            //}

            //if(persons == null || persons.Count == 0)
            //{
            //    MessageBox.Show("Добавьте хотя бы одного персонажа!");
            //    //return;
            //}

            //if (contacts == null || contacts.Count == 0)
            //{
            //    MessageBox.Show("Добавьте хотя бы одного контактёра!");
            //    //return;
            //}

            //if(nameText.Text == "")
            //{
            //    MessageBox.Show("Добавьте название!");
            //    //return;
            //}

            //if (clientText.Text == "")
            //{
            //    MessageBox.Show("Добавьте заказчика!");
            //    //return;
            //}

            Project p1 = new Project();
            p1.name = "новый проект";
            p1.Persons = new BindingList<Person>();
            Form1.projects.Add(p1);

            string path = "./projects/" + p1.name + ".prj";
            File.WriteAllText(path, JsonConvert.SerializeObject(p1));


            projList.SelectedIndex = Form1.projects.Count - 1;
        }

        private void projectDelB_Click(object sender, EventArgs e)
        {
            int sel = projList.SelectedIndex;
            if (sel == -1)
                return;

            foreach (Person p in Form1.projects[sel].Persons)
            {
                p.proj = null;
                Form1.freePersons.Add(p);
            }


            string path = "./projects/" + Form1.projects[sel].name + ".prj";
            File.Delete(path);
            Form1.projects.RemoveAt(sel);


            if (sel > 0)
                projList.SelectedIndex = sel - 1;

            if (sel == 0 && Form1.projects.Count > 0)
                projList.SelectedIndex = 0;


        }

        private void selDialB_Click(object sender, EventArgs e)
        {
            int sel = projList.SelectedIndex;
            if (sel == -1)
                return;

            OpenFileDialog sd = new OpenFileDialog();
            sd.RestoreDirectory = true;
            sd.Filter = "Файлы диалога(*.dlg) | *.dlg";
            sd.InitialDirectory = Directory.GetCurrentDirectory() + "\\dialogs";
            sd.Title = "Открыть диалог";

            if (sd.ShowDialog() == DialogResult.Cancel)
                return;

            string path = sd.FileName;

            Dialog d = JsonConvert.DeserializeObject<Dialog>(File.ReadAllText(path));

            selLabel.Text = d.name;
            //isSelected = true;

            Form1.projects[sel].script = d;
            b.ResetCurrentItem();
        }

        private void crDialB_Click(object sender, EventArgs e)
        {
            DialogCreator form = new DialogCreator();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog sd = new OpenFileDialog();
            sd.RestoreDirectory = true;
            sd.Filter = "Текстовый файл(*.txt) | *.txt";
            sd.InitialDirectory = Directory.GetCurrentDirectory() + "\\contacts";
            sd.Title = "Открыть файл со списком контактёров";

            if (sd.ShowDialog() == DialogResult.Cancel)
                return;

            string path = sd.FileName;

            int sel = projList.SelectedIndex;
            AddContacts(sel, File.ReadAllLines(path).ToList());
            ReloadContacts(sel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Добавьте логин контактёра!");
                return;
            }

            int sel = projList.SelectedIndex;

            List<string> add = new List<string>();
            add.Add(textBox1.Text);

            AddContacts(sel, add);
            ReloadContacts(sel);

            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sel = contList.SelectedIndex;
            DeleteContact(projList.SelectedIndex, sel);
        }

        private void accDelB_Click(object sender, EventArgs e)
        {
            int sel = persList.SelectedIndex;
            if (sel == -1)
                return;

            Project p = b.Current as Project;
            if (p == null)
                return;

            p.Persons[sel].proj = null;
            Form1.freePersons.Add(p.Persons[sel]);
            p.Persons.RemoveAt(sel);

            ReloadContacts(projList.SelectedIndex);

        }

        private void accAddB_Click(object sender, EventArgs e)
        {
            PersonCreator form = new PersonCreator(true);
            form.Show();
            form.FormClosed += PersonCreator_FormClosed;
        }

        private void PersonCreator_FormClosed(object sender, FormClosedEventArgs e)
        {
            ReloadContacts(projList.SelectedIndex);
        }

        private void ProjectCreator_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Project p in Form1.projects)
                File.WriteAllText("./projects/" + p.name + ".prj", JsonConvert.SerializeObject(p, new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                }));
        }

        private void projList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sel = projList.SelectedIndex;
            ReloadContacts(sel);
        }

        public void ReloadContacts(int sel)
        {
            if (sel == -1)
                return;
            contacts = new List<string>();
            foreach (Person p in Form1.projects[sel].Persons)
            {
                contacts.Add(p.name + ":");
                contacts.AddRange(from x in p.Contacts select x.Login);
            }

            contList.DataSource = null;
            contList.DataSource = contacts;
        }

        void AddContacts(int sel, List<string> cnt)
        {
            if (sel == -1)
                return;
            Project p = Form1.projects[sel];

            int sum = 0;

            if (p.Persons == null || p.Persons.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы одного персонажа!", "Проект: " + p.name);
                return;
            }

            foreach (Person x in p.Persons)
                sum += x.Contacts.Count;
            sum += cnt.Count;

            int sr = sum / p.Persons.Count;

            foreach (Person x in p.Persons)
            {
                if (x.Contacts.Count >= sr)
                    continue;
                int ins = sr - x.Contacts.Count;
                for (int i = 0; i < ins; i++)
                    if (cnt.Count > 0)
                    {

                        x.Contacts.Add(new Contact(cnt[0]));
                        cnt.RemoveAt(0);
                    }

            }

            int j = 0;
            if (cnt.Count > 0)
                while (cnt.Count > 0)
                {
                    p.Persons[j].Contacts.Add(new Contact(cnt[0]));
                    cnt.RemoveAt(0);
                    j++;
                    if (j >= p.Persons.Count)
                        j = 0;
                }
        }

        void DeleteContact(int selP, int selC)
        {
            if (Form1.projects[selP].Persons == null || Form1.projects[selP].Persons.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы одного персонажа!", "Проект: " + Form1.projects[selP].name);
                return;
            }

            if (selP == -1)
                return;

            if (selC == -1 || selC == 0)
                return;

            BindingList<Person> list = Form1.projects[selP].Persons;

            int x = 0;
            int i = 0;

            while (x + list[i].Contacts.Count + 1 < selC)
            {
                x += list[i].Contacts.Count + 1;
                i++;
            }

            if (x + list[i].Contacts.Count + 1 == selC)
                return;

            list[i].Contacts.RemoveAt(selC - x - 1);

            ReloadContacts(selP);

            contList.SelectedIndex = selC - 1;
        }
    }
}
