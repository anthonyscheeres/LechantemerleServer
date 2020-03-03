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

        /*        // GET: api/Reservation
                [HttpGet]
                public IEnumerable<string> Get()
                {
                    return new string[] { "value1", "value2" };
                }
        */
        // GET: api/Reservation/5
        [HttpGet("{token}")]
        public string Get(string token)
        {
            return reservationService.getAccpetedReservation(token);
        }

  /*      // POST: api/Reservation
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }*/

        // PUT: api/Reservation/5
        [HttpPut("{token}")]
        public string Put(string token, [FromBody] ReservationModel reservation)
        {
           
            return reservationService.updateAcceptResevationByModel(token, reservation);
        }

   /*     // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
