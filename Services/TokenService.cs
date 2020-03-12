using ChantemerleApi.Dao;
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
        internal void getPermissionFromDatabaseByTokenIsAdmin()
        {
            //default response
            bool response = false;



            response = tokenDao.getPermissionFromDatabaseByTokenHasAdmin(this.token);

            if (response != true) throw new AuthenticationException();

        }






        /**
* @author Anthony Scheeres
*/
        internal double TokenToUserId()
        {
            return tokenDao.TokenToUserIdThrowsException(this.token);
        }

    }
}






