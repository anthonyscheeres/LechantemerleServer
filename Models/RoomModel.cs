namespace ChantemerleApi.Models
{
    public class RoomModel
    {
        public int amountOfBeds { get; }

        public RoomModel(int amountOfBeds)
        {
            this.amountOfBeds = amountOfBeds;
        }

    }
}
