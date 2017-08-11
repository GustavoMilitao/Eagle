using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{

    public class CreditCard
    {
        public int ID { get; set; }

        public int IDPaymentMethod { get; set; }

        public string NameInCard { get; set; }

        public string CardNumber { get; set; }

        public DateTime ValidTru { get; set; }

        public string CVV { get; set; }

        public DateTime RegDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

    }
}
