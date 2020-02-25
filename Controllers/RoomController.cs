using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChantemerleApi.Models;
using ChantemerleApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChantemerleApi.Controllers
{
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        RoomService roomService = new RoomService();


        // POST api/<controller>
        [HttpPost("{token}")]
        public string Post(string token, [FromBody] RoomModel room)
        {
            return roomService.ValidateAddRoom(room, token);
        }

    }
}
