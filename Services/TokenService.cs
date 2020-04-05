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
            getPermissionFromDatabaseByTokenIsAdmin(this.token);

        }


        /**
* @author Anthony Scheeres
*/
        private void getPermissionFromDatabaseByTokenIsAdmin(string tok)
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




        internal double TokenToUserId()
        {
            return TokenToUserId(token);
        }

        private  double TokenToUserId(string token)
        {
            return TokenToUserId2(token);
        }




        /**
* @author Anthony Scheeres
*/
        private double TokenToUserId2(string token)
        {
            return tokenDao.TokenToUserIdThrowsException(token);
        }

    }
}






