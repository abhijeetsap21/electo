using electo.Models;
using electo.Models.IRepositories;
using electo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace electo.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ISurveyServices _SurveyServices;
        public SurveyController()
        {
            _SurveyServices = new SurveyServices();
        }
        // GET: Survey
        public ActionResult Index()
        {
            var SurveyList = _SurveyServices.GetByCampaignId(Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.campaignID.ToString())));
            return View(SurveyList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create(survey osurvey)
        {

            int result = 0;
            result = _SurveyServices.create(osurvey);
            if (result == 1)
            {
                TempData["Result"] = "Success";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Result"] = "unsuccess";               
                return View();
            }
        }
    }
}