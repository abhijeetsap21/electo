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
        private readonly ICampaignService _CampaignService;
        private readonly ISurveyServices _SurveyServices;
        public SurveyController()
        {
            _CampaignService = new CampaignService();
            _SurveyServices = new SurveyServices();
        }
        // GET: Survey
        public ActionResult Index()
        {
            ViewBag.CampaignList = new SelectList((_CampaignService.getCompaignListByElectionIDandCreatedByID(Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()))).Select(e => new { e.campaignID, e.campaignName })), "campaignID", "campaignName");
            return View();
        }
        public ActionResult _partialsurveyList( int CampaignId)
        {
            var ActivityListLIst = _SurveyServices.GetByCampaignId(CampaignId);
            return PartialView("_partialsurveyList", ActivityListLIst);
        }
        [HttpGet]
        public ActionResult Create()
        {
           
            ViewBag.campaignID = _CampaignService.getCompaignListByElectionIDandCreatedByID(Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()))).Select(e => new { e.campaignID, e.campaignName });
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