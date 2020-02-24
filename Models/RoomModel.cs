using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
