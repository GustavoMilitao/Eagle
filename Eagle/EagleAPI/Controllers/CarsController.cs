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
    public class CarsController : ApiController
    {
        private CarBLL carBLL;

        public CarBLL CarBLL
        {
            get
            {
                if (carBLL == null)
                    carBLL = new CarBLL();
                return carBLL;
            }
        }


        

        // GET api/values
        public JsonResult<List<Car>> Get()
        {
            List<Car> cars = CarBLL.ListCars();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(cars, serializerSettings);
        }

      

        // GET api/values/5
        public JsonResult<Car> Get(int id)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(CarBLL.getCarByID(id), serializerSettings);
        }

        // POST api/values
        public int Post([FromBody]string car)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            Car u = JsonConvert.DeserializeObject<Car>(car, serializerSettings);
            return CarBLL.InsertCar(u);
        }
        // PUT api/values/5
        public Object Put(int id, [FromBody]string car)
        {
            Car u = JsonConvert.DeserializeObject<Car>(car);
            u.ID = id;
            return new { success = CarBLL.UpdateCar(u) };
        }

        // DELETE api/values/5
        public Object Delete(int id)
        {
            return new { success = CarBLL.DeleteCarByID(id) };
        }

       
    }
}

