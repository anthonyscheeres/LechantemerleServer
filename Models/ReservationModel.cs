namespace ChantemerleApi.Models
{
	public class ReservationModel
	{
		public int id { get; set; }

		public int roomno { get; set; }
		public string? created_at { get; set; }


		public string? time_from { get; set; }
		public string? time_till { get; set; }
		public int price { get; set; }
		public bool? accepted_by_super_user { get; set; }

		public ReservationModel(int id, int roomno, string created_at, string time_from, string time_till, int price, bool? accepted_by_super_user)
		{
			this.id = id;
			this.roomno = roomno;
			this.created_at = created_at;
			this.time_from = time_from;
			this.time_till = time_till;
			this.price = price;
			this.accepted_by_super_user = accepted_by_super_user;
		}

		public ReservationModel()
		{
		}
	}
}
