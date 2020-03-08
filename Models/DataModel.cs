namespace ChantemerleApi.Models
{

    public static class DataModel
    {
        public static readonly DatabaseModel databaseCredentials = new DatabaseModel("Host=92.65.83.65;Username=pi;Password=good passw0rd; Database=chantemerle");
        public static readonly MailModel mailCredentials = new MailModel("testlab8990@gmail.com", "6t7yuuhi");
        public static readonly RestApiModel server = new RestApiModel("localhost", 44314); //this is needed do the token system can call itself
    }
}
