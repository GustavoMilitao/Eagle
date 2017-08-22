using EagleAPI.Controllers;
using EagleEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EagleUI.Interface.Controllers
{
    public class LoginController : Controller
    {
        UsersController usersController = new UsersController();

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
                var json = usersController.Get(user, senha);
                if (json.Content != null)
                {
                    var guid = Guid.NewGuid().ToString();
                    Session[guid] = json.Content;
                    var qtdDays = keepLogged ? 9999 : 0;
                    return Json(new { success = true, sessionID = guid, days = qtdDays });
                }
                return Json(new { success = false, message = "Usuário ou senha inválidos." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [Route("Recover")]
        public ActionResult Recover(string sessionID)
        {
            User user = (User)Session[sessionID];
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}