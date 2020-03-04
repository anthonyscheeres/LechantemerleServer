using ChantemerleApi.Models;
using ChantemerleApi.Utilities;
using Npgsql;

namespace ChantemerleApi.Dao
{
    public class ReservationDao
    {
        private readonly string cs = DataModel.databaseCredentials.cs;
        private DatabaseUtilities databaseUtilities = new DatabaseUtilities();

        private string constructSqlQueryForPreparedStatmentBasedOnWheterTheResrvationIsAccepted(bool isAccepted)
        {
            string sqlQueryFroGettingReservationInformation = "select app_users.username, app_users.email, reservations.time_from, reservations.time_till, reservations.id, reservations.price, reservations.accepted_by_super_user,reservations.roomno, reservations.id, reservations.created_at  from reservations full join app_users on reservations.user_id = app_users.id";

            const string queryExtensionToSelectAcceptedReservations = " where reservations.accepted_by_super_user = TRUE";
            const string queryExtensionToSelectNonAcceptedReservations = " where reservations.accepted_by_super_user = FALSE";

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

        internal void updateAcceptResevationByModelInDatbase(int id)
        {
            const string sqlQueryForDeletingAnreservation = "update reservations set accepted_by_super_user = @accepted_by_super_user where id = @id";
            const bool accepted_by_super_user = true;
            using var connectionWithDatabase = new NpgsqlConnection(cs);
            connectionWithDatabase.Open();



            using var command = new NpgsqlCommand(sqlQueryForDeletingAnreservation, connectionWithDatabase);

            command.Parameters.AddWithValue("accepted_by_super_user", accepted_by_super_user);

            command.Parameters.AddWithValue("id", id);
            command.Prepare();

            command.ExecuteNonQuery();
        }

        internal string getReservations(bool isAccepted)
        {
            string sqlQueryForRegistingUser = constructSqlQueryForPreparedStatmentBasedOnWheterTheResrvationIsAccepted(isAccepted);
            string jsonString = databaseUtilities.sendSelectQueryToDatabaseReturnJson(sqlQueryForRegistingUser);
            return jsonString;
        }
    }
}
