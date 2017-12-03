using MVC_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Project.ActionFilter
{
    public class CheckUser:ActionFilterAttribute
    {
        public static bool actionResult { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            TCKimlikDogrulama.KPSPublicSoapClient service = new TCKimlikDogrulama.KPSPublicSoapClient();

            User user = filterContext.ActionParameters["a"] as User;
            bool result = false;
            try
            {
                result = service.TCKimlikNoDogrula(
                    long.Parse(user.TCKN),
                    user.FirstName.ToUpper(),
                    user.LastName.ToUpper(),
                    int.Parse(user.BirthYear)
                    );
            }
            catch
            {
                result = false;
            }

            filterContext.Result = new RedirectResult("/User/Create/" + result);
        }
    }
}