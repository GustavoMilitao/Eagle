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
    public class OrderPaymentsController : ApiController
    {
        private OrderPaymentBLL orderPaymentBLL;

        public OrderPaymentBLL OrderPaymentBLL
        {
            get
            {
                if (orderPaymentBLL == null)
                    orderPaymentBLL = new OrderPaymentBLL();
                return orderPaymentBLL;
            }
        }


        

        // GET api/values
        public JsonResult<List<OrderPayment>> Get()
        {
            List<OrderPayment> orderPayments = OrderPaymentBLL.ListOrderPayments();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(orderPayments, serializerSettings);
        }

      

        // GET api/values/5
        public JsonResult<OrderPayment> Get(int id)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(OrderPaymentBLL.getOrderPaymentByID(id), serializerSettings);
        }

        // POST api/values
        public int Post([FromBody]string orderPayment)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            OrderPayment u = JsonConvert.DeserializeObject<OrderPayment>(orderPayment, serializerSettings);
            return OrderPaymentBLL.InsertOrderPayment(u);
        }
        // PUT api/values/5
        public Object Put(int id, [FromBody]string orderPayment)
        {
            OrderPayment u = JsonConvert.DeserializeObject<OrderPayment>(orderPayment);
            u.ID = id;
            return new { success = OrderPaymentBLL.UpdateOrderPayment(u) };
        }

        // DELETE api/values/5
        public Object Delete(int id)
        {
            return new { success = OrderPaymentBLL.DeleteOrderPaymentByID(id) };
        }

       
    }
}

