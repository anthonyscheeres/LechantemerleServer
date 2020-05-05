using ChantemerleApi.Utilities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Dao
{
    public class DaoBase
    {
        internal NpgsqlConnection _connection { get; set; }
  
    }
}
