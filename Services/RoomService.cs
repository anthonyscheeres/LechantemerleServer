using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Services
{
    public class RoomService
    {
        TokenService tokenService = new TokenService();
        RoomDao roomDao = new RoomDao();

       public string ValidateAddRoom(RoomModel roomModel, string token)
        {
            string response = ResponseR.fail.ToString();
            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByToken(token);
            if (hasAdminInDatabaseOverApi) {
                roomDao.sendQueryToDatabaseToAddBed(roomModel.amountOfBeds);
                response = ResponseR.success.ToString();
            }
            return response;
        }
    }
}
