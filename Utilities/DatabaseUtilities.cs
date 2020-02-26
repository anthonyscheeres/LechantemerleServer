using ChantemerleApi.Models;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Utilities
{
    public class DatabaseUtilities
    {

        private string cs = DataModel.databaseCredentials.cs;
        internal string sendSelectQueryToDatabaseeturnJson(string sqlQuery)
        {
            using var connectionWithDatabase = new NpgsqlConnection(cs);

            connectionWithDatabase.Open();


            using var command = new NpgsqlCommand(sqlQuery, connectionWithDatabase);




            command.Prepare();

            var readerContainingTheDataFromTheDatabase = command.ExecuteReader();

            string jsonResultFromDatabaseConvertedToJsonFormat = JsonConvert.SerializeObject(readerContainingTheDataFromTheDatabase, Formatting.Indented);

            return jsonResultFromDatabaseConvertedToJsonFormat;
        }
    }
}
