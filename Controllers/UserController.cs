using ChantemerleApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ChantemerleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService userService = new UserService();

        // GET: api/User/5
        [HttpGet("{token}")]
        public string Get(string token)
        {
            return userService.validateShowAllUsersIncludingAdmins(token); ;
        }

        // POST: api/User
        [HttpPost]
        public string Post([FromBody] UserModel user)
        {
           

            return userService.registerValidateUserService(user);
        }

        // PUT: api/User/5
        [HttpPut("{token}")]
        public string Put(string token, [FromBody] UserModel user)
        {
           
            return userService.letAnUserChangeItsOwnUsernameOrPassword(user, token);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{token}")]
        public string Delete(string token, [FromBody] UserModel user)
        {
            

            return userService.validatDeleteUserByModel(token, user);
        }
    }
}
