using ChantemerleApi.Models;
using Newtonsoft.Json;
using Npgsql;
using System.Data;

namespace ChantemerleApi.Utilities
{
    public class DatabaseUtilities
    {

        private string cs = DataModel.getConfigModel().databaseCredentials.cs;

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

            connectionWithDatabase.Open(); //open the connection


            using (NpgsqlCommand cmd = new NpgsqlCommand(sqlQuery, connectionWithDatabase))
            using (NpgsqlDataReader readerContainingTheDataFromTheDatabase = cmd.ExecuteReader())
            {
                var dataTable = new DataTable();
                dataTable.Load(readerContainingTheDataFromTheDatabase);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(dataTable);

                connectionWithDatabase.Close(); //close the connection to save bandwith
                return JSONString;
            }





        }





    }
}
