using ChantemerleApi.Models;
using Newtonsoft.Json;
using Npgsql;
using System.Data;

namespace ChantemerleApi.Utilities
{
    public class DatabaseUtilities
    {

        private readonly string cs = DataModel.get().databaseCredentials.cs;

        public DatabaseUtilities(string cs)
        {
            this.cs = cs;
        }

        public DatabaseUtilities()
        {
        }

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

            var dataTable = new DataTable();
            dataTable.Load(readerContainingTheDataFromTheDatabase);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dataTable);

            connectionWithDatabase.Close();
            return JSONString;





        }





    }
}
