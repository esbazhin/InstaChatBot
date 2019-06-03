using InstaSharper.API.Builder;
using InstaSharper.Classes;
using InstaSharper.Classes.Models;
using InstaSharper.Logger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstChatBot
{
    public class Person
    {
        //ИМЯ,ID персонажа,  логин, пароль, оператор, Самоописание, проект, количество сообщений. 
        public string name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string Oper { get; set; }
        public string Project
        {
            get
            {
                if (proj == null)
                    return "свободен";
                return proj.name;
            }
        }
        public int msgCount { get; set; }

        public List<Contact> Contacts { get; set; }

        public Project proj = null;

        bool working = false;

        InstaSharper.API.IInstaApi api;

        public bool CheckOK(bool show)
        {
            if (name == null || name == "")
            {
                if (show)
                    MessageBox.Show("Добавьте имя!", "Проект: " + proj.name + " Персонаж: " + name);
                return false;
            }

            if (Login == null || Login == "")
            {
                if (show)
                    MessageBox.Show("Добавьте логин!", "Проект: " + proj.name + " Персонаж: " + name);
                return false;
            }

            if (Password == null || Password == "")
            {
                if (show)
                    MessageBox.Show("Добавьте пароль!", "Проект: " + proj.name + " Персонаж: " + name);
                return false;
            }

            if (Oper == null || Oper == "")
            {
                if (show)
                    MessageBox.Show("Добавьте оператора!", "Проект: " + proj.name + " Персонаж: " + name);
                return false;
            }

            if (Contacts == null || Contacts.Count == 0)
            {
                if (show)
                    MessageBox.Show("Добавьте хотя бы одного контактёра!", "Проект: " + proj.name + " Персонаж: " + name);
                return false;
            }

            return true;
        }

        public async Task Run()
        {
            if (!CheckOK(false))
                return;

            var user = new UserSessionData
            {
                UserName = Login,
                Password = this.Password
            };

            if (api == null)
                api = InstaApiBuilder.CreateBuilder()
                    .SetUser(user)
                    .UseLogger(new DebugLogger(LogLevel.Exceptions))
                    .SetRequestDelay(RequestDelay.FromSeconds(1, 3))
                    .Build();
            var succ = await api.LoginAsync();

            if (!succ.Succeeded)
            {
                Task.Factory.StartNew(() => MessageBox.Show("Ошибка: " + succ.Info.Message, "Персонаж: " + name));
                return;
            }

            var curUser = await api.GetCurrentUserAsync();
            if (!curUser.Succeeded)
            {
                Task.Factory.StartNew(() => MessageBox.Show("Ошибка: " + curUser.Info.Message, "Персонаж: " + name));
                return;
            }


            working = true;


            Task[] tasks = { FirstMessages(), Answer(curUser.Value) };
            await Task.WhenAll(tasks);


            //await FirstMessages();
            //await Answer(curUser.Value.Pk);
            await api.LogoutAsync();

        }


        public void Stop()
        {
            working = false;
        }


        private async Task Answer(InstaCurrentUser curUser)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();

            while (working)
            {
                if (watch.ElapsedMilliseconds >= 6 * 60 * 1000)
                {
                    Stop();
                    break;

                }

                if (Contacts.Count == 0)
                {
                    Stop();
                    break;
                }

                var result = await api.GetDirectInboxAsync();
                if (result.Succeeded && result.Value.Inbox.Threads != null && result.Value.Inbox.Threads.Count != 0)
                    foreach (var thread1 in result.Value.Inbox.Threads)
                    {
                        //если бот уже чето ответил то ждем сообщения от пользователя и смотрим другой тред
                        if (thread1.Items[0].UserId == curUser.Pk)
                            continue;

                        //загружаем весь тред
                        var q1 = await api.GetDirectInboxThreadAsync(thread1.ThreadId);

                        if (q1.Succeeded)
                        {
                            var thread = q1.Value;

                            //определяем контактёра перебирая всех юзеров в треде
                            int contInd = Contacts.FindIndex(x => x.Login == thread.Users[0].UserName);

                            //если не найден пропускаем этот тред
                            if (contInd == -1)
                                continue;

                            if (Contacts == null || Contacts.Count == 0)
                                break;
                            Contact contact = Contacts[contInd];

                            //если пользователю отправили уже все наборы сообщений
                            if (contact.Complete)
                                continue;

                            if (contact.LastAnswered < 0)
                                continue;

                            List<string> refuses = proj.script.contRefuses[contact.LastAnswered];
                            string[] questions = proj.script.questions;
                            //string answer = proj.script.persMsgs[contact.LastAnswered + 1];



                            //определяем есть ли стоп слово или вопрос
                            bool foundStop = false;
                            bool foundQuestion = false;
                            int questionInd = -1;

                            int countMsg = 0;
                            //смотрим все последние сообщения от пользователя
                            while (thread.Items[countMsg].UserId != curUser.Pk && countMsg + 1 < thread.Items.Count)
                            {

                                //ищем стоп слово
                                foreach (string word in refuses)
                                {
                                    //нашли стоп слово
                                    if (thread.Items[countMsg].Text == word)
                                    {
                                        foundStop = true;
                                        break;
                                    }
                                }

                                if (foundStop)
                                    break;


                                //ищем вопрос
                                for (int i = 0; i < questions.Length; i++)
                                {
                                    //нашли стоп слово
                                    if (thread.Items[countMsg].Text == questions[i])
                                    {
                                        foundQuestion = true;
                                        questionInd = i;
                                        break;
                                    }
                                }

                                if (foundQuestion)
                                    break;

                                countMsg++;
                            }




                            if (foundStop)
                            {
                                //принудительно завершаем
                                Contacts.RemoveAt(contInd);
                                proj.DialCount++;
                                await SendMessage(thread.Users[0].Pk.ToString(), thread.ThreadId, proj.script.refuseAnswer);
                                await SendToOper(thread.ThreadId, curUser);
                            }
                            else if (foundQuestion)
                            {
                                await SendMessage(thread.Users[0].Pk.ToString(), thread.ThreadId, proj.script.answersToQuestions[questionInd]);
                            }   //если прошло нужное время
                            else if (contact.LastAnswered > 5 || DateTime.Now >= contact.LastAnswTime.Add(proj.script.delays[contact.LastAnswered]))
                            {
                                //обновляем номер последнего отвеченного
                                contact.LastAnswered++;
                                contact.LastAnswTime = DateTime.Now;

                                //если это было последнее сообщение в диалоге то отправляем оператору и удаляем из списка
                                if (contact.Complete)
                                {
                                    Contacts.RemoveAt(contInd);
                                    proj.DialCount++;
                                    await SendToOper(thread.ThreadId, curUser);
                                    foundStop = true;
                                    break;
                                }

                                //если не последнее то пишем ответ
                                string answer = proj.script.persMsgs[contact.LastAnswered];
                                await SendMessage(thread.Users[0].Pk.ToString(), thread.ThreadId, answer);

                            }
                        }
                    }
            }
        }

        //private async Task Answer(InstaCurrentUser curUser)
        //{
        //    var x = await api.GetUserAsync("sarancha1337");
        //    for (int i = 0; i < 14; i++)
        //    {
        //        await SendMessage(x.Value.Pk.ToString(), string.Empty, i.ToString());
        //        await Task.Delay(2000);
        //    }

        //    for (int i = 14; i < 20; i++)
        //        await SendMessage(x.Value.Pk.ToString(), string.Empty, i.ToString());
        //}


        Stopwatch delay = new Stopwatch();
        async Task<bool> SendMessage(string recepient, string threadId, string text)
        {
            if (!delay.IsRunning)
                delay.Start();
            else
                while (delay.ElapsedMilliseconds < 1 * 1000)
                    Task.Delay(100).Wait();

            //var x = await api.SendDirectMessage(recepient, threadId, text);

            string url = "https://youtu.be/pBhnsFAhGx4?list=FLSsho9tQdNbmc7509kcCgcw";
            InstaMessageLink msg = new InstaMessageLink();  
            msg.Text = text + " " + url;
            msg.Url = url;
            
            var x = await api.SendLinkMessage(msg, long.Parse(recepient));
            if (x.Succeeded)
            {
                msgCount++;
                delay.Restart();
                return true;
            }
            return false;
        }

        async Task SendToOper(string threadId, InstaCurrentUser curUser)
        {
            var q1 = await api.GetDirectInboxThreadAsync(threadId);

            if (q1.Succeeded)
            {
                var thread = q1.Value;
                var q = await api.GetUserAsync(Oper);
                if (!q.Succeeded)
                {
                    Task.Factory.StartNew(() => MessageBox.Show("Ошибка в параметре \"Оператор\": " + q.Info.Message, "Персонаж: " + name));
                    return;
                }

                string msg = "";
                thread.Items.Reverse();
                foreach (var item in thread.Items)
                {
                    if (item.UserId == thread.Users[0].Pk)
                        msg += thread.Users[0].UserName + ":\n";
                    else
                        msg += curUser.UserName + ":\n";

                    msg += "\t" + item.Text + "\n";
                }

                await SendMessage(q.Value.Pk.ToString(), string.Empty, msg);
            }
        }


        async Task FirstMessages()
        {         
            for(int i = 0; i < Contacts.Count; i++)
            {
                try
                {
                    if (!working)
                        return;

                    if (Contacts[i].LastAnswered == -1)
                    {
                        var q = await api.GetUserAsync(Contacts[i].Login);
                        if (q.Succeeded)
                        {
                            string pk = q.Value.Pk.ToString();

                            bool msg = await SendMessage(pk, string.Empty, proj.script.persMsgs[0]);

                            if (msg)
                            {
                                Contacts[i].LastAnswered = 0;
                                Contacts[i].LastAnswTime = DateTime.Now;
                            }
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}

