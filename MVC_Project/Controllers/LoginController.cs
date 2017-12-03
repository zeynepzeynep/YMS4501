using MVC_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Project.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(User user)
        {
            if (user.UserName != "" && user.Password != "")
            {
                HttpContext.Session.Add("login", user);
                return RedirectToAction("About", "Home");
            }
            return View("Index");
        }

        public ActionResult Cikis()
        {
            Session.Abandon();
            return View("Index");
        }
    }
}