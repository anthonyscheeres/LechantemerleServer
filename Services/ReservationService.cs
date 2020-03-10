using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using System;

namespace ChantemerleApi.Services
{

    /**
* @author Anthony Scheeres
*/
    public class ReservationService
    {

        private readonly ReservationDao reservationDao = new ReservationDao();
        internal string validatDeleteReservationByModel(ReservationModel reservation, string token)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation)); //if model is null throw error to protect from json injection
            string failResponse = ResponseR.fail.ToString(); string response = failResponse;

            TokenService tokenService = new TokenService(token);

            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByTokenIsAdmin();
            if (hasAdminInDatabaseOverApi)
            {
                response = ResponseR.success.ToString();
                reservationDao.deleteReservationByIdInDatabase(reservation.id);
            }

            return response;
        }

        internal string addPendingReservation(ReservationModel reservation, string token)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));

            // admin adds a Reservation 

            string failResponse = ResponseR.fail.ToString(); string response = failResponse;

            TokenService tokenService = new TokenService(token);


            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByTokenIsAdmin();
            if (hasAdminInDatabaseOverApi)
            {
            
                reservationDao.addPendingResevationByModelInDatbaseSoTheCustomerCanClaimIt(reservation);
                response = ResponseR.success.ToString();
            }

            return response;
        }

        internal string customerAcceptPendingReservationPotential(ReservationModel reservation, string token)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));


            //pass token to responsible service
            TokenService tokenService = new TokenService(token);
            string failResponse = ResponseR.fail.ToString(); string response = failResponse; //default failed response 
            //check if user his email is validated
            UserDao userDao = new UserDao();
            bool isEmaillValid = userDao.isEnailValideByModel(token);

            if (isEmaillValid)
            {
                // token to user id here 
                double userId = tokenService.TokenToUserId();
                string successResponse = ResponseR.success.ToString();
                reservationDao.customerAcceptPendingReservationPotentialInDatabase(userId, reservation.id);


            }

            return response;
        }

        internal string updateAdminAcceptResevationByModel(string token, ReservationModel reservation)
        {
            if (reservation == null) throw new ArgumentNullException(nameof(reservation));
            TokenService tokenService = new TokenService(token);
            string failResponse = ResponseR.fail.ToString(); string response = failResponse;
            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByTokenIsAdmin();
            if (hasAdminInDatabaseOverApi)
            {
                response = ResponseR.success.ToString();
                reservationDao.updateAcceptResevationByModelInDatbase(reservation.id);
            }

            return response;
        }

        internal string getPendingReservation()
        {
            const bool isAccepted = false;
            return validateGetReservation(isAccepted);
        }

        internal string getAccpetedReservation(string token)
        {
            const bool isAccepted = true;

            TokenService tokenService = new TokenService(token);

            string failResponse = ResponseR.fail.ToString(); string response = failResponse;
            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByTokenIsAdmin();
            if (hasAdminInDatabaseOverApi)
            {

                response = validateGetReservation(isAccepted);
            }

            return response;

        }




        private string validateGetReservation(bool isAccepted)
        {

         
            string response = reservationDao.getReservations(isAccepted);

            return response;

        }

    }
}
