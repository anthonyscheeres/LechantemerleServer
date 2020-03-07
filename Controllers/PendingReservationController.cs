using ChantemerleApi.Models;
using ChantemerleApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ChantemerleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PendingReservationController : ControllerBase
    {

        ReservationService reservationService = new ReservationService();
        // GET: api/PendingReservation/5
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

        // PUT: api/PendingReservation/5
        [HttpPut("{token}")]
        public string Put(string token, [FromBody] ReservationModel reservation)
        {
            

            return reservationService.customerAcceptPendingReservationPotential(reservation, token);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{token}")]
        public string Delete(string token, [FromBody] ReservationModel reservation)
        {
            

            return reservationService.validatDeleteReservationByModel(reservation, token);
        }
    }
}
