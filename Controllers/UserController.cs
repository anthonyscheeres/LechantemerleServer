using ChantemerleApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ChantemerleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        PermissionService permissionService = new PermissionService();
        UserService userService = new UserService();

        // GET: api/User/showAllUsers
        [Route("showAllUsers")]
        [HttpGet("{token}")]
        public string Get([FromQuery] string token)
        {
            return userService.validateShowAllUsersIncludingAdmins(token); ;
        }

        // POST: api/User/register
        [HttpPost]
        [Route("register")]
        public string Post([FromBody] UserModel user)
        {


            return userService.registerValidateUserService(user);
        }

        // PUT: api/User/chanceUsernamePassword?token={token}
        [HttpPut("{token}")]
        [Route("chanceUsernamePassword")]
        public string letAnUserChangeItsOwnUsernameOrPassword([FromQuery] string token, [FromBody] UserModel user)
        {

            return userService.letAnUserChangeItsOwnUsernameOrPassword(user, token);
        }

        // DELETE: api/User/deleteUser?token={token}
        [HttpDelete("{token}")]
        [Route("deleteUser")]
        public string deleteUserByModel(string token, [FromBody] UserModel user)
        {

            return userService.validatDeleteUserByModel(token, user);
        }

        // GET: api/User/validateToken?token={token}
        [HttpGet("token")]
        [Route("validateToken")]
        public string validateToken([FromQuery] string token)
        {
          
            return userService.validateToken(token);

        }

  
        // POST: api/User/login
        [Route("login")]
        [HttpPost]

        public string loginUser([FromBody] UserModel user)
        {
            //ask the permission layer what permission this user has after an validation
            return permissionService.loginUserAfterValidation(user);
        }

        // POST: api/User/validateMail?token={token}
        [HttpPost("token")]
        [Route("validateMail")]

        public string sendNewValidateEmailLink([FromQuery] string token)
        {
            return userService.validateMailAgain(token);
        }

        // GET: api/User/validateGetProfile?token={token}
        [HttpGet("token")]
        [Route("validateGetProfile")]
        public string validateProfileToken([FromQuery] string token)
        {

            return userService.validateProfile(token);

        }


    }
}
