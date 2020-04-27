
using ChantemerleApi.Models;
using Npgsql;


namespace anthonyscheeresApi.Providers
{
    public static class ConnectionProvider
    {
        
        private static NpgsqlConnection npgsqlConnection { set; get; }
       
        
        public static NpgsqlConnection getProvide()
        {
      
                string cs = DataModel.getConfigModel().databaseCredentials.cs;
      
            return new NpgsqlConnection(cs);
        }

    }
}
