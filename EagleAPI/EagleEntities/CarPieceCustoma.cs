using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{
    public class CarPieceCustoma
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public double KmToChange { get; set; }

        public double ValueToChange { get; set; }

        public int IDCustoma { get; set; }

        public CarCustoma CarCustoma { get; set; }

    }
}
