namespace ChantemerleApi.Models
{
    public class MailModel
    {
        private string username { get; }

        private string password { get; }

        public MailModel(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

    }
}
