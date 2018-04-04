using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace electo.Models.BaseClass
{
    public class BaseClass : Controller
    {
     
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            String ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToUpper();
            String ActionName = filterContext.ActionDescriptor.ActionName.ToUpper();
            String Action = string.Format("{0}Controller{1}", ControllerName, ActionName).ToUpper();

            if (BaseUtil.ListControllerExcluded().Contains(ControllerName))
            {
                if ((ControllerName == "ACCOUNT" && (ActionName == "LOGIN" || ActionName == "LOGOUT" || ActionName == "FORGOTPASSWORD" || ActionName== "RESETPASSWORD")) 
                    || (ControllerName == "ENQUIRIES" && (ActionName =="CREATE"))
                    || (ControllerName == "HOME" && (ActionName == "ACCESSDENIED")))
                    {
                        return;
                    }
            if (BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()) == "")
                {
                    filterContext.Result = null;
                    filterContext.Result = new RedirectResult("/Account/login");
                    return;
                }
                if (!BaseUtil.CheckAuthentication(filterContext))
                {
                    filterContext.Result = null;
                    filterContext.Result = new RedirectResult("/Home/AccessDenied");
                    return;
                }

                return;
            }

            else
            {
                if (BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()) == "")
                {
                    filterContext.Result = null;
                    filterContext.Result = new RedirectResult("/Account/login");
                    return;
                }
                if (!BaseUtil.CheckAuthentication(filterContext))
                {
                    filterContext.Result = null;
                    filterContext.Result = new RedirectResult("/Home/AccessDenied");
                    return;
                }

                return;
            }
        }

    }
        
}