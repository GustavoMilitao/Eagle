using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{
    public class Car_Customa
    {
        public int ID { get; set; }

        public int ID_Car { get; set; }

        public int ID_User { get; set; }

        public List<Car_Piece_Customa> Car_Pieces_Customa { get; set; }

        public Car Car { get; set; }

        public User User { get; set; }

        public double TotalCustomaValuePerKm { get; set; }

    }
}
