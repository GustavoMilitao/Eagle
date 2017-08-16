using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{
    public class OrderPayment
    {
        public int ID { get; set; }

        public int IDPayMethod { get; set; }

        public int IDOrder { get; set; }

        public double Value { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public Order Order { get; set; }

        public DateTime RegDate { get; set; }

    }
}
