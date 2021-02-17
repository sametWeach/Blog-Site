using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.ayarlar
{
    public class _securityFilter:ActionFilterAttribute
    {
        
       
        
                public override void OnActionExecuting(ActionExecutingContext filterContext)
                {
                   string contollerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                    if (HttpContext.Current.Session["Kullanici"]==null && contollerName !="Login")
                   {
                       filterContext.Result = new RedirectResult("/Login/Index");
                       return;

                    }
                   base.OnActionExecuting(filterContext);
                }
            
        
    }
}