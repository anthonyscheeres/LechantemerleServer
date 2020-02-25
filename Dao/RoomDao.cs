using ChantemerleApi.Models;
using Newtonsoft.Json;
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


        internal string getAllRoomsOutOrInOrder(bool isOutOfOrder)
        {


            var sqlQueryForRegistingUser = "select * from rooms";
            //hard coded queries
            string queryExtensionToSelectOutOfOrder = " where rooms.out_of_order  = TRUE";
            string queryExtensionToSelectNotOutOfOrder = " where rooms.out_of_order  = FALSE";
            string orderBy = " order by id";

            string tooAdTooQuery = queryExtensionToSelectNotOutOfOrder;

            //you want to display in or the out of order rooms
            if (isOutOfOrder)
            {
                tooAdTooQuery = queryExtensionToSelectOutOfOrder;
            }

            //construct the sql query here
            sqlQueryForRegistingUser = sqlQueryForRegistingUser + tooAdTooQuery + orderBy;

            //use database credentials to login and start a connection
            using var connectionWithDatabase = new NpgsqlConnection(cs);

            connectionWithDatabase.Open();


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);




            command.Prepare();

            var i = command.ExecuteReader();

            string json = JsonConvert.SerializeObject(i, Formatting.Indented);

            return json;
        }

    }
}
