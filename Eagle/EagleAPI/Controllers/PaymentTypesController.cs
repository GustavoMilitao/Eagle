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
    public class PaymentTypesController : ApiController
    {
        private PaymentTypeBLL paymentTypeBLL;

        public PaymentTypeBLL PaymentTypeBLL
        {
            get
            {
                if (paymentTypeBLL == null)
                    paymentTypeBLL = new PaymentTypeBLL();
                return paymentTypeBLL;
            }
        }


        

        // GET api/values
        public JsonResult<List<PaymentType>> Get()
        {
            List<PaymentType> paymentTypes = PaymentTypeBLL.ListPaymentTypes();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(paymentTypes, serializerSettings);
        }

      

        // GET api/values/5
        public JsonResult<PaymentType> Get(int id)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(PaymentTypeBLL.getPaymentTypeByID(id), serializerSettings);
        }

        // POST api/values
        public int Post([FromBody]string paymentType)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            PaymentType u = JsonConvert.DeserializeObject<PaymentType>(paymentType, serializerSettings);
            return PaymentTypeBLL.InsertPaymentType(u);
        }
        // PUT api/values/5
        public Object Put(int id, [FromBody]string paymentType)
        {
            PaymentType u = JsonConvert.DeserializeObject<PaymentType>(paymentType);
            u.ID = id;
            return new { success = PaymentTypeBLL.UpdatePaymentType(u) };
        }

        // DELETE api/values/5
        public Object Delete(int id)
        {
            return new { success = PaymentTypeBLL.DeletePaymentTypeByID(id) };
        }

       
    }
}

