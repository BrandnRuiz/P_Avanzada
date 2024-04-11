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

        public ActionResult Login()
        {
            return View();
        } 
        
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Home() 
        { 
            return View();
        }
    }
}