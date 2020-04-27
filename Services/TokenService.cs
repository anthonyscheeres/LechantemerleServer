using anthonyscheeresApi.Providers;
using ChantemerleApi.Dao;
using System.Security.Authentication;

namespace ChantemerleApi.Services
{
    public class TokenService
    {
        private readonly TokenDao tokenDao =DaoProvider.getToken();
   



        /**
    * @author Anthony Scheeres
    */
        internal void getPermissionFromDatabaseByTokenIsAdmin(string token)
        {
            getPermissionFromDatabaseByTokenIsAdmin(token);

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





        internal  double TokenToUserId(string token)
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






