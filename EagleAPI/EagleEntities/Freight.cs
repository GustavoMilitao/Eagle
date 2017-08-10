using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{
    public class Freight
    {
        public int ID { get; set; }

        public int IDUserDriver { get; set; }

        public int IDCar { get; set; }

        public int IDCarCustoma { get; set; }

        public int IDDriverGain { get; set; }

        public double TotalFreightCostPerKm { get; set; }

        public double TotalFreight { get; set; }

        public DateTime RegDate { get; set; }

        public User Driver { get; set; }

        public Car Car { get; set; }

        public CarCustoma CarCustoma { get; set; }

        public DriverGain DriverGain { get; set; }

    }
}
