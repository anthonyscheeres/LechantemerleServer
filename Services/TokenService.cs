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
            getPermissionFromDatabaseByTokenIsAdmin(token);

        }


        /**
* @author Anthony Scheeres
*/
        internal void getPermissionFromDatabaseByTokenIsAdmin(string tok)
        {
            getPermissionFromDatabaseByTokenIsAdmin1(tok);

        }



        /**
    * @author Anthony Scheeres
    */
       private void getPermissionFromDatabaseByTokenIsAdmin1(string token)
        {
            //default response
            bool response = false;



            response = tokenDao.getPermissionFromDatabaseByTokenHasAdmin(token);

            if (response != true) throw new AuthenticationException();

        }









        /**
* @author Anthony Scheeres
*/
        internal double TokenToUserId()
        {
            return tokenDao.TokenToUserIdThrowsException(token);
        }

    }
}






