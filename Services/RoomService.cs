using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using System;

namespace ChantemerleApi.Services
{


    /**
* @author Anthony Scheeres
*/
    public class RoomService
    {

        private readonly RoomDao roomDao = new RoomDao();


        /**
* @author Anthony Scheeres
*/
        internal string ValidateAddRoom(RoomModel roomModel, string token)
        {
            if (roomModel == null) throw new ArgumentNullException(nameof(roomModel));
            TokenService tokenService = new TokenService(token);
            string failResponse = ResponseR.fail.ToString(); 
            tokenService.getPermissionFromDatabaseByTokenIsAdmin();
            string response;
                roomDao.sendQueryToDatabaseToAddBed(roomModel.amountOfBeds);
                response = ResponseR.success.ToString();
    
            return response;
        }


        /**
* @author Anthony Scheeres
*/
        internal string getAllAvailableRoomsForReservation()
        {
            const bool isOutOfOrder = false;
            return roomDao.getAllRoomsOutOrInOrder(isOutOfOrder);
        }
    }
}
