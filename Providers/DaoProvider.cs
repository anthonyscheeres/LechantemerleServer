

using ChantemerleApi.Dao;

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


            if (contactInfoDao == null)
             {
                contactInfoDao = new ContactInfoDao(ConnectionProvider.getProvide());
            }



            return contactInfoDao;
        }

        internal static PermissionDao getPermission()
        {
            if (permissionDao == null)
            {
                permissionDao = new PermissionDao(ConnectionProvider.getProvide());
            }

            return permissionDao;
        }


        internal static TokenDao getToken()
        {
            if (tokenDao == null)
            {
                tokenDao = new TokenDao(ConnectionProvider.getProvide());
            }

            return tokenDao;
        }

        internal static UserDao getUser()
        {
            if (userDao == null)
            {
                userDao = new UserDao(ConnectionProvider.getProvide());
            }

            return userDao;

        }

        internal static ReservationDao getResrvation()
        {
            if (reservationDao == null)
            {
                reservationDao = new ReservationDao(ConnectionProvider.getProvide());
            }

            return reservationDao;
        }

        internal static RoomDao getRoom()
        {
            if (roomDao == null)
            {
                roomDao = new RoomDao(ConnectionProvider.getProvide());
            }

            return roomDao;
        }

    }
}
