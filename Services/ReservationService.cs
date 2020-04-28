using anthonyscheeresApi.Providers;
using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using System;
using System.Threading;

namespace ChantemerleApi.Services
{

    /**
* @author Anthony Scheeres
*/
    public class ReservationService
    {
        TokenService tokenService = ServiceProvider.getToken();
        private readonly ReservationDao reservationDao = new ReservationDao();
        internal string validatDeleteReservationByModel(ReservationModel reservation, string token)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation)); //if model is null throw error to protect from json injection
            string failResponse = ResponseR.fail.ToString(); string response = failResponse;

            

            tokenService.getPermissionFromDatabaseByTokenIsAdmin(token);

            response = ResponseR.success.ToString();
            reservationDao.deleteReservationByIdInDatabase(reservation.id);

            return response;
        }



        internal void CheckOverlappingDatesInDatabase(ReservationModel r )
        {
            if (reservationDao.CheckOverlappingDatesInDatabase(r.time_from, r.time_till, r.id)){
                throw new Exception();
            }

        }

        /**
* @author Anthony Scheeres
*/
        internal string addPendingReservation(ReservationModel reservation, string token)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));

            // admin adds a Reservation 

            string failResponse = ResponseR.fail.ToString(); string response = failResponse;

          


            tokenService.getPermissionFromDatabaseByTokenIsAdmin(token);

            this.CheckOverlappingDatesInDatabase(reservation);



            reservationDao.addPendingResevationByModelInDatbaseSoTheCustomerCanClaimIt(reservation);
            response = ResponseR.success.ToString();


            if (reservation.everyMonth)
            {
                //do on new thread
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    addResrvationForEveryMonth(reservation); //this methode calls itself multiple times



                }).Start();

            }




            return response;
        }

        internal string getPendingDatesByIdReservation(int id)
        {
            return reservationDao.selectRoomAvailableTimesById(id);
        }

        internal void addResrvationForEveryMonth(ReservationModel reservation)
        {
            int start = 1;

            int aantalMaandenInEenJaar = 12 - start;


            //start a loop
            for (int index = start; index < aantalMaandenInEenJaar; index++)
            {
                sendAddedMonths(index, reservation);


            }
        }



        internal void sendAddedMonths(int index, ReservationModel reservation)
        {
            ReservationModel rservation = reservation;//refresh base model

            rservation.time_from = rservation.time_from.AddMonths(index);//add month from index use a for loop to send reser
            rservation.time_till = rservation.time_till.AddMonths(index);
            reservationDao.addPendingResevationByModelInDatbaseSoTheCustomerCanClaimIt(rservation);
        }


        internal string getUserResrvations(string token)
        {

            string failResponse = ResponseR.fail.ToString(); string response = failResponse; //default failed response 

            double userId = tokenService.TokenToUserId(token);
            string successResponse = ResponseR.success.ToString();

            successResponse = reservationDao.getUsersReservations();

            return successResponse;


        }



        /**
* @author Anthony Scheeres
*/
        internal string customerAcceptPendingReservationPotential(ReservationModel reservation, string token)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));


            //pass token to responsible service
            
            string failResponse = ResponseR.fail.ToString(); string response = failResponse; //default failed response 
            //check if user his email is validated
            UserDao userDao = new UserDao();
            bool isEmaillValid = userDao.isEnailValideByModel(token);

            if (isEmaillValid)
            {
                // token to user id here 
                double userId = tokenService.TokenToUserId(token);
                string successResponse = ResponseR.success.ToString();
                reservationDao.customerAcceptPendingReservationPotentialInDatabase(userId, reservation.id);


            }

            return response;
        }

        internal string validatDeleteReservationAll(string token)
        {
            //initialize default objects
            
            string failResponse = ResponseR.fail.ToString(); 
             string response = failResponse;
            string succesResponse = ResponseR.success.ToString();
            response = succesResponse;

            //throw exeption and end the code
            tokenService.getPermissionFromDatabaseByTokenIsAdmin(token);

            //change http response 
            response = succesResponse;

            //execute query
            reservationDao.deleteAll();


            return response;

        }

        internal string getReservation(string token)
        {
            

            string response = ResponseR.success.ToString();


            //check if the token is valide
            double id = tokenService.TokenToUserId(token);

            response = reservationDao.getProfileResrvationInformationFromDatabase(id);


            return response;
        }


        /**
* @author Anthony Scheeres
*/
        internal string updateAdminAcceptResevationByModel(string token, ReservationModel reservation)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));
            
            string failResponse = ResponseR.fail.ToString(); string response = failResponse;
            tokenService.getPermissionFromDatabaseByTokenIsAdmin(token);

            response = ResponseR.success.ToString();
            reservationDao.updateAcceptResevationByModelInDatbase(reservation.id);

            return response;
        }

        internal string getPendingReservation()
        {
            const bool isAccepted = false;
            return validateGetReservation(isAccepted);
        }

        internal string getPendingReservation(int id)
        {
            const bool isAccepted = false;
            return validateGetReservation(isAccepted, id);
        }

        private string validateGetReservation(bool isAccepted, int id)
        {

            string response = reservationDao.getReservations(isAccepted, id);

            return response;
        }

        internal string getAccpetedReservation(string token)
        {
            const bool isAccepted = true;

            

            string failResponse = ResponseR.fail.ToString(); string response = failResponse;
            tokenService.getPermissionFromDatabaseByTokenIsAdmin(token);


            response = validateGetReservation(isAccepted);

            return response;

        }




        private string validateGetReservation(bool isAccepted)
        {


            string response = reservationDao.getReservations(isAccepted);

            return response;

        }

    }
}
