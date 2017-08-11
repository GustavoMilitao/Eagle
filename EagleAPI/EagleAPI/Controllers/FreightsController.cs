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
    public class FreightsController : ApiController
    {
        private FreightBLL freightBLL;

        public FreightBLL FreightBLL
        {
            get
            {
                if (freightBLL == null)
                    freightBLL = new FreightBLL();
                return freightBLL;
            }
        }


        

        // GET api/values
        public JsonResult<List<Freight>> Get()
        {
            List<Freight> freights = FreightBLL.ListFreights();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(freights, serializerSettings);
        }

      

        // GET api/values/5
        public JsonResult<Freight> Get(int id)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(FreightBLL.getFreightByID(id), serializerSettings);
        }

        // POST api/values
        public int Post([FromBody]string freight)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            Freight u = JsonConvert.DeserializeObject<Freight>(freight, serializerSettings);
            return FreightBLL.InsertFreight(u);
        }
        // PUT api/values/5
        public Object Put(int id, [FromBody]string freight)
        {
            Freight u = JsonConvert.DeserializeObject<Freight>(freight);
            u.ID = id;
            return new { success = FreightBLL.UpdateFreight(u) };
        }

        // DELETE api/values/5
        public Object Delete(int id)
        {
            return new { success = FreightBLL.DeleteFreightByID(id) };
        }

       
    }
}

