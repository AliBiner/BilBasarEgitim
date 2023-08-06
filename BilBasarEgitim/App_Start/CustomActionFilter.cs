using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilBasarEgitim.App_Start
{
    public class CustomActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Oturum süresi dolmuş mu kontrol ediyoruz.
            if (filterContext.HttpContext.Session != null && filterContext.HttpContext.Session["Email"] == null)
            {
                // Kullanıcı oturumu yok veya süresi dolmuş, login sayfasına yönlendir.
                filterContext.Result = new RedirectToRouteResult(new
                    System.Web.Routing.RouteValueDictionary(new { controller = "Admin", action = "Login" }));
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}