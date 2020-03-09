namespace ChantemerleApi.Models
{
    public class MailModel
    {
        public string username { get; set; }

        public string password { get; set; }

        public MailModel(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

    }
}
