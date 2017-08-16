using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{
    public class ConsumptionCost
    {
        public int ID { get; set; }

        public int IDCar { get; set; }

        public decimal GasKmPerLiter { get; set; }

        public decimal GasPrice { get; set; }

        public decimal GasPricePerKm { get; set; }

        public DateTime RegDate { get; set; }

        public Car Car { get; set; }

    }
}
