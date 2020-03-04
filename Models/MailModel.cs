namespace ChantemerleApi.Models
{
    public class MailModel
    {
        public string username { get; }

        public string password { get; }

        public MailModel(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

    }
}
