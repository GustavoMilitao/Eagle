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
    public class CreditCardsController : ApiController
    {
        private CreditCardBLL creditCardBLL;

        public CreditCardBLL CreditCardBLL
        {
            get
            {
                if (creditCardBLL == null)
                    creditCardBLL = new CreditCardBLL();
                return creditCardBLL;
            }
        }


        

        // GET api/values
        public JsonResult<List<CreditCard>> Get()
        {
            List<CreditCard> creditCards = CreditCardBLL.ListCreditCards();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(creditCards, serializerSettings);
        }

      

        // GET api/values/5
        public JsonResult<CreditCard> Get(int id)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(CreditCardBLL.getCreditCardByID(id), serializerSettings);
        }

        // POST api/values
        public int Post([FromBody]string creditCard)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            CreditCard u = JsonConvert.DeserializeObject<CreditCard>(creditCard, serializerSettings);
            return CreditCardBLL.InsertCreditCard(u);
        }
        // PUT api/values/5
        public Object Put(int id, [FromBody]string creditCard)
        {
            CreditCard u = JsonConvert.DeserializeObject<CreditCard>(creditCard);
            u.ID = id;
            return new { success = CreditCardBLL.UpdateCreditCard(u) };
        }

        // DELETE api/values/5
        public Object Delete(int id)
        {
            return new { success = CreditCardBLL.DeleteCreditCardByID(id) };
        }

       
    }
}

