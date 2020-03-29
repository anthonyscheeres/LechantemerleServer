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
            return AddRoom(roomModel, token);
        }

        private string AddRoom(RoomModel roomModel, string token)
        {
            TokenService tokenService = new TokenService(token);
            string successResponse = ResponseR.success.ToString();

            tokenService.getPermissionFromDatabaseByTokenIsAdmin();
            string response;

            roomDao.sendQueryToDatabaseToAddBed(roomModel.amountOfBeds);
            response = successResponse;
            return response;
        }

        internal string ValidateChangeRoomImg(RoomModel room, string token)
        {
            throw new NotImplementedException();
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
