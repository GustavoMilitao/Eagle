using EagleEntities;
using EagleDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EagleBLL
{
    public class OrderBLL
    {
        private OrderDAL orderDAL;

        public OrderDAL OrderDAL
        {
            get
            {
                if (orderDAL == null)
                    orderDAL = new OrderDAL();
                return orderDAL;
            }
        }

        public int InsertOrder(Order order)
        {
            return OrderDAL.InsertOrder(order);
        }

        public bool UpdateOrder(Order order)
        {
            return OrderDAL.UpdateOrder(order);
        }

        public Order getOrderByID(int id)
        {
            return OrderDAL.getOrderByID(id);
        }

        public bool DeleteOrderByID(int id)
        {
            return OrderDAL.DeleteOrderByID(id);
        }

        public List<Order> ListOrders()
        {
            return OrderDAL.ListOrders();
        }
    }
}

