using InstaSharper.API.Builder;
using InstaSharper.Classes;
using InstaSharper.Logger;
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
    public partial class Form1 : Form
    {
        public static BindingList<Project> projects;
        public static BindingList<Person> freePersons;

        BindingSource b;
        BindingSource b1;
        BindingSource b2;

        public void AddProject(Project p)
        {
            projects.Add(p);
        }

        public Form1()
        {
            InitializeComponent();

            projects = new BindingList<Project>();
            if (!Directory.Exists("./projects"))
                Directory.CreateDirectory("./projects");


            //parse all projects
            DirectoryInfo d = new DirectoryInfo("./projects");
            FileInfo[] files = d.GetFiles("*.prj");

            foreach (FileInfo file in files)
                projects.Add(JsonConvert.DeserializeObject<Project>(File.ReadAllText(file.FullName), new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                }));

            if (File.Exists("freePersons.prs"))
                freePersons = JsonConvert.DeserializeObject<BindingList<Person>>(File.ReadAllText("freePersons.prs"));
            else
                File.Create("freePersons.prs");

            if (freePersons == null)
                freePersons = new BindingList<Person>();

            b = new BindingSource();
            b1 = new BindingSource();
            b2 = new BindingSource();

            b.DataSource = projects;

            projGrid.DataSource = b;

            b1.DataSource = b;
            b1.DataMember = "Persons";

            grid.DataSource = b1;

            b2.DataSource = b1;
            b2.DataMember = "Contacts";

            contList.DataSource = b2;
            contList.DisplayMember = "Login";

            timer1.Interval = 1000;
            timer1.Start();
        }

        private void dialogsButton_Click(object sender, EventArgs e)
        {
            DialogCreator form = new DialogCreator();
            form.Show();
        }

        private void projectsButton_Click(object sender, EventArgs e)
        {
            ProjectCreator form = new ProjectCreator();
            form.Show();
        }

        private void accsButton_Click(object sender, EventArgs e)
        {
            PersonCreator form = new PersonCreator(false);
            form.Show();
        }

        private void projGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                Project p = b.Current as Project;
                if (p.IsRunning)
                    p.Stop();
                else
                    p.Run();
                b.ResetCurrentItem();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Project p in Form1.projects)
            {
                if (p.IsRunning)
                    p.Stop();
                File.WriteAllText("./projects/" + p.name + ".prj", JsonConvert.SerializeObject(p, new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                }));
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Project p in projects)
                    if (!p.IsRunning)
                        p.Run();

                b.ResetBindings(false);
            }
            catch (Exception ex)
            {
                foreach (Project p in projects)
                    p.Stop();

                MessageBox.Show(ex.Message, ex.Source);
                Close();
            }
        }

        private async void stopButton_Click(object sender, EventArgs e)
        {
            foreach (Project p in projects)
                if (p.IsRunning)
                    p.Stop();
            b.ResetBindings(false);

            //var user = new UserSessionData
            //{
            //    UserName = "",
            //    Password = ""
            //};

            //InstaSharper.API.IInstaApi api = api = InstaApiBuilder.CreateBuilder()
            //        .SetUser(user)
            //        .UseLogger(new DebugLogger(LogLevel.Exceptions))
            //        .SetRequestDelay(RequestDelay.FromSeconds(1, 3))
            //        .Build();

            //var q = await api.CreateNewAccount("fgjyetrsfdvc", "Eswagnigga228", "fgjyetrsfdvcg@ask-mail.com", "Andrew");

            //if (q.Succeeded)
            //    MessageBox.Show(q.Value.ErrorType, q.Value.AccountCreated.ToString());
            //else
            //    MessageBox.Show(q.Info.Message);



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            b.ResetBindings(false);
            b1.ResetBindings(false);
            b2.ResetBindings(false);
        }
    }
}
