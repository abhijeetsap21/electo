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


        private readonly IEventServices _eventServices;
        private readonly IEventTypeService _EventTypeService;
        public CampaignActivityController()
        {
            _EventTypeService = new EventTypeService();
            _eventServices = new EventServices();
        }




        // GET: CampaignActivity
        public ActionResult Index()
        {
            ViewBag.eventTypeID = new SelectList((_EventTypeService.GetEventTypeList().Select(e => new { e.eventTypeID, e.eventName })), "eventTypeID", "eventName");
            return View();
        }

        public ActionResult _partialActivityList( int eventTypeID)
        {
            int CampaignId= Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.campaignID.ToString()));
            var ActivityListLIst = _eventServices.GetByCampaignIdANDEventTypeID(CampaignId, eventTypeID);
            return PartialView("_partialActivityList", ActivityListLIst);
        }
    }
}