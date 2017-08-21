using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EagleUI.Interface.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(string user, string senha, bool keepLogged)
        {
            try
            {
                return Json(new { success = true, sessionID = Guid.NewGuid().ToString(), days = 9999 });
            }
            catch
            {
                return Json(new { success = false, message = "Errado" });
            }
        }

        [HttpPost]
        [Route("Recover")]
        public ActionResult Recover(string sessionID)
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}