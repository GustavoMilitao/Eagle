using EagleEntities;
using EagleDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleBLL
{
    public class PaymentMethodBLL
    {
        private PaymentMethodDAL paymentMethodDAL;

        public PaymentMethodDAL PaymentMethodDAL
        {
            get
            {
                if (paymentMethodDAL == null)
                    paymentMethodDAL = new PaymentMethodDAL();
                return paymentMethodDAL;
            }
        }

        public int InsertPaymentMethod(PaymentMethod paymentMethod)
        {
            return PaymentMethodDAL.InsertPaymentMethod(paymentMethod);
        }

        public bool UpdatePaymentMethod(PaymentMethod paymentMethod)
        {
            return PaymentMethodDAL.UpdatePaymentMethod(paymentMethod);
        }

        public PaymentMethod getPaymentMethodByID(int id)
        {
            return PaymentMethodDAL.getPaymentMethodByID(id);
        }

        public bool DeletePaymentMethodByID(int id)
        {
            return PaymentMethodDAL.DeletePaymentMethodByID(id);
        }

        public List<PaymentMethod> ListPaymentMethods()
        {
            return PaymentMethodDAL.ListPaymentMethods();
        }
    }
}

