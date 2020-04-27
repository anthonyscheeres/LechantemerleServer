using anthonyscheeresApi.Providers;
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
        TokenService tokenService = ServiceProvider.getToken();

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
            
            string successResponse = ResponseR.success.ToString();

            tokenService.getPermissionFromDatabaseByTokenIsAdmin(token);
            string response;

            roomDao.sendQueryToDatabaseToAddBed(roomModel.amountOfBeds);
            response = successResponse;
            return response;
        }

        internal string ValidateChangeRoomImg(RoomModel room, string token)
        {
            
            string successResponse = ResponseR.success.ToString();

            tokenService.getPermissionFromDatabaseByTokenIsAdmin(token);
            string response;

            roomDao.sendQueryToDatabaseToChangeBedImg(room.img, room.id);
            response = successResponse;
            return response;
        }

        internal string ValidateRemoveRoom(RoomModel room, string token)
        {
            
            string successResponse = ResponseR.success.ToString();

            tokenService.getPermissionFromDatabaseByTokenIsAdmin(token);
            string response;

            roomDao.sendQueryToDatabaseToDeleteRoom(room.id);
            response = successResponse;
            return response;
        }

        internal string ValidateChangeRoombeds(RoomModel room, string token)
        {
            
            string successResponse = ResponseR.success.ToString();

            tokenService.getPermissionFromDatabaseByTokenIsAdmin(token);
            string response;

            roomDao.sendQueryToDatabaseToChangeAmountBeds(room.amountOfBeds, room.id);
            response = successResponse;
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
