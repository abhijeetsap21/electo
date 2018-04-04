using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using electo.Models.ViewModels;
using electo.Models.Repositories;
using electo.Models;
using electo.Models.BaseClass;

namespace electo.Controllers
{
    [CustomErrorHandling]
    public class dashboardController : BaseClass
    {
        // GET: dashboard
        private DashBoardServices _objectDashBoardServices = new DashBoardServices();
        public ActionResult Dashboard()
        {
            DashBoardViewModels _objectDashBoardViewModels = new DashBoardViewModels();
            _objectDashBoardViewModels.newCampaignRequests = _objectDashBoardServices.GetNewCampaignRequests_Result();
            _objectDashBoardViewModels.getUpcomingElections = _objectDashBoardServices.GetUpcomingElections_Result();
            _objectDashBoardViewModels.getRunningCampaigns = _objectDashBoardServices.GetRunningCampaigns_Result();
            _objectDashBoardViewModels.getNewEnquiries = _objectDashBoardServices.GetNewEnquiries_Result();


            var newCampaignCount = _objectDashBoardViewModels.newCampaignRequests.Count();
            var upComingElectionCount = _objectDashBoardViewModels.getUpcomingElections.Count();
            var runningCampaignCount= _objectDashBoardViewModels.getRunningCampaigns.Count();
            var newEnquiriesCount = _objectDashBoardViewModels.getNewEnquiries.Count();

            ViewBag.newCampaignCount = newCampaignCount;
            ViewBag.upComingElectionCount = upComingElectionCount;
            ViewBag.runningCampaignCount = runningCampaignCount;
            ViewBag.newEnquiriesCount = newEnquiriesCount;

            return View(_objectDashBoardViewModels);
        }
    }
}