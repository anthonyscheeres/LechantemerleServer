using ChantemerleApi.Models;
using ChantemerleApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ChantemerleApi.Controllers
{

    /**
	 * @author Anthony Scheeres
	 */

    [Route("api/[controller]")]
    [ApiController]

    public class ReservationController : ControllerBase
    {

        ReservationService reservationService = new ReservationService();

        [HttpGet("{token}")]
        public string getAccpetedReservation(string token)
        {
            return reservationService.getAccpetedReservation(token);
        }



        // PUT: api/Reservation/5
        [HttpPut("{token}")]
        public string updateAcceptResevationByModel(string token, [FromBody] ReservationModel reservation)
        {

            return reservationService.updateAcceptResevationByModel(token, reservation);
        }

        [Route("getPendingReservation")]
        [HttpGet]
        public string getPendingReservation()
        {
            return reservationService.getPendingReservation();
        }

       [Route("addPendingReservation")]
        [HttpPost("{token}")]
        public string addPendingReservation([FromBody] ReservationModel reservation, string token)
        {
            return reservationService.addPendingReservation(reservation, token);
        }

        [Route("claimReservations")]
        [HttpPut("{token}")]
        public string customerAcceptPendingReservation(string token, [FromBody] ReservationModel reservation)
        {

            return reservationService.customerAcceptPendingReservationPotential(reservation, token);
        }

        //DELETE : api/Reservation/deleteReservation
        [Route("deleteReservation")]
        [HttpDelete("{token}")]
        public string deleteReservation(string token, [FromBody] ReservationModel reservation)
        {


            return reservationService.validatDeleteReservationByModel(reservation, token);
        }
    }
}
