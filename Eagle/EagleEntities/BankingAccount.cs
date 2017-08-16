using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleEntities
{
    public class BankingAccount
    {
        public int ID { get; set; }

        public int IDUser { get; set; }

        public string Bankcode { get; set; }

        public string Bankname { get; set; }

        public string Agency { get; set; }

        public string CurrentAccount { get; set; }

        public string Digit { get; set; }

        public DateTime RegDate { get; set; }

        public User User { get; set; }

    }
}
