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


        // GET: api/Reservation/getPendingResrvationsAdmin?token={token}
        [Route("getPendingResrvationsAdmin")]
        [HttpGet("{token}")]
        public string getPendingResrvationsAdmin([FromQuery] string token)
        {
            return reservationService.getAccpetedReservation(token);
        }

        

        // PUT: api/Reservation/updateAcceptResevation?token={token}
        [Route("updateAcceptResevation")]
        [HttpPut("{token}")]
        public string updateAdminAcceptResevationByModel([FromQuery] string token, [FromBody] ReservationModel reservation)
        {

            return reservationService.updateAdminAcceptResevationByModel(token, reservation);
        }
        // GET: api/Reservation/getPendingDatesByIdReservation?id={id}
        [Route("getPendingDatesByIdReservation")]
        [HttpGet("{id}")]
        public string getPendingDatesByIdReservation([FromQuery] int id)
        {
            return reservationService.getPendingDatesByIdReservation(id);
        }


        // GET: api/Reservation/getPendingReservation
        [Route("getPendingReservation")]
        [HttpGet]
        public string getPendingReservation()
        {
            return reservationService.getPendingReservation();
        }

        // GET: api/Reservation/getPendingReservation
        [Route("getPendingReservation")]
        [HttpGet("{id}")]
        public string getPendingReservation([FromQuery] int id)
        {
            return reservationService.getPendingReservation(id);
        }

        // GET: api/Reservation/getReservation
        [Route("getReservation")]
        [HttpGet("{token}")]
        public string getPendingReservation([FromQuery] string token)
        {
            return reservationService.getReservation(token);
        }


        // POST: api/Reservation/addPendingReservation?token={token}
        [Route("addPendingReservation")]
        [HttpPost("{token}")]
       
        public string addPendingReservation([FromBody] ReservationModel reservation, [FromQuery] string token)
        {
            return reservationService.addPendingReservation(reservation, token);
        }





        // PUT: api/Reservation/claimReservations?token={token}
        [Route("claimReservations")]
        [HttpPut("{token}")]
        public string customerAcceptPendingReservation([FromQuery] string token, [FromBody] ReservationModel reservation)
        {

            return reservationService.customerAcceptPendingReservationPotential(reservation, token);
        }




        // GET: api/Reservation/getUsersReservations?token={token}
        [Route("getUsersReservations")]
        [HttpGet("{token}")]
        public string getUsersReservations([FromQuery] string token)
        {
            return reservationService.getUserResrvations(token);
        }

        //DELETE : api/Reservation/deleteReservation?token={token}
        [Route("deleteReservation")]
        [HttpDelete("{token}")]
        public string deleteReservation([FromQuery] string token, [FromBody] ReservationModel reservation)
        {


            return reservationService.validatDeleteReservationByModel(reservation, token);
        }

        //DELETE : api/Reservation/deleteAllReservations?token={token}
        [Route("deleteAllReservations")]
        [HttpDelete("{token}")]
        public string deleteAllReservations([FromQuery] string token)
        {


            return reservationService.validatDeleteReservationAll(token);
        }
    }


}
