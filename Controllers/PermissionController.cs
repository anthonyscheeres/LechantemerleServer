using ChantemerleApi.Models;
using ChantemerleApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChantemerleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        PermissionService permissionService = new PermissionService();
        ReservationService reservationService = new ReservationService();

        // POST: api/Permission/login
        [Route("login")]
        [HttpPost]
  
        public string Post( [FromBody] UserModel user)
        {
            //ask the permission layer what permission this user has after an validation
            return permissionService.loginUserAfterValidation(user);
        }
      
        

    }
}
