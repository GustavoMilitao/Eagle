using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{
    public class Car_Piece_Customa
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public double KmToChange { get; set; }

        public double ValueToChange { get; set; }

        public int ID_Customa { get; set; }

        public Car_Customa Car_Customa { get; set; }

    }
}
