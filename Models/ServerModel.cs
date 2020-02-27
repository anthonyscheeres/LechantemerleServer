using System.Collections.Generic;

namespace ChantemerleApi.Models
{
	public class ServerModel
	{
		private List<RestApiModel> restApi { get; set; }
		private List<DatabaseModel> database { get; set; }
		private MailModel mail { get; set; }
	}
}