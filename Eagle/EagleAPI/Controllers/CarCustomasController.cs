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
    public class CarCustomasController : ApiController
    {
        private CarCustomaBLL carCustomaBLL;

        public CarCustomaBLL CarCustomaBLL
        {
            get
            {
                if (carCustomaBLL == null)
                    carCustomaBLL = new CarCustomaBLL();
                return carCustomaBLL;
            }
        }


        

        // GET api/values
        public JsonResult<List<CarCustoma>> Get()
        {
            List<CarCustoma> carCustomas = CarCustomaBLL.ListCarCustomas();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(carCustomas, serializerSettings);
        }

      

        // GET api/values/5
        public JsonResult<CarCustoma> Get(int id)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(CarCustomaBLL.getCarCustomaByID(id), serializerSettings);
        }

        // POST api/values
        public int Post([FromBody]string carCustoma)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            CarCustoma u = JsonConvert.DeserializeObject<CarCustoma>(carCustoma, serializerSettings);
            return CarCustomaBLL.InsertCarCustoma(u);
        }
        // PUT api/values/5
        public Object Put(int id, [FromBody]string carCustoma)
        {
            CarCustoma u = JsonConvert.DeserializeObject<CarCustoma>(carCustoma);
            u.ID = id;
            return new { success = CarCustomaBLL.UpdateCarCustoma(u) };
        }

        // DELETE api/values/5
        public Object Delete(int id)
        {
            return new { success = CarCustomaBLL.DeleteCarCustomaByID(id) };
        }

       
    }
}

