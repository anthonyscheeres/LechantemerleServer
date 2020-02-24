using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChantemerleApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChantemerleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        PermissionService permissionService = new PermissionService();
        /*      // GET: api/Permission
              [HttpGet]
              public IEnumerable<string> Get()
              {
                  return new string[] { "value1", "value2" };
              }

              // GET: api/Permission/5
              [HttpGet("{id}", Name = "Get")]
              public string Get(int id)
              {
                  return "value";
              }
      */
        // POST: api/Permission
        [HttpPost("{token}")]
        public string Post(string token, [FromBody] UserModel user)
        {
            return permissionService.loginUserAfterValidation(user);
        }
/*
        // PUT: api/Permission/5
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
