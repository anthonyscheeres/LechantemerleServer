
using ChantemerleApi.Models;
using Npgsql;


namespace anthonyscheeresApi.Providers
{
    public static class ConnectionProvider
    {

        private static NpgsqlConnection _npgsqlConnection { set; get; }


        public static NpgsqlConnection getProvide()
        {

            string cs = DataModel.getConfigModel().databaseCredentials.cs;

            _npgsqlConnection = new NpgsqlConnection(cs);



            return _npgsqlConnection;
        }

    }
}
