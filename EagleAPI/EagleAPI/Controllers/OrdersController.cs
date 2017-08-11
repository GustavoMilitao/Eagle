using Newtonsoft.Json;
using EagleBLL;
using EagleEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace EagleAPI.Controllers
{
    public class OrdersController : ApiController
    {
        private OrderBLL orderBLL;

        public OrderBLL OrderBLL
        {
            get
            {
                if (orderBLL == null)
                    orderBLL = new OrderBLL();
                return orderBLL;
            }
        }


        

        // GET api/values
        public JsonResult<List<Order>> Get()
        {
            List<Order> orders = OrderBLL.ListOrders();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(orders, serializerSettings);
        }

      

        // GET api/values/5
        public JsonResult<Order> Get(int id)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(OrderBLL.getOrderByID(id), serializerSettings);
        }

        // POST api/values
        public int Post([FromBody]string order)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            Order u = JsonConvert.DeserializeObject<Order>(order, serializerSettings);
            return OrderBLL.InsertOrder(u);
        }
        // PUT api/values/5
        public Object Put(int id, [FromBody]string order)
        {
            Order u = JsonConvert.DeserializeObject<Order>(order);
            u.ID = id;
            return new { success = OrderBLL.UpdateOrder(u) };
        }

        // DELETE api/values/5
        public Object Delete(int id)
        {
            return new { success = OrderBLL.DeleteOrderByID(id) };
        }

       
    }
}

