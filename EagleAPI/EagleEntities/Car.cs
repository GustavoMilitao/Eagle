using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{
    public class Car
    {
        public int ID { get; set; }

        public int IDCarModel { get; set; }

        public int IDUser { get; set; }

        public string Carmodel { get; set; }

        public int Caryear { get; set; }

        public double GasKmPerLiter { get; set; }

        public double GasPrice { get; set; }

        public double GasPricePerKm { get; set; }

        public CarCustoma Customa { get; set; }

        public User User { get; set; }

    }
}
