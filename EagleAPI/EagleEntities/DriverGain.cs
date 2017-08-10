using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{
    public class DriverGain
    {
        public int ID { get; set; }

        public int IDUserDriver { get; set; }

        public int IDCar { get; set; }

        public double NetGainPerKm { get; set; }

        public DateTime RegDate { get; set; }

        public User User { get; set; }

        public Car Car { get; set; }

    }
}
