namespace ChantemerleApi.Models
{
    public class RoomModel
    {
        public int amountOfBeds { get; set; }
        public string img { get; set; }

        public int id { get; set; }

        public RoomModel(int amountOfBeds, string img, int id)
        {
            this.amountOfBeds = amountOfBeds;
            this.img = img;
            this.id = id;
        }

        public RoomModel()
        {
        }
    }
}
