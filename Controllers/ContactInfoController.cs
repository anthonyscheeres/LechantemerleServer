using ChantemerleApi.Models;
using ChantemerleApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChantemerleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        ContactInfoService contactInfoService = new ContactInfoService();


        // GET: api/ContactInfo
        [HttpGet]
        public string Get()
        {
            return contactInfoService.getContactInfoAsJsonFormatForPublicUsers();
        }



        // PUT: api/ContactInfo/5
        [HttpPut("{token}")]
        public string Put(string token, [FromBody] ContactInfoModel contactInfo)
        {
            return contactInfoService.validateChangeContactInfo(token, contactInfo);
        }

        /*        // DELETE: api/ApiWithActions/5
                [HttpDelete("{id}")]
                public void Delete(int id)
                {

                }*/
    }
}
