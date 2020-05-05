

using ChantemerleApi.Dao;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anthonyscheeresApi.Providers
{

     internal static class DaoProvider
    {
       private static ContactInfoDao contactInfoDao { get; set; }
        private static PermissionDao permissionDao { get; set; }
        private static TokenDao tokenDao { get; set; }
        private static UserDao userDao { get; set; }

        private static RoomDao roomDao { get; set; }
        private static ReservationDao reservationDao { get; set; }

       
        internal static ContactInfoDao getContact()


        {


        //    if (contactInfoDao == null)
        //    {
                contactInfoDao = new ContactInfoDao(ConnectionProvider.getProvide());
          //  }
       //     else contactInfoDao._connection = ConnectionProvider.getProvide();



            return contactInfoDao;
        }

         internal static PermissionDao getPermission()
        {
         //   if (permissionDao ==null)
       //     {
                permissionDao = new PermissionDao(ConnectionProvider.getProvide());
       //     }
          //  else permissionDao._connection = ConnectionProvider.getProvide();

            return permissionDao;
        }


         internal static TokenDao getToken()
        {
       //     if (tokenDao ==null)
       //     {
                tokenDao = new TokenDao(ConnectionProvider.getProvide());
       //     }
           // else tokenDao._connection = ConnectionProvider.getProvide();

            return tokenDao;
        }

         internal static UserDao getUser()
        {
        //    if (userDao == null)
       //     {
                userDao = new UserDao(ConnectionProvider.getProvide());
       //     }
        //    else userDao._connection = ConnectionProvider.getProvide();

            return userDao;

        }

        internal static ReservationDao getResrvation()
        {
       //     if (reservationDao == null)
       //     {
                reservationDao = new ReservationDao(ConnectionProvider.getProvide());
        //    }
       //     else reservationDao._connection = ConnectionProvider.getProvide();

            return reservationDao;
        }

        internal static RoomDao getRoom()
        {
       //     if (roomDao == null)
       //     {
                roomDao = new RoomDao(ConnectionProvider.getProvide());
       //     }
       //     else roomDao._connection = ConnectionProvider.getProvide();

            return roomDao;
        }

    }
}
