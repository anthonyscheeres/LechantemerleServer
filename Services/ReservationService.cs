using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using System;

namespace ChantemerleApi.Services
{
    public class ReservationService
    {
        readonly TokenService tokenService = new TokenService();
        readonly ReservationDao reservationDao = new ReservationDao();
        internal string validatDeleteReservationByModel(ReservationModel reservation, string token)
        {
            string response = ResponseR.fail.ToString();
            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByToken(token);
            if (hasAdminInDatabaseOverApi)
            {
                response = ResponseR.success.ToString();
                reservationDao.deleteReservationByIdInDatabase(reservation.id);
            }

            return response;
        }

        internal string addPendingReservation(ReservationModel reservation)
        {
            throw new NotImplementedException();
        }

        internal string acceptPendingReservation(ReservationModel reservation, string token)
        {
            string response = ResponseR.fail.ToString();
            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByToken(token);
            if (hasAdminInDatabaseOverApi)
            {
                response = ResponseR.success.ToString();
                reservationDao.deleteReservationByIdInDatabase(reservation.id);
            }

            return response;
        }

        internal string getPendingReservation(string token)
        {
            const bool isAccepted = false;
            return validateGetReservation(isAccepted, token);
        }

        internal string getAccpetedReservation(string token)
        {
            const bool isAccepted = true;
            return validateGetReservation(isAccepted, token);
        }




        private string validateGetReservation(bool isAccepted, string token)
        {

            string response = ResponseR.fail.ToString();
            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByToken(token);
            if (hasAdminInDatabaseOverApi)
            {

                response = reservationDao.getReservations(isAccepted);

            }
            return response;

        }

    }
}
