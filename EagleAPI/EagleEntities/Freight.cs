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

        public int ID_User_Driver { get; set; }

        public int ID_Car { get; set; }

        public int ID_Car_Customa { get; set; }

        public int ID_Driver_Gain { get; set; }

        public double TotalFreightCostPerKm { get; set; }

        public double TotalFreight { get; set; }

        public DateTime Reg_Date { get; set; }

        public User Driver { get; set; }

        public Car Car { get; set; }

        public Car_Customa Car_Customa { get; set; }

        public Driver_Gain Driver_Gain { get; set; }

    }
}
