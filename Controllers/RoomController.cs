using ChantemerleApi.Models;
using ChantemerleApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ChantemerleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        RoomService roomService = new RoomService();

        // GET: api/room/listAvailableRooms
        [Route("listAvailableRooms")]
        [HttpGet]
        public string getAllAvailableRoomsForReservation()
        {
            return roomService.getAllAvailableRoomsForReservation();
        }


        // POST api/room/addRoom/{token}

        [Route("addRoom")]
        [HttpPost("{token}")]
        public string addRoom(string token, [FromBody] RoomModel room)
        {
            return roomService.ValidateAddRoom(room, token);
        }
    }
}
