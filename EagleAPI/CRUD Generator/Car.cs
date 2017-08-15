using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{
    public class Car
    {
        public int ID { get; set; }

        public int IDCarModel { get; set; }

        public int IDUser { get; set; }

        public CarModel CarModel { get; set; }

        public CarCustoma Customa { get; set; }

        public User User { get; set; }

    }
}
