namespace InstChatBot
{
    public class Contact
    {
        public string Login { get; set; }

        //main dialog
        public int LastAnswered { get; set; }
        public bool Complete { get { return LastAnswered == 7; } }
        public System.DateTime LastAnswTime { get; set; }

        public Contact(string login)
        {
            Login = login;
            LastAnswered = -1;
            LastAnswTime = System.DateTime.Now;
        }
    }
}
