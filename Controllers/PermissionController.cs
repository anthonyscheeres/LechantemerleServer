using ChantemerleApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChantemerleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        PermissionService permissionService = new PermissionService();

        // POST: api/Permission
        [HttpPost("{token}")]
        public string Post(string token, [FromBody] UserModel user)
        {
            return permissionService.loginUserAfterValidation(user);
        }


    }
}
