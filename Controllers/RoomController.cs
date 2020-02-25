using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChantemerleApi.Models;
using ChantemerleApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChantemerleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        RoomService roomService = new RoomService();

        // GET: api/room/
        [HttpGet]
        public string Get()
        {
            return roomService.getAllAvailableRoomsForReservation();
        }


        // POST api/room
        [HttpPost("{token}")]
        public string Post(string token, [FromBody] RoomModel room)
        {
            return roomService.ValidateAddRoom(room, token);
        }
    }
}
