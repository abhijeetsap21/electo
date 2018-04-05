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
    public class CampaignActivityController : Controller
    {

        private readonly ICampaignService _CampaignService;
        private readonly IEventServices _eventServices;
        private readonly IEventTypeService _EventTypeService;
        public CampaignActivityController()
        {
            _CampaignService = new CampaignService();
            _EventTypeService = new EventTypeService();
            _eventServices = new EventServices();
        }

                // GET: CampaignActivity
        public ActionResult Index()
        {
            ViewBag.CampaignList = new SelectList((_CampaignService.getCompaignListByElectionIDandCreatedByID(Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()))).Select(e => new { e.campaignID, e.campaignName })),"campaignID","campaignName");
            ViewBag.eventTypeID = new SelectList((_EventTypeService.GetEventTypeList().Select(e => new { e.eventTypeID, e.eventName })), "eventTypeID", "eventName");
            return View();
        }

        public ActionResult _partialActivityList( int eventTypeID ,int CampaignId)
        {
           
            var ActivityListLIst = _eventServices.GetByCampaignIdANDEventTypeID(CampaignId, eventTypeID);
            return PartialView("_partialActivityList", ActivityListLIst);
        }
    }
}