﻿using anthonyscheeresApi.Providers;
using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using System;
using System.Threading;

namespace ChantemerleApi.Services
{

    /**
* @author Anthony Scheeres
*/
    public class ReservationService : TokenService
    {
        
        private readonly ReservationDao reservationDao = DaoProvider.getResrvation();
        internal string validatDeleteReservationByModel(ReservationModel reservation, string token)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation)); //if model is null throw error to protect from json injection

          //initialize default objects

            string successResponse, failResponse, response;

            successResponse = ResponseR.success.ToString();
            failResponse = ResponseR.fail.ToString();
            response = failResponse; //default failed response 





            getPermissionFromDatabaseByTokenIsAdmin(token);

            response = ResponseR.success.ToString();
            reservationDao.deleteReservationByIdInDatabase(reservation.id);

            return response;
        }



        internal void CheckOverlappingDatesInDatabase(ReservationModel r )
        {
            if (reservationDao.CheckOverlappingDatesInDatabase(r.time_from, r.time_till, r.roomno)){
                throw new Exception();
            }

        }

        /**
* @author Anthony Scheeres
*/
        internal string ValidateAddPendingReservation(ReservationModel reservation, string token)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));

            // admin adds a Reservation 

            //initialize default objects

            string successResponse, failResponse, response;

            successResponse = ResponseR.success.ToString();
            failResponse = ResponseR.fail.ToString();
            response = failResponse; //default failed response 




            getPermissionFromDatabaseByTokenIsAdmin(token);

   



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

            int aantalWeken = 12 - start;


            //start a loop
            for (int index = start; index < aantalWeken; index++)
            {

                sendAddedMonths(index, reservation);


            }
        }



        internal void sendAddedMonths(int index, ReservationModel reservation)
        {
            ReservationModel rservation = reservation;//refresh base model
            int daysOfTheWeek = 7;
            int days = index * daysOfTheWeek;

            rservation.time_from = rservation.time_from.AddDays(days);//add month from index use a for loop to send reser
            rservation.time_till = rservation.time_till.AddDays(days);

            try
            {

                reservationDao.addPendingResevationByModelInDatbaseSoTheCustomerCanClaimIt(rservation);
            }
            catch (Exception)
            {

            }


        }


        internal string getUserResrvations(string token)
        {
            //initialize default objects

            string successResponse, failResponse, response;

            successResponse = ResponseR.success.ToString();
            failResponse = ResponseR.fail.ToString();
            response = failResponse; //default failed response 



            double userId = TokenToUserId(token);
            response = successResponse;

            response = reservationDao.getUsersReservations();

            return successResponse;


        }



        /**
* @author Anthony Scheeres
*/
        internal string customerAcceptPendingReservationPotential(ReservationModel reservation, string token)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));


            string successResponse, failResponse, response;

            successResponse = ResponseR.success.ToString();
            failResponse = ResponseR.fail.ToString();
            response = failResponse; //default failed response 



            //check if user his email is validated
            UserDao userDao = DaoProvider.getUser();
            bool isEmaillValid = userDao.isEnailValideByModel(token);


            if (isEmaillValid)
            {
                // token to user id here 
                double userId = TokenToUserId(token);
              
                reservationDao.customerAcceptPendingReservationPotentialInDatabase(userId, reservation.id);


                response = successResponse;
            }




            return response;
        }

        internal string validatDeleteReservationAll(string token)
        {
            //initialize default objects

            string successResponse, failResponse, response;

            successResponse = ResponseR.success.ToString();
            failResponse = ResponseR.fail.ToString();
            response = failResponse; //default failed response 


            //throw exeption and end the code
            getPermissionFromDatabaseByTokenIsAdmin(token);

            //change http response 
            response = successResponse;

            //execute query
            reservationDao.deleteAll();


            return response;

        }

        internal string getReservation(string token)
        {

            string successResponse, failResponse, response;

            successResponse = ResponseR.success.ToString();
            failResponse = ResponseR.fail.ToString();
            response = failResponse; //default failed response 




            //check if the token is valide
            double id = TokenToUserId(token);

            response = reservationDao.getProfileResrvationInformationFromDatabase(id);


            return response;
        }


        /**
* @author Anthony Scheeres
*/
        internal string updateAdminAcceptResevationByModel(string token, ReservationModel reservation)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));

            //initialize default objects

            string successResponse, failResponse, response;

            successResponse = ResponseR.success.ToString();
            failResponse = ResponseR.fail.ToString();
            response = failResponse; //default failed response 




            getPermissionFromDatabaseByTokenIsAdmin(token);

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


            //initialize default objects

            string successResponse, failResponse, response;

            successResponse = ResponseR.success.ToString();
            failResponse = ResponseR.fail.ToString();
            response = failResponse; //default failed response 


            getPermissionFromDatabaseByTokenIsAdmin(token);


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
