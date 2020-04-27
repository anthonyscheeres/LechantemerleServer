using anthonyscheeresApi.Providers;
using ChantemerleApi.Models;
using Newtonsoft.Json;
using Npgsql;
using System.Data;

namespace ChantemerleApi.Utilities
{
    public class DatabaseUtilities
    {


        public DatabaseUtilities()
        {

        }

        public string sendSelectQueryToDatabaseReturnJson(string sqlQuery)
        {
            return sendSelectQueryToDatabaseReturnJsonPrivate(sqlQuery);
        }

  

        private string sendSelectQueryToDatabaseReturnJsonPrivate(string sqlQuery)
        {
            using var connectionWithDatabase = ConnectionProvider.getProvide();

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
