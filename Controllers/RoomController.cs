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
        /*        // GET: api/<controller>
                [HttpGet]
                public IEnumerable<string> Get()
                {
                    return new string[] { "value1", "value2" };
                }

                // GET api/<controller>/5
                [HttpGet("{id}")]
                public string Get(int id)
                {
                    return "value";
                }*/

        // POST api/<controller>
        [HttpPost("{token}")]
        public string Post(string token, [FromBody] RoomModel room)
        {
            return roomService.addRoom(room, token);
        }

/*        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
