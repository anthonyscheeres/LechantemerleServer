using ChantemerleApi.Dao;
using System;
using System.Security.Authentication;

namespace ChantemerleApi.Services
{
    public class TokenService
    {
        private readonly TokenDao tokenDao = new TokenDao();
        private string token;

        /**
    * @author Anthony Scheeres
    */
        //Get tokenServices by passsing the token
        internal TokenService(string token)
        {
            this.token = token;
        }


        /**
    * @author Anthony Scheeres
    */
        internal bool getPermissionFromDatabaseByTokenIsAdmin()
        {
            //default response
            bool response = false;

            try
            {

                response = tokenDao.getPermissionFromDatabaseByTokenHasAdmin(this.token);

            }

            catch (InvalidCastException error)
            {
                //pars error means a problem in the query. 
                response = false;
            }

            return response;
        }



        /**
* @author Anthony Scheeres
*/
        internal double TokenToUserId()
        {
            return tokenDao.TokenToUserId(this.token);
        }

    }
}






