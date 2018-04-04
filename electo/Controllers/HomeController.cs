using electo.Models.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NewLetter.Controllers
{
    public class HomeController : BaseClass
    {
      
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult General(int id)
        {
            return View();
        }
        public ActionResult AccessDenied()
        {
            ViewBag.Message = "AccessDenied";
            ViewBag.Title = "Access Denied";
            ViewBag.Icon = "glyphicon glyphicon-warning-sign";
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        

	}
}