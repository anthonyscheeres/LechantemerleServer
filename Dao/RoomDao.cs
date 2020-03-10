using ChantemerleApi.Models;
using ChantemerleApi.Utilities;
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

        private DatabaseUtilities databaseUtilities = new DatabaseUtilities();
        private string cs = DataModel.getConfigModel().databaseCredentials.cs;

        public RoomDao(string cs)
        {
            this.cs = cs;
        }

        public RoomDao()
        {
        }

        internal void sendQueryToDatabaseToAddBed(int amountOfBedsInTheRoom)
        {

            using var connectionWithDatabase = new NpgsqlConnection(cs);
            connectionWithDatabase.Open(); //open the connection


            const string sqlQueryForRegistingUser = "INSERT INTO rooms(amount_of_beds) VALUES(@amount_of_beds)";
            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);

            command.Parameters.AddWithValue("amount_of_beds", amountOfBedsInTheRoom);
            command.Prepare(); //Construct and optimize query

            command.ExecuteNonQuery();
            connectionWithDatabase.Close(); //close the connection to save bandwith
        }

        private string generateQueryForAllRoomsOitOrInOrder(bool isOutOfOrder)
        {

            string sqlQueryForRegistingUser = "select * from rooms";
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
            return sqlQueryForRegistingUser;

        }


        internal string getAllRoomsOutOrInOrder(bool isOutOfOrder)
        {

            //construct the sql query here
            string sqlQueryForRegistingUser = generateQueryForAllRoomsOitOrInOrder(isOutOfOrder);


            //send query to database
            string json = databaseUtilities.sendSelectQueryToDatabaseReturnJson(sqlQueryForRegistingUser);

            //send database response data back 
            return json;
        }

    }
}
