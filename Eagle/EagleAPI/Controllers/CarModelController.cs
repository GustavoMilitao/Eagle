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
    public class CarModelsController : ApiController
    {
        private CarModelBLL carModelBLL;

        public CarModelBLL CarModelBLL
        {
            get
            {
                if (carModelBLL == null)
                    carModelBLL = new CarModelBLL();
                return carModelBLL;
            }
        }


        

        // GET api/values
        public JsonResult<List<CarModel>> Get()
        {
            List<CarModel> carModels = CarModelBLL.ListCarModels();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(carModels, serializerSettings);
        }

      

        // GET api/values/5
        public JsonResult<CarModel> Get(int id)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(CarModelBLL.getCarModelByID(id), serializerSettings);
        }

        // POST api/values
        public int Post([FromBody]string carModel)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            CarModel u = JsonConvert.DeserializeObject<CarModel>(carModel, serializerSettings);
            return CarModelBLL.InsertCarModel(u);
        }
        // PUT api/values/5
        public Object Put(int id, [FromBody]string carModel)
        {
            CarModel u = JsonConvert.DeserializeObject<CarModel>(carModel);
            u.ID = id;
            return new { success = CarModelBLL.UpdateCarModel(u) };
        }

        // DELETE api/values/5
        public Object Delete(int id)
        {
            return new { success = CarModelBLL.DeleteCarModelByID(id) };
        }

       
    }
}

