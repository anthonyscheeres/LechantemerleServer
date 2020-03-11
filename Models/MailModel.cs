namespace ChantemerleApi.Models
{
    public class MailModel
    {
        public string username { get; set; }

        public string password { get; set; }

        public string mailService { get; set; }

        public MailModel(string username, string password, string mailService)
        {
            this.username = username;
            this.password = password;
            this.mailService = mailService;
        }
    }
}
