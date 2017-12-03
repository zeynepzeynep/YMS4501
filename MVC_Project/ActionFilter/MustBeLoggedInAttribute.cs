using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Project.ActionFilter
{
    public class MustBeLoggedInAttribute:ActionFilterAttribute
    {
        public string Role { get; set; }

        public MustBeLoggedInAttribute(string _role)
        {
            Role = _role;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if(filterContext.HttpContext.Session["login"]==null && Role == "Admin")
            {
                filterContext.Result = new RedirectResult("/Login");
            }
        }
    }
}