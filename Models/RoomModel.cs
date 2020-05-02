namespace ChantemerleApi.Models
{
    public class RoomModel
    {
        public int amountOfBeds { get; set; }
        public string img { get; set; }

        public int id { get; set; }

        public string description { get; set; }

        public RoomModel(int amountOfBeds, string img, int id, string description)
        {
            this.amountOfBeds = amountOfBeds;
            this.img = img;
            this.id = id;
            this.description = description;
        }

        public RoomModel()
        {
        }
    }
}
