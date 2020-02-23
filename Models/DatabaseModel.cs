using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Models
{
	public class DatabaseModel
	{
		private string username { get; set; }

		private string password { get; set; }

		private int portNumber { get; set; }

		private string databaseName { get; set; }

		private string hostName { get; set; }
	}
}
