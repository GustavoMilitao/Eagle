using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{
    public class Order
    {
        public int ID { get; set; }

        public int IDUser { get; set; }

        public int IDDistributor { get; set; }

        public int IDDriver { get; set; }

        public double TotalPrice { get; set; }

        public List<Product> ProductsList { get; set; }

        public List<OrderPayment> Payments { get; set; }

        public DateTime RegDate { get; set; }

        public User User { get; set; }

        public User Distributor { get; set; }

        public User Driver { get; set; }

    }
}
