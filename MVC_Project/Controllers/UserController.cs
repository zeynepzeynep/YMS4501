using MVC_Project.ActionFilter;
using MVC_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Project.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create(bool? result)
        {
            if (result.HasValue)
            {
                if (result.Value == true)
                    ViewBag.Result = new string[] { "TC Kimlik No Doğrulanmıştır.", "alert-success" };
                else
                    ViewBag.Result = new string[] { "TC Kimlik No Geçerli Değildir.", "alert-danger" };
            }

            return View();
        }

        [
            HttpPost,
            CheckUser
        ]
        public ActionResult Create(User a)
        {
            return View();
        }
    }
}