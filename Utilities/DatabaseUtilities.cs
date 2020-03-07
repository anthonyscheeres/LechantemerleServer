using ChantemerleApi.Models;
using Newtonsoft.Json;
using Npgsql;

namespace ChantemerleApi.Utilities
{
    public class DatabaseUtilities
    {

        private readonly string cs = DataModel.databaseCredentials.cs;

        public string sendSelectQueryToDatabaseReturnJson(string sqlQuery)
        {
            return sendSelectQueryToDatabaseReturnJsonPrivate(sqlQuery, cs);
        }

        public string sendSelectQueryToDatabaseReturnJson(string sqlQuery, string cs)
        {
            return sendSelectQueryToDatabaseReturnJsonPrivate(sqlQuery, cs);
        }

        private string sendSelectQueryToDatabaseReturnJsonPrivate(string sqlQuery, string cs)
        {
            using var connectionWithDatabase = new NpgsqlConnection(cs);

            connectionWithDatabase.Open();


            using NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connectionWithDatabase);

            command.Prepare();

            var readerContainingTheDataFromTheDatabase = command.ExecuteReader();

            string jsonResultFromDatabaseConvertedToJsonFormat = JsonConvert.SerializeObject(readerContainingTheDataFromTheDatabase, Formatting.Indented);

            connectionWithDatabase.Close();

            return jsonResultFromDatabaseConvertedToJsonFormat;
        }
    }
}
