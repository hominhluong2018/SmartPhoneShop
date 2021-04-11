using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneShop.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Signin()
        {
            return View();
        }
        public ActionResult Regist()
        {
            return View();
        }
    }
}