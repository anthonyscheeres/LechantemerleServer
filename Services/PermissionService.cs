using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Services
{
    public class PermissionService
    {
        PermissionDao permissionDao = new PermissionDao();

        public string loginUserAfterValidation(string username, string password)
        {
            return validateLoginUser(username, password);
        }


        public string loginUserAfterValidation(UserModel user)
        {
            return loginUserAfterValidation(user.username, user.password);
        }

        /**
* @author Anthony Scheeres
*/
        private string validateLoginUser(string username, string password)
        {
            string response = ResponseR.fail.ToString();
  
      
                loginUser(username, password);


                response = ResponseR.success.ToString();
        



            return response;


        }

        private void loginUser(string username, string password)
        {

        }



    }
}
