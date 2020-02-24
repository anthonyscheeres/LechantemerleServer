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

       public string addRoom(RoomModel room, string token)
        {
            string response = ResponseR.fail.ToString();
            bool admin = tokenService.getPermissionFromDatabaseByToken(token);
            if (admin) {
                roomDao.sendQueryToDatabaseToAddBed(room.amountOfBeds);
            }
            return response;
        }
    }
}
