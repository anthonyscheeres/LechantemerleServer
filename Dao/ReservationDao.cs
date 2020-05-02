using anthonyscheeresApi.Providers;
using ChantemerleApi.Models;
using ChantemerleApi.Utilities;
using Npgsql;
using System;

namespace ChantemerleApi.Dao
{
    public class ReservationDao
    {
        private string cs = DataModel.getConfigModel().databaseCredentials.cs;
        private DatabaseUtilities databaseUtilities = new DatabaseUtilities();

        public ReservationDao(string cs)
        {
            this.cs = cs;
        }

        public ReservationDao()
        {
        }

        private string constructSqlQueryForPreparedStatmentBasedOnWheterTheResrvationIsAccepted(bool isAccepted)
        {
         
            string sqlQueryFroGettingReservationInformation = string.Format("select rooms.img, rooms.amount_of_beds, rooms.id as {0}, app_users.username, app_users.email, reservations.time_from::TIMESTAMP::DATE, reservations.time_till::TIMESTAMP::DATE, reservations.price, reservations.accepted_by_super_user,reservations.roomno, reservations.id, reservations.created_at::TIMESTAMP::DATE  from reservations left join app_users on reservations.user_id = app_users.id left join rooms on reservations.roomno = rooms.id", "name");
            Console.WriteLine(sqlQueryFroGettingReservationInformation);
            string sqlDontSelectPastResrvations = " and reservations.time_till>now()";

            const string queryExtensionToSelectAcceptedReservations = " where reservations.user_id IS NOT NULL";
            const string queryExtensionToSelectNonAcceptedReservations = " where reservations.user_id IS NULL";

            string tooAdToQuery = queryExtensionToSelectNonAcceptedReservations; 


            if (isAccepted) //if reservation is accepted bij admin display these reservations
            {
                tooAdToQuery = queryExtensionToSelectAcceptedReservations; //add to query
            }

            tooAdToQuery = tooAdToQuery + sqlDontSelectPastResrvations; //add to query to only display future reservations

            string sqlQueryFroGettingReservationInformationConstuctedBasedOnWheterIsAccpetedOrNot = sqlQueryFroGettingReservationInformation + tooAdToQuery; //construc the query and return

            return sqlQueryFroGettingReservationInformationConstuctedBasedOnWheterIsAccpetedOrNot;
        }

        internal bool CheckOverlappingDatesInDatabase(DateTime time_from, DateTime time_till, int kamerId)
        {




            const string query = "select exists (select * from reservations where roomno=@roomno and time_till::timestamp::date <= @time_till ::date and @time_from::date <= time_from::timestamp::date)";




            using var connectionWithDatabase = ConnectionProvider.getProvide();

            connectionWithDatabase.Open(); //open the connection


            using var command = new NpgsqlCommand(query, connectionWithDatabase);

            var typpe = "yyyy-MM-dd";

            command.Parameters.AddWithValue("time_till", time_till.ToString(typpe));

            command.Parameters.AddWithValue("time_from", time_from.ToString(typpe));


            command.Parameters.AddWithValue("roomno", kamerId);
          
            command.Prepare(); //Construct and optimize query

        
            var i = command.ExecuteReader();
            bool credentialsAreValid = false;

            // int index = (i.GetOrdinal("exists"));

            PsqlUtilities.GetAll(i).ForEach(r => {  if (r.GetValue(0).ToString().ToLower() == "true") credentialsAreValid = true; });

            connectionWithDatabase.Close(); //close the connection to save bandwith


            return credentialsAreValid;


        }

        internal string selectRoomAvailableTimesById(int id)
        {
            string query = "select reservations.id, time_from::timestamp::date, time_till::timestamp::date, price from reservations left join rooms on reservations.roomno = rooms.id where user_id is null and reservations.roomno=" + id;
            string jsonString = databaseUtilities.sendSelectQueryToDatabaseReturnJson(query);
            return jsonString;
        }

        internal void addPendingResevationByModelInDatbaseSoTheCustomerCanClaimIt(ReservationModel reservation) //throws exception
        {
            CheckOverlappingDatesInDatabase(reservation.time_from, reservation.time_till, reservation.roomno);


            const string sqlQueryForDeletingAnreservation = "insert into reservations(roomno, time_from, time_till, price, accepted_by_super_user) values(@roomno, @time_from, @time_till, @price, @accepted_by_super_user);";

            using var connectionWithDatabase = ConnectionProvider.getProvide();
            connectionWithDatabase.Open(); //open the connection



            using var command = new NpgsqlCommand(sqlQueryForDeletingAnreservation, connectionWithDatabase);

            command.Parameters.AddWithValue("roomno", reservation.roomno);
            command.Parameters.AddWithValue("time_from", reservation.time_from);
            command.Parameters.AddWithValue("time_till", reservation.time_till);
            command.Parameters.AddWithValue("price", reservation.price);
            command.Parameters.AddWithValue("accepted_by_super_user", false);

            command.Prepare(); //Construct and optimize query

            command.ExecuteNonQuery();
            connectionWithDatabase.Close(); //close the connection to save bandwith
        }

        internal string getProfileResrvationInformationFromDatabase(double id)
        {
            string sqlQueryFroGettingReservationInformation = string.Format("select rooms.amount_of_beds, rooms.id as {0}, app_users.username, app_users.email, app_users.id, reservations.time_from::TIMESTAMP::DATE, reservations.time_till::TIMESTAMP::DATE, reservations.price, reservations.accepted_by_super_user,reservations.roomno, reservations.id as {1}, reservations.created_at::TIMESTAMP::DATE  from reservations left join app_users on reservations.user_id = app_users.id left join rooms on reservations.roomno = rooms.id", "name", "reservationsId");
            Console.WriteLine(sqlQueryFroGettingReservationInformation);
            string query = sqlQueryFroGettingReservationInformation + " where id=" + id;
            string jsonString = databaseUtilities.sendSelectQueryToDatabaseReturnJson(query);
            return jsonString;
        }

        internal void deleteReservationByIdInDatabase(int id)
        {
            const string sqlQueryForDeletingAnreservation = "delete from reservations where id = @id";

            using var connectionWithDatabase = ConnectionProvider.getProvide();
            connectionWithDatabase.Open(); //open the connection



            using var command = new NpgsqlCommand(sqlQueryForDeletingAnreservation, connectionWithDatabase);

            command.Parameters.AddWithValue("id", id);
            command.Prepare(); //Construct and optimize query

            command.ExecuteNonQuery();
            connectionWithDatabase.Close(); //close the connection to save bandwith
        }

        internal void deleteAll()
        {
            const string sqlQueryForDeletingAllreservation = "delete from reservations;";
          
            using var connectionWithDatabase = ConnectionProvider.getProvide();
            connectionWithDatabase.Open(); //open the connection



            using var command = new NpgsqlCommand(sqlQueryForDeletingAllreservation, connectionWithDatabase);

            

            command.Prepare(); //Construct and optimize query

            command.ExecuteNonQuery();
            connectionWithDatabase.Close(); //close the connection to save bandwith
        }

        internal string getReservations(bool isAccepted, int id)
        {
            string sqlQueryForRegistingUser = constructSqlQueryForPreparedStatmentBasedOnWheterTheResrvationIsAccepted(isAccepted);
            sqlQueryForRegistingUser = sqlQueryForRegistingUser + " and where rooms=" + id;

            string jsonString = databaseUtilities.sendSelectQueryToDatabaseReturnJson(sqlQueryForRegistingUser);
            return jsonString;
        }


        internal string getUsersReservations()
        {
            const string query = "select * from reservations where user_id = @user_id and time_till >= current_timestamp;";

            string jsonString = databaseUtilities.sendSelectQueryToDatabaseReturnJson(query);
            return jsonString;
        }


        internal void customerAcceptPendingReservationPotentialInDatabase(double userId, int id)
        {
            const string sqlQueryForDeletingAnreservation = "update reservations set user_id = @user_id where id = @id and user_id is null";

            using var connectionWithDatabase = ConnectionProvider.getProvide();
            connectionWithDatabase.Open(); //open the connection



            using var command = new NpgsqlCommand(sqlQueryForDeletingAnreservation, connectionWithDatabase);

            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("user_id", userId);
   
            command.Prepare(); //Construct and optimize query

            command.ExecuteNonQuery();
            connectionWithDatabase.Close(); //close the connection to save bandwith
        }

        internal void updateAcceptResevationByModelInDatbase(int id)
        {
            const string sqlQueryForDeletingAnreservation = "update reservations set accepted_by_super_user = @accepted_by_super_user where id = @id;";
            const bool accepted_by_super_user = true;
            using var connectionWithDatabase = ConnectionProvider.getProvide();
            connectionWithDatabase.Open(); //open the connection



            using var command = new NpgsqlCommand(sqlQueryForDeletingAnreservation, connectionWithDatabase);

            command.Parameters.AddWithValue("accepted_by_super_user", accepted_by_super_user);

            command.Parameters.AddWithValue("id", id);
            command.Prepare(); //Construct and optimize query

            command.ExecuteNonQuery();
            connectionWithDatabase.Close(); //close the connection to save bandwith
        }

        internal string getReservations(bool isAccepted)
        {
            string sqlQueryForRegistingUser = constructSqlQueryForPreparedStatmentBasedOnWheterTheResrvationIsAccepted(isAccepted);
            string jsonString = databaseUtilities.sendSelectQueryToDatabaseReturnJson(sqlQueryForRegistingUser);
            return jsonString;
        }
    }
}
