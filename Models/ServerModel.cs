using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Models
{
	public class ServerModel
	{
		private List<RestApiModel> restApi { get; set; }
		private List<DatabaseModel> database { get; set; }
		private MailModel mail { get; set; }
	}
}