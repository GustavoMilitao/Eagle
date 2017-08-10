using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{

    public class Credit_Card
    {
        public int ID { get; set; }

        public int ID_Payment_Method { get; set; }

        public string NameInCard { get; set; }

        public string Card_Number { get; set; }

        public DateTime Valid_Tru { get; set; }

        public string CVV { get; set; }

        public DateTime Reg_Date { get; set; }

        public Payment_Method Payment_Method { get; set; }

    }
}
