using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{
    public class CarModel
    {
        public int ID { get; set; }

        public string ModelName { get; set; }

        public string Brand { get; set; }

        public string Year { get; set; }

        public string Potency { get; set; }

        public bool? Flex { get; set; }

    }
}
