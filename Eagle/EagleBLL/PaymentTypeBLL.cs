using EagleEntities;
using EagleDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleBLL
{
    public class PaymentTypeBLL
    {
        private PaymentTypeDAL paymentTypeDAL;

        public PaymentTypeDAL PaymentTypeDAL
        {
            get
            {
                if (paymentTypeDAL == null)
                    paymentTypeDAL = new PaymentTypeDAL();
                return paymentTypeDAL;
            }
        }

        public int InsertPaymentType(PaymentType paymentType)
        {
            return PaymentTypeDAL.InsertPaymentType(paymentType);
        }

        public bool UpdatePaymentType(PaymentType paymentType)
        {
            return PaymentTypeDAL.UpdatePaymentType(paymentType);
        }

        public PaymentType getPaymentTypeByID(int id)
        {
            return PaymentTypeDAL.getPaymentTypeByID(id);
        }

        public bool DeletePaymentTypeByID(int id)
        {
            return PaymentTypeDAL.DeletePaymentTypeByID(id);
        }

        public List<PaymentType> ListPaymentTypes()
        {
            return PaymentTypeDAL.ListPaymentTypes();
        }
    }
}

