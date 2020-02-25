using ChantemerleApi.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Dao
{
    public class RoomDao
    {
        /**
* @author Anthony Scheeres
*/
        private string cs = DataModel.databaseCredentials.cs;
        internal void sendQueryToDatabaseToAddBed(int amountOfBedsInTheRoom)
        {

            using var connectionWithDatabase = new NpgsqlConnection(cs);
            connectionWithDatabase.Open();


            var sqlQueryForRegistingUser = "INSERT INTO rooms(amount_of_beds) VALUES(@amount_of_beds)";
            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);

            command.Parameters.AddWithValue("amount_of_beds", amountOfBedsInTheRoom);
            command.Prepare();

            command.ExecuteNonQuery();

        }



    }
}
