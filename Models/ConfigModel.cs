using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Models
{
    public class ConfigModel
    {
        public DatabaseModel databaseCredentials { get; set; }
        public MailModel mailCredentials { get; set; }
        public RestApiModel server { get; set; }


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
