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
    public class PaymentMethodsController : ApiController
    {
        private PaymentMethodBLL paymentMethodBLL;

        public PaymentMethodBLL PaymentMethodBLL
        {
            get
            {
                if (paymentMethodBLL == null)
                    paymentMethodBLL = new PaymentMethodBLL();
                return paymentMethodBLL;
            }
        }


        

        // GET api/values
        public JsonResult<List<PaymentMethod>> Get()
        {
            List<PaymentMethod> paymentMethods = PaymentMethodBLL.ListPaymentMethods();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(paymentMethods, serializerSettings);
        }

      

        // GET api/values/5
        public JsonResult<PaymentMethod> Get(int id)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(PaymentMethodBLL.getPaymentMethodByID(id), serializerSettings);
        }

        // POST api/values
        public int Post([FromBody]string paymentMethod)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            PaymentMethod u = JsonConvert.DeserializeObject<PaymentMethod>(paymentMethod, serializerSettings);
            return PaymentMethodBLL.InsertPaymentMethod(u);
        }
        // PUT api/values/5
        public Object Put(int id, [FromBody]string paymentMethod)
        {
            PaymentMethod u = JsonConvert.DeserializeObject<PaymentMethod>(paymentMethod);
            u.ID = id;
            return new { success = PaymentMethodBLL.UpdatePaymentMethod(u) };
        }

        // DELETE api/values/5
        public Object Delete(int id)
        {
            return new { success = PaymentMethodBLL.DeletePaymentMethodByID(id) };
        }

       
    }
}

