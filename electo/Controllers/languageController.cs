using electo.Models;
using electo.Models.BaseClass;
using electo.Models.IRepositories;
using electo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace electo.Controllers
{
    [CustomErrorHandling]
    public class languageController : BaseClass
    {
        // GET: language 
        private readonly IlanguageServices _language;
       public languageController()
        {
            _language = new languageServices();
        }
        public ActionResult Index()
        {
           var _languageList= _language.getAll_LangaugeList();
            return View(_languageList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(language olanguage)
        {
            int result = 0;
            result= _language.create(olanguage);
            if (result == 1)
            {
                TempData["Result"] = "Success";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Result"] = "unsuccess";
                return View(olanguage);
            }

          
        }
    }
}