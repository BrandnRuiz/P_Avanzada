using Microsoft.Ajax.Utilities;
using P_WebMartes.Entidades;
using P_WebMartes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P_WebMartes.Controllers
{
    public class LoginController : Controller
    {

        UserModel model = new UserModel();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login( User entidad )
        {
            var res = model.UserLogin( entidad );

            if (res.Code == 0)            
                return RedirectToAction("Home", "Login");
            else
            {
                ViewBag.MessageScreen = res.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register( User entidad )
        {
            var res = model.UserRegister(entidad);

            if (res.Code == 0)            
                return RedirectToAction("Login", "Login");
            else
            {
                ViewBag.MessageScreen = res.Message;
                return View();
            }                
        }

        [HttpGet]
        public ActionResult RecoverAccess()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecoverAccess( User entidad )
        {
            var res = model.UserRecoverAccess(entidad);

            if (res.Code == 0)
                return RedirectToAction("Login", "Login");
            else
            {
                ViewBag.MessageScreen = res.Message;
                return View();
            }
        }

        [HttpGet]
        public ActionResult Home() 
        { 
            return View();
        }
    }
}