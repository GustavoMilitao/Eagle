using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{
    public class CarCustoma
    {
        public int ID { get; set; }

        public int IDCar { get; set; }

        public int IDUser { get; set; }

        public List<CarPieceCustoma> CarPiecesCustoma { get; set; }

        public Car Car { get; set; }

        public User User { get; set; }

        public double TotalCustomaValuePerKm { get; set; }

    }
}
