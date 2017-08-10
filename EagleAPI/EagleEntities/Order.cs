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

        public int ID_User { get; set; }

        public int ID_Distributor { get; set; }

        public int ID_Driver { get; set; }

        public double TotalPrice { get; set; }

        public List<Product> Products_List { get; set; }

        public List<Order_Payment> Payments { get; set; }

        public DateTime Reg_Date { get; set; }

        public User User { get; set; }

        public User Distributor { get; set; }

        public User Driver { get; set; }

    }
}
