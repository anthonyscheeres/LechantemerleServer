using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Services
{
    public class ReservationService
    {
        ReservationDao reservationDao = new ReservationDao();
        internal string deleteReservationByModel(ReservationModel reservation)
        {
            throw new NotImplementedException();
        }

        internal string addPendingReservation(ReservationModel reservation)
        {
            throw new NotImplementedException();
        }

        internal string acceptPendingReservation(ReservationModel reservation)
        {
            throw new NotImplementedException();
        }

        internal string getPendingReservation(string token)
        {
            bool isAccepted = false;
            return validateGetReservation(isAccepted, token);
        }

        internal string getAccpetedReservation(string token)
        {
            bool isAccepted = true;
            return validateGetReservation(isAccepted, token);
        }




        private string validateGetReservation(bool isAccepted,string token) {
            TokenService tokenService = new TokenService();
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
