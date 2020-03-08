using ChantemerleApi.Models;
using ChantemerleApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChantemerleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        PermissionService permissionService = new PermissionService();
        ReservationService reservationService = new ReservationService();

        // POST: api/Permission/login
        [Route("login")]
        [HttpPost]
  
        public string Post( [FromBody] UserModel user)
        {
            //ask the permission layer what permission this user has after an validation
            return permissionService.loginUserAfterValidation(user);
        }
      
        // GET: api/PendingReservation/{token}
        [HttpGet("{token}")]
        public string Get(string token)
        {
            return reservationService.getPendingReservation(token);
        }

        // POST: api/PendingReservation

        [HttpPost("{token}")]
        public string Post([FromBody] ReservationModel reservation, string token)
        {
            return reservationService.addPendingReservation(reservation, token);
        }

        // PUT: api/PendingReservation/acceptPendingReservation/{token}
        [Route("acceptPendingReservation")]
        [HttpPut("{token}")]
        public string acceptPendingReservation(string token, [FromBody] ReservationModel reservation)
        {
            return reservationService.customerAcceptPendingReservationPotential(reservation, token);
        }

        // DELETE: api/ApiWithActions/5

        [Route("deleteReservation")]
        [HttpDelete("{token}")]
        public string deleteReservation(string token, [FromBody] ReservationModel reservation)
        {


            return reservationService.validatDeleteReservationByModel(reservation, token);
        }

    }
}
