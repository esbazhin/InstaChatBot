using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstChatBot
{
    public class Project
    {
        //Название, заказчик, скрипт, число диалогов , прошедших всю генеральную линию диалогов.

        public string name { get; set; }
        public string Client { get; set; }
        public string Dialog
        {
            get
            {
                if (script == null)
                    return "Не выбран";
                return script.name;
            }
        }
        public Dialog script { get; set; }
        public int DialCount { get; set; }
        public BindingList<Person> Persons { get; set; }

        public bool IsRunning { get; set; }
        public bool IsStopped { get { return !IsRunning; } }
        public string IsRun
        {
            get
            {
                if (IsStopped)
                    return "Не запущен";
                else
                    return "Запущен";
            }
        }

        bool CheckOK()
        {
            if (name == null || name == "")
            {
                MessageBox.Show("Добавьте имя!", "Проект: " + name);
                return false;
            }

            if (Client == null || Client == "")
            {
                MessageBox.Show("Добавьте заказчика!", "Проект: " + name);
                return false;
            }

            if (script == null)
            {
                MessageBox.Show("Не выбран диалог!", "Проект: " + name);
                return false;
            }

            if (Persons == null || Persons.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы одного персонажа!", "Проект: " + name);
                return false;
            }

            foreach (Person p in Persons)
                if (!p.CheckOK(true))
                    return false;

            return true;
        }

        public async void Run()
        {
            if (!CheckOK())
                return;

            IsRunning = true;

            int i = 0;

            while (IsRunning)
            {
                if (Persons.Count == 0)
                {
                    IsRunning = false;
                    break;
                }

                Person p = Persons[i];

                if (!p.CheckOK(false))
                {
                    Persons.Remove(p);
                    p.proj = null;
                    Form1.freePersons.Add(p);
                    continue;
                }

                await p.Run();

                i++;
                if (i >= Persons.Count)
                    i = 0;
            }
        }

        public void Stop()
        {
            foreach (Person p in Persons)
                p.Stop();
            IsRunning = false;
        }
    }
}
