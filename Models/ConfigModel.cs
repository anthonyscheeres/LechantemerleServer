using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Models
{
    public class ConfigModel
    {
        public DatabaseModel databaseCredentials = new DatabaseModel("Host=92.65.83.65;Username=pi;Password=good passw0rd; Database=chantemerle");
        public MailModel mailCredentials = new MailModel("testlab8990@gmail.com", "6t7yuuhi");
        public RestApiModel server = new RestApiModel("localhost", 44314); //this is needed do the token system can call itself


        public ConfigModel()
        {
        }
            public ConfigModel(DatabaseModel databaseCredentials, MailModel mailCredentials, RestApiModel server)
        {
            this.databaseCredentials = databaseCredentials;
            this.mailCredentials = mailCredentials;
            this.server = server;
        }
    }
}
