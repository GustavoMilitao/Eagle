using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{
    public class Order_Payment
    {
        public int ID { get; set; }

        public int ID_Pay_Method { get; set; }

        public int ID_Order { get; set; }

        public double Value { get; set; }

        public Payment_Method Payment_Method { get; set; }

        public Order Order { get; set; }

        public DateTime Reg_Date { get; set; }

    }
}
