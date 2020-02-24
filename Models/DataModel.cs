using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Models
{
    public class DataModel
    {
       public static DatabaseModel databaseCredentials = new DatabaseModel("Host=92.65.83.65;Username=pi;Password=good passw0rd; Database=chantemerle");
        public static MailModel mailCredentials = new MailModel("testlab8990@gmail.com", "6t7yuuhi");
    }
}
