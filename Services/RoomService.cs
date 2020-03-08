using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using System;

namespace ChantemerleApi.Services
{
    public class RoomService
    {

        private readonly RoomDao roomDao = new RoomDao();

        internal string ValidateAddRoom(RoomModel roomModel, string token)
        {
            if (roomModel == null) throw new ArgumentNullException(nameof(roomModel));
            TokenService tokenService = new TokenService(token);
            string response = ResponseR.fail.ToString();
            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByTokenIsAdmin();
            if (hasAdminInDatabaseOverApi)
            {
                roomDao.sendQueryToDatabaseToAddBed(roomModel.amountOfBeds);
                response = ResponseR.success.ToString();
            }
            return response;
        }

        internal string getAllAvailableRoomsForReservation()
        {
            const bool isOutOfOrder = false;
            return roomDao.getAllRoomsOutOrInOrder(isOutOfOrder);
        }
    }
}
