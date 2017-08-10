using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{
    public class PaymentMethod
    {
        public int ID { get; set; }

        public int? IDUser { get; set; }

        public int IDPayType { get; set; }

        public bool? Active { get; set; }

        public User User { get; set; }

        public PaymentType PaymentType { get; set; }

        public DateTime RegDate { get; set; }

    }
}
