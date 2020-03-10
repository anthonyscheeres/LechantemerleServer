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
        //default  reservation service connection
        ReservationService reservationService = new ReservationService();


        // GET: api/Reservation/getAccpetedReservation/{token}
        [Route("getAcceptedReservation")]
        [HttpGet("{token}")]
        public string getAccpetedReservation(string token)
        {
            return reservationService.getAccpetedReservation(token);
        }



        // PUT: api/Reservation/updateAcceptResevation/{token}
        [Route("updateAcceptResevation")]
        [HttpPut("{token}")]
        public string updateAdminAcceptResevationByModel(string token, [FromBody] ReservationModel reservation)
        {

            return reservationService.updateAdminAcceptResevationByModel(token, reservation);
        }

        // GET: api/Reservation/getPendingReservation
        [Route("getPendingReservation")]
        [HttpGet]
        public string getPendingReservation()
        {
            return reservationService.getPendingReservation();
        }

        // POST: api/Reservation/addPendingReservation/{token}
        [Route("addPendingReservation")]
        [HttpPost("{token}")]
        public string addPendingReservation([FromBody] ReservationModel reservation, string token)
        {
            return reservationService.addPendingReservation(reservation, token);
        }


        // PUT: api/Reservation/claimReservations/{token}
        [Route("claimReservations")]
        [HttpPut("{token}")]
        public string customerAcceptPendingReservation(string token, [FromBody] ReservationModel reservation)
        {

            return reservationService.customerAcceptPendingReservationPotential(reservation, token);
        }

        //DELETE : api/Reservation/deleteReservation/{token}
        [Route("deleteReservation")]
        [HttpDelete("{token}")]
        public string deleteReservation(string token, [FromBody] ReservationModel reservation)
        {


            return reservationService.validatDeleteReservationByModel(reservation, token);
        }
    }
}
