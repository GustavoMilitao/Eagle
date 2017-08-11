using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{
    public class Product
    {
        public int ID { get; set; }

        public int IDUserDistributor { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public bool? Returnable { get; set; }

        public double SinglePrice { get; set; }

        public bool? Available { get; set; }

        public DateTime RegDate { get; set; }

        public User Distributor { get; set; }

    }
}
