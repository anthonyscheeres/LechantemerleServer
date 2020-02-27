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
    public class ReservationDao
    {
        private readonly string cs = DataModel.databaseCredentials.cs;
        DatabaseUtilities databaseUtilities = new DatabaseUtilities();

        private string constructSqlQueryForPreparedStatmentBasedOnWheterTheResrvationIsAccepted(bool isAccepted)
        {
            var sqlQueryFroGettingReservationInformation = "select app_users.username, app_users.email, reservations.time_from, reservations.time_till, reservations.price, reservations.accepted_by_super_user,reservations.roomno, reservations.id, reservations.created_at  from reservations full join app_users on reservations.user_id = app_users.id";

            string queryExtensionToSelectAcceptedReservations = " where reservations.accepted_by_super_user = TRUE";
            string queryExtensionToSelectNonAcceptedReservations = " where reservations.accepted_by_super_user = FALSE";

            string tooAdToQuery = queryExtensionToSelectNonAcceptedReservations;


            if (isAccepted)
            {
                tooAdToQuery = queryExtensionToSelectAcceptedReservations;


            }

            sqlQueryFroGettingReservationInformation = sqlQueryFroGettingReservationInformation + tooAdToQuery;

            return sqlQueryFroGettingReservationInformation;
        }

        internal void deleteReservationByIdInDatabase(int id)
        {
            const string sqlQueryForDeletingAnreservation = "delete from reservations where id = @id";

            using var connectionWithDatabase = new NpgsqlConnection(cs);
            connectionWithDatabase.Open();


            
            using var command = new NpgsqlCommand(sqlQueryForDeletingAnreservation, connectionWithDatabase);

            command.Parameters.AddWithValue("id", id);
            command.Prepare();

            command.ExecuteNonQuery();
        }

        internal string getReservations(bool isAccepted)
        {
            string sqlQueryForRegistingUser = constructSqlQueryForPreparedStatmentBasedOnWheterTheResrvationIsAccepted(isAccepted);
            string jsonString = databaseUtilities.sendSelectQueryToDatabaseeturnJson(sqlQueryForRegistingUser);
            return jsonString;
        }
    }
}
