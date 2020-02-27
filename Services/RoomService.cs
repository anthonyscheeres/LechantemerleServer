using ChantemerleApi.Dao;
using ChantemerleApi.Models;

namespace ChantemerleApi.Services
{
    public class RoomService
    {
        private readonly TokenService tokenService = new TokenService();
        private readonly RoomDao roomDao = new RoomDao();

        internal string ValidateAddRoom(RoomModel roomModel, string token)
        {
            string response = ResponseR.fail.ToString();
            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByToken(token);
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
