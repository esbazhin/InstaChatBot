using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace InstChatBot
{
    public partial class DialogCreator : Form
    {
        public DialogCreator()
        {
            if (!Directory.Exists("./dialogs"))
                Directory.CreateDirectory("./dialogs");

            InitializeComponent();
            //label19.Text = "Подсказка: ответы и вопросы контактёров могут быть различными. Чтобы задать несколько вариантов ответа, разделите их символом \"; \". \nНапример: \"ответ 1; ответ 2; ответ 3\".";

            string[] delayOptions = {"сразу же", "10 секунд", "20 секунд", "40 секунд", "5 минут", "1 час", "1 день", "1 неделю" };
            comboBox1.DataSource=  delayOptions.Clone();
            comboBox2.DataSource = delayOptions.Clone();
            comboBox3.DataSource = delayOptions.Clone();
            comboBox4.DataSource = delayOptions.Clone();
            comboBox5.DataSource = delayOptions.Clone();
            comboBox6.DataSource = delayOptions;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveDialButton_Click(object sender, EventArgs e)
        {
            string[] persMsg = new string[7];
            persMsg[0] = dialText1.Text; persMsg[1] = dialText2.Text; persMsg[2] = dialText3.Text; persMsg[3] = dialText4.Text; persMsg[4] = dialText5.Text;
            persMsg[5] = dialText6.Text; persMsg[6] = dialText7.Text;

            List<string>[] contAnsws = new List<string>[7];
            contAnsws[0] = Convert(answText1.Text); contAnsws[1] = Convert(answText2.Text); contAnsws[2] = Convert(answText3.Text); contAnsws[3] = Convert(answText4.Text);
            contAnsws[4] = Convert(answText5.Text); contAnsws[5] = Convert(answText6.Text); contAnsws[6] = Convert(answText7.Text);

            TimeSpan[] delays = new TimeSpan[6];
            delays[0] = ConvertDT(comboBox1.SelectedIndex); delays[1] = ConvertDT(comboBox2.SelectedIndex); delays[2] = ConvertDT(comboBox3.SelectedIndex);
            delays[3] = ConvertDT(comboBox4.SelectedIndex); delays[4] = ConvertDT(comboBox5.SelectedIndex); delays[5] = ConvertDT(comboBox6.SelectedIndex);

            string[] questions = new string[3];
            questions[0] = questionText1.Text; questions[1] = questionText2.Text; questions[2] = questionText3.Text;

            string[] answers = new string[3];
            answers[0] = answerText1.Text; answers[1] = answerText2.Text; answers[2] = answerText3.Text;

            Dialog d = new Dialog(persMsg, contAnsws, delays, questions, answers, refText.Text, nameText.Text);

            string path = "./dialogs/" + d.name + ".dlg";

            File.WriteAllText(path, JsonConvert.SerializeObject(d));
        }

        List<string> Convert(string text)
        {
            List<string> answ = text.Split('~').ToList();
            if (answ[answ.Count - 1] == "" || answ[answ.Count - 1] == " ")
                answ.RemoveAt(answ.Count - 1);
            return answ;
        }

        TimeSpan ConvertDT(int sel)
        {
            switch(sel)
            {
                case 0:
                    return new TimeSpan(0, 0, 0, 0);
                case 1:
                    return new TimeSpan(0, 0, 0, 10);
                case 2:
                    return new TimeSpan(0, 0, 0, 20);
                case 3:
                    return new TimeSpan(0, 0, 0, 40);
                case 4:
                    return new TimeSpan(0, 0, 5, 0);
                case 5:
                    return new TimeSpan(0, 1, 0, 0);
                case 6:
                    return new TimeSpan(1, 0, 0, 0);
                case 7:
                    return new TimeSpan(7, 0, 0, 0);
                default:
                    return new TimeSpan(0, 0, 0, 0);
            }
        }

        int DeConvertDT(TimeSpan delay)
        {
            
            switch (delay.TotalSeconds)
            {
                case 0:
                    return 0;
                case 10:
                    return 1;
                case 20:
                    return 2;
                case 40:
                    return 3;
                case 5 * 60:
                    return 4;
                case 1 * 60 * 60:
                    return 5;
                case 24 * 60 * 60:
                    return 6;
                case 7 * 24 * 60 * 60:
                    return 7;
                default:
                    return 0;
            }
        }

        private void changeDialButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog sd = new OpenFileDialog();
            sd.RestoreDirectory = true;
            sd.Filter = "Файлы диалога(*.dlg) | *.dlg";
            sd.InitialDirectory = Directory.GetCurrentDirectory() + "\\dialogs";
            sd.Title = "Открыть диалог";

            if (sd.ShowDialog() == DialogResult.Cancel)
                return;

            string path = sd.FileName;

            Dialog d = JsonConvert.DeserializeObject<Dialog>(File.ReadAllText(path));



            dialText1.Text = d.persMsgs[0]; dialText2.Text = d.persMsgs[1]; dialText3.Text = d.persMsgs[2]; dialText4.Text = d.persMsgs[3]; dialText5.Text = d.persMsgs[4];
            dialText6.Text = d.persMsgs[5]; dialText7.Text = d.persMsgs[6];

            answText1.Text = DeConvert(d.contRefuses[0]); answText2.Text = DeConvert(d.contRefuses[1]); answText3.Text = DeConvert(d.contRefuses[2]);
            answText4.Text = DeConvert(d.contRefuses[3]); answText5.Text = DeConvert(d.contRefuses[4]); answText6.Text = DeConvert(d.contRefuses[5]);
            answText7.Text = DeConvert(d.contRefuses[6]);

            comboBox1.SelectedIndex = DeConvertDT(d.delays[0]); comboBox2.SelectedIndex = DeConvertDT(d.delays[1]); comboBox3.SelectedIndex = DeConvertDT(d.delays[2]);
            comboBox4.SelectedIndex = DeConvertDT(d.delays[3]); comboBox5.SelectedIndex = DeConvertDT(d.delays[4]); comboBox6.SelectedIndex = DeConvertDT(d.delays[5]);
            
            questionText1.Text = d.questions[0]; questionText2.Text = d.questions[1]; questionText3.Text = d.questions[2];
            
            answerText1.Text = d.answersToQuestions[0]; answerText2.Text = d.answersToQuestions[1]; answerText3.Text = d.answersToQuestions[2];


            refText.Text = d.refuseAnswer;

            nameText.Text = d.name;
        }

        string DeConvert(List<string> list)
        {
            string answ = "";
            for (int i = 0; i < list.Count - 1; i++)
                answ += list[i] + "~";
            if(list.Count > 0)
                answ += list[list.Count - 1];

            return answ;
        }
    }
}
