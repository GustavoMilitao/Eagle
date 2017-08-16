using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;


namespace EagleUI.Interface.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Get()
        {
            return View();
        }
    }
}