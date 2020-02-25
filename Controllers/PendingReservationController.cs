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
    public class PendingReservationController : ControllerBase
    {

        ReservationService reservationService = new ReservationService();
        // GET: api/PendingReservation/5
        [HttpGet("{token}")]
        public string Get(string token)
        {
            return "value";
        }

        // POST: api/PendingReservation
        [HttpPost]
        public string Post([FromBody] ReservationModel reservation)
        {
            return reservationService.addPendingReservation(reservation);
        }

        // PUT: api/PendingReservation/5
        [HttpPut("{token}")]
        public string Put(string token, [FromBody] ReservationModel reservation)
        {
            return reservationService.acceptPendingReservation(reservation);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{token}")]
        public string Delete(string token, [FromBody] ReservationModel reservation)
        {
            return reservationService.deleteReservationByModel(reservation);
        }
    }
}
