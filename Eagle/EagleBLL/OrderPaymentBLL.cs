using EagleEntities;
using EagleDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleBLL
{
    public class OrderPaymentBLL
    {
        private OrderPaymentDAL orderPaymentDAL;

        public OrderPaymentDAL OrderPaymentDAL
        {
            get
            {
                if (orderPaymentDAL == null)
                    orderPaymentDAL = new OrderPaymentDAL();
                return orderPaymentDAL;
            }
        }

        public int InsertOrderPayment(OrderPayment orderPayment)
        {
            return OrderPaymentDAL.InsertOrderPayment(orderPayment);
        }

        public bool UpdateOrderPayment(OrderPayment orderPayment)
        {
            return OrderPaymentDAL.UpdateOrderPayment(orderPayment);
        }

        public OrderPayment getOrderPaymentByID(int id)
        {
            return OrderPaymentDAL.getOrderPaymentByID(id);
        }

        public bool DeleteOrderPaymentByID(int id)
        {
            return OrderPaymentDAL.DeleteOrderPaymentByID(id);
        }

        public List<OrderPayment> ListOrderPayments()
        {
            return OrderPaymentDAL.ListOrderPayments();
        }
    }
}

