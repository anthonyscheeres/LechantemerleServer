using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChantemerleApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
/*
        // POST: api/Reservation
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Reservation/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
