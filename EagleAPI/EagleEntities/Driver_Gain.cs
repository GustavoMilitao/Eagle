using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{
    public class Driver_Gain
    {
        public int ID { get; set; }

        public int ID_User_Driver { get; set; }

        public int ID_Car { get; set; }

        public double NetGainPerKm { get; set; }

        public DateTime Reg_Date { get; set; }

        public User User { get; set; }

        public Car Car { get; set; }

    }
}
