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
    public class CarPieceCustomasController : ApiController
    {
        private CarPieceCustomaBLL carPieceCustomaBLL;

        public CarPieceCustomaBLL CarPieceCustomaBLL
        {
            get
            {
                if (carPieceCustomaBLL == null)
                    carPieceCustomaBLL = new CarPieceCustomaBLL();
                return carPieceCustomaBLL;
            }
        }


        

        // GET api/values
        public JsonResult<List<CarPieceCustoma>> Get()
        {
            List<CarPieceCustoma> carPieceCustomas = CarPieceCustomaBLL.ListCarPieceCustomas();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(carPieceCustomas, serializerSettings);
        }

      

        // GET api/values/5
        public JsonResult<CarPieceCustoma> Get(int id)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(CarPieceCustomaBLL.getCarPieceCustomaByID(id), serializerSettings);
        }

        // POST api/values
        public int Post([FromBody]string carPieceCustoma)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            CarPieceCustoma u = JsonConvert.DeserializeObject<CarPieceCustoma>(carPieceCustoma, serializerSettings);
            return CarPieceCustomaBLL.InsertCarPieceCustoma(u);
        }
        // PUT api/values/5
        public Object Put(int id, [FromBody]string carPieceCustoma)
        {
            CarPieceCustoma u = JsonConvert.DeserializeObject<CarPieceCustoma>(carPieceCustoma);
            u.ID = id;
            return new { success = CarPieceCustomaBLL.UpdateCarPieceCustoma(u) };
        }

        // DELETE api/values/5
        public Object Delete(int id)
        {
            return new { success = CarPieceCustomaBLL.DeleteCarPieceCustomaByID(id) };
        }

       
    }
}

