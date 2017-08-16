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
    public class ConsumptionCostsController : ApiController
    {
        private ConsumptionCostBLL consumptionCostBLL;

        public ConsumptionCostBLL ConsumptionCostBLL
        {
            get
            {
                if (consumptionCostBLL == null)
                    consumptionCostBLL = new ConsumptionCostBLL();
                return consumptionCostBLL;
            }
        }


        

        // GET api/values
        public JsonResult<List<ConsumptionCost>> Get()
        {
            List<ConsumptionCost> consumptionCosts = ConsumptionCostBLL.ListConsumptionCosts();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(consumptionCosts, serializerSettings);
        }

      

        // GET api/values/5
        public JsonResult<ConsumptionCost> Get(int id)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(ConsumptionCostBLL.getConsumptionCostByID(id), serializerSettings);
        }

        // POST api/values
        public int Post([FromBody]string consumptionCost)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            ConsumptionCost u = JsonConvert.DeserializeObject<ConsumptionCost>(consumptionCost, serializerSettings);
            return ConsumptionCostBLL.InsertConsumptionCost(u);
        }
        // PUT api/values/5
        public Object Put(int id, [FromBody]string consumptionCost)
        {
            ConsumptionCost u = JsonConvert.DeserializeObject<ConsumptionCost>(consumptionCost);
            u.ID = id;
            return new { success = ConsumptionCostBLL.UpdateConsumptionCost(u) };
        }

        // DELETE api/values/5
        public Object Delete(int id)
        {
            return new { success = ConsumptionCostBLL.DeleteConsumptionCostByID(id) };
        }

       
    }
}

