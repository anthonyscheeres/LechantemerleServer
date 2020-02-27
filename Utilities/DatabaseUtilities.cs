using ChantemerleApi.Models;
using Newtonsoft.Json;
using Npgsql;

namespace ChantemerleApi.Utilities
{
    public class DatabaseUtilities
    {

        private readonly string cs = DataModel.databaseCredentials.cs;
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
