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
    public class ProductsController : ApiController
    {
        private ProductBLL productBLL;

        public ProductBLL ProductBLL
        {
            get
            {
                if (productBLL == null)
                    productBLL = new ProductBLL();
                return productBLL;
            }
        }


        

        // GET api/values
        public JsonResult<List<Product>> Get()
        {
            List<Product> products = ProductBLL.ListProducts();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(products, serializerSettings);
        }

      

        // GET api/values/5
        public JsonResult<Product> Get(int id)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            return Json(ProductBLL.getProductByID(id), serializerSettings);
        }

        // POST api/values
        public int Post([FromBody]string product)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            Product u = JsonConvert.DeserializeObject<Product>(product, serializerSettings);
            return ProductBLL.InsertProduct(u);
        }
        // PUT api/values/5
        public Object Put(int id, [FromBody]string product)
        {
            Product u = JsonConvert.DeserializeObject<Product>(product);
            u.ID = id;
            return new { success = ProductBLL.UpdateProduct(u) };
        }

        // DELETE api/values/5
        public Object Delete(int id)
        {
            return new { success = ProductBLL.DeleteProductByID(id) };
        }

       
    }
}

