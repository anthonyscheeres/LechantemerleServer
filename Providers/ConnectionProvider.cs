
using ChantemerleApi.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anthonyscheeresApi.Providers
{
    public static class ConnectionProvider
    {
        
        private static NpgsqlConnection npgsqlConnection { set; get; }
       
        
        public static NpgsqlConnection getProvide()
        {
            if (ConnectionProvider.npgsqlConnection ==null)
            {
                string cs = DataModel.getConfigModel().databaseCredentials.cs;
                ConnectionProvider.npgsqlConnection = ConnectionProvider.getProvide();

            }
            return ConnectionProvider.npgsqlConnection;
        }

    }
}
