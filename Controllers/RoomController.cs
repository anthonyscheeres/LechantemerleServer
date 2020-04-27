using anthonyscheeresApi.Providers;
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
        RoomService roomService = ServiceProvider.getRoom();

        // GET: api/Room/listAvailableRooms
        [Route("listAvailableRooms")]
        [HttpGet]
        public string getAllAvailableRoomsForReservation()
        {
            return roomService.getAllAvailableRoomsForReservation();
        }




        // PUT: api/Room/updateImgRoom?token={token}
        [Route("updateImgRoom")]
        [HttpPut("{token}")]
        public string updateImgRoom([FromQuery] string token, [FromBody] RoomModel room)
        {
            return roomService.ValidateChangeRoomImg(room, token);

        }


        // PUT: api/Room/updatAmountOfBedsRoom?token={token}
        [Route("updatAmountOfBedsRoom")]
        [HttpPut("{token}")]
        public string updateBedsRoom([FromQuery] string token, [FromBody] RoomModel room)
        {
            return roomService.ValidateChangeRoombeds(room, token);

        }

        // DELETE: api/Room/deleteRoom?token={token}
        [Route("deleteRoom")]
        [HttpDelete("{token}")]
        public string deleteRoom([FromQuery] string token, [FromBody] RoomModel room)
        {
            return roomService.ValidateRemoveRoom(room, token);
        }
    

    // POST api/Room/addRoom?token={token}

    [Route("addRoom")]
        [HttpPost("{token}")]
        public string addRoom([FromQuery] string token, [FromBody] RoomModel room)
        {
            return roomService.ValidateAddRoom(room, token);
        }
    }
}
