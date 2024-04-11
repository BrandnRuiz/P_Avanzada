using P_WebMartes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P_WebMartes.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login( User entidad )
        {

            return RedirectToAction("Home", "Login");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register( User entidad )
        {
            return View();
        }

        [HttpGet]
        public ActionResult RecoverAccess()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecoverAccess( User entidad )
        {
            return View();
        }

        [HttpGet]
        public ActionResult Home() 
        { 
            return View();
        }
    }
}