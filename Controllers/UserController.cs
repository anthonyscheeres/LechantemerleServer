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
        public string Get(string token)
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

        // PUT: api/User/{token}
        [HttpPut("{token}")]
        [Route("chanceUsernamePassword")]
        public string letAnUserChangeItsOwnUsernameOrPassword(string token, [FromBody] UserModel user)
        {
           
            return userService.letAnUserChangeItsOwnUsernameOrPassword(user, token);
        }

        // DELETE: api/User/deleteUser
        [HttpDelete("{token}")]
        [Route("deleteUser")]
        public string deleteUserByModel(string token, [FromBody] UserModel user)
        {
 
            return userService.validatDeleteUserByModel(token, user);
        }


  
        // POST: api/User/login
        [Route("login")]
        [HttpPost]

        public string loginUser([FromBody] UserModel user)
        {
            //ask the permission layer what permission this user has after an validation
            return permissionService.loginUserAfterValidation(user);
        }
    }
}
