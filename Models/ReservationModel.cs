using System;

namespace ChantemerleApi.Models
{
	public class ReservationModel
	{
		public int id { get; set; }

		public int roomno { get; set; }
		public string created_at { get; set; }


		public DateTime time_from { get; set; }
		public DateTime time_till { get; set; }
		public int price { get; set; }
		public bool accepted_by_super_user { get; set; }

		public bool everyMonth { get; set; }

		public ReservationModel(int roomno, DateTime time_from, DateTime time_till, int price, bool everyMonth)
		{
			this.roomno = roomno;
			this.time_from = time_from;
			this.time_till = time_till;
			this.price = price;
			this.everyMonth = everyMonth;
		}

		public ReservationModel()
		{
		}
	}
}
