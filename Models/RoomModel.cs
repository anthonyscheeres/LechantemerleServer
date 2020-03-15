namespace ChantemerleApi.Models
{
    public class RoomModel
    {
        public int amountOfBeds { get; set; }

        public RoomModel(int amountOfBeds)
        {
            this.amountOfBeds = amountOfBeds;
        }

        public RoomModel()
        {
        }
    }
}
