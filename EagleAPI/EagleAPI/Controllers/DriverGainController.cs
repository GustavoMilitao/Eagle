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
    public class DriverGainsController : ApiController
    {
        private DriverGainBLL driverGainBLL;

        public DriverGainBLL DriverGainBLL
        {
            get
            {
                if (driverGainBLL == null)
                    driverGainBLL = new DriverGainBLL();
                return driverGainBLL;
            }
        }


        

        // GET api/values
        public JsonResult<List<DriverGain>> Get()
        {
            List<DriverGain> driverGains = DriverGainBLL.ListDriverGains();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(driverGains, serializerSettings);
        }

      

        // GET api/values/5
        public JsonResult<DriverGain> Get(int id)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(DriverGainBLL.getDriverGainByID(id), serializerSettings);
        }

        // POST api/values
        public int Post([FromBody]string driverGain)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            DriverGain u = JsonConvert.DeserializeObject<DriverGain>(driverGain, serializerSettings);
            return DriverGainBLL.InsertDriverGain(u);
        }
        // PUT api/values/5
        public Object Put(int id, [FromBody]string driverGain)
        {
            DriverGain u = JsonConvert.DeserializeObject<DriverGain>(driverGain);
            u.ID = id;
            return new { success = DriverGainBLL.UpdateDriverGain(u) };
        }

        // DELETE api/values/5
        public Object Delete(int id)
        {
            return new { success = DriverGainBLL.DeleteDriverGainByID(id) };
        }

       
    }
}

