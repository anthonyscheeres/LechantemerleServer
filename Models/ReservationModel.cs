namespace ChantemerleApi.Models
{
	public class ReservationModel
	{
		public int id;

		public int roomno;
		public string created_at;


		public string time_from;
		public string time_till;
		public int price;
		public bool accepted_by_super_user;

		public ReservationModel(int id,

	int roomno,
	string created_at,


	string time_from,
	string time_till,
	int price,
	bool accepted_by_super_user)
		{
			this.id = id;

			this.roomno = roomno;
			this.created_at = created_at;


			this.time_from = time_from;
			this.time_till = time_till;
			this.price = price;
			this.accepted_by_super_user = accepted_by_super_user;
		}


	}
}
