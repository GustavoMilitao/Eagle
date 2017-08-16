using EagleEntities;
using EagleDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleBLL
{
    public class CreditCardBLL
    {
        private CreditCardDAL creditCardDAL;

        public CreditCardDAL CreditCardDAL
        {
            get
            {
                if (creditCardDAL == null)
                    creditCardDAL = new CreditCardDAL();
                return creditCardDAL;
            }
        }

        public int InsertCreditCard(CreditCard creditCard)
        {
            return CreditCardDAL.InsertCreditCard(creditCard);
        }

        public bool UpdateCreditCard(CreditCard creditCard)
        {
            return CreditCardDAL.UpdateCreditCard(creditCard);
        }

        public CreditCard getCreditCardByID(int id)
        {
            return CreditCardDAL.getCreditCardByID(id);
        }

        public bool DeleteCreditCardByID(int id)
        {
            return CreditCardDAL.DeleteCreditCardByID(id);
        }

        public List<CreditCard> ListCreditCards()
        {
            return CreditCardDAL.ListCreditCards();
        }
    }
}

