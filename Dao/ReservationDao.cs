using ChantemerleApi.Models;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Dao
{
    public class ReservationDao
    {
        private string cs = DataModel.databaseCredentials.cs;



        internal string getReservations(bool isAccepted)
        {


            var sqlQueryForRegistingUser = "select app_users.username, app_users.email, reservations.time_from, reservations.time_till, reservations.price, reservations.accepted_by_super_user,reservations.roomno, reservations.id, reservations.created_at  from reservations full join app_users on reservations.user_id = app_users.id";

           string queryExtensionToSelectAcceptedReservations =  " where reservations.accepted_by_super_user = TRUE";
            string queryExtensionToSelectNonAcceptedReservations = " where reservations.accepted_by_super_user = FALSE";

            string tooAdTooQuery = queryExtensionToSelectNonAcceptedReservations;


            if (isAccepted)
            {
                tooAdTooQuery = queryExtensionToSelectAcceptedReservations;


            }

            sqlQueryForRegistingUser = sqlQueryForRegistingUser + tooAdTooQuery;

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
