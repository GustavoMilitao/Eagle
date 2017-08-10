using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{
    public class Payment_Method
    {
        public int ID { get; set; }

        public int? ID_User { get; set; }

        public int ID_Pay_Type { get; set; }

        public bool? Active { get; set; }

        public User User { get; set; }

        public Payment_Type Payment_Type { get; set; }

        public DateTime Reg_Date { get; set; }

    }
}
