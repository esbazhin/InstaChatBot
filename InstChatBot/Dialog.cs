using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstChatBot
{
    public class Dialog
    {
        public string name { get; }

        //main dialog       
        public string[] persMsgs { get; }
        public List<string>[] contRefuses { get; }
        public TimeSpan[] delays { get; }
        public string refuseAnswer { get; }

        ////refuse
        //public List<string> typRefuses = new List<string>();
        //public string refuseAnsw;

        //questions
        public string[] questions { get; }
        public string[] answersToQuestions { get; }

        public Dialog(string[] persMsgs, List<string>[] contRefuses, TimeSpan[] delays, string[] questions, string[] answersToQuestions, string refuseAnswer, string name)
        {
            this.persMsgs = persMsgs;
            this.contRefuses = contRefuses;
            this.delays = delays;
            //this.typRefuses = typRefuses;
            //this.refuseAnsw = refuseAnsw;
            this.questions = questions;
            this.answersToQuestions = answersToQuestions;
            this.refuseAnswer = refuseAnswer;
            this.name = name;
        }
    }
}
