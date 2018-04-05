using electo.Models.IRepositories;
using electo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using electo.Models.SP_Models;
using static electo.Models.SP_Models.StoredProcedureModels;
using electo.Models;
using electo.Models.BaseClass;

namespace electo.Controllers
{
    [CustomErrorHandling]
    public class RunningCampaignController : BaseClass
    {
        // GET: RunningCampaign
        private readonly IElectionService _ElectionService;
        private CampaignService cmpSer = new CampaignService();
        private readonly IstateService _stateService;
        private readonly IPoliticalPartyService _PoliticalPartyService;
        private readonly ILSCServices _LSCServices;
        private readonly IVSCServices _VSCServices;
        private readonly IwardServices _WardServices;
        private readonly IPollingBooth _PollingBoothService;
        private readonly IAccountServices _AccountServices;
        public RunningCampaignController()
        {
            _ElectionService = new ElectionService();
            _stateService = new stateService();
            _PoliticalPartyService = new PoliticalPartyService();
            _LSCServices = new LSCServices();
            _VSCServices = new VSCServices();
            _WardServices = new wardServices();
            _PollingBoothService = new PollingBoothService();
            _AccountServices = new AccountServices();
        }

        public ActionResult RunningCampaigns()
        {
            ViewBag.ElectionType = new SelectList((_ElectionService.getElectionTypes().Select(e => new { e.electionTypeID, e.electionTypeNAME })), "electionTypeID", "electionTypeNAME");
            ViewBag.PoliticalParties = new SelectList((_AccountServices.getAllPoliticalParty().Select(e => new { e.politicalPartyID, e.politicalPartyName })), "politicalPartyID", "politicalPartyName");
            return View();
        }

       
        public JsonResult getCampaignNames(string prefix)
        {
            var names = cmpSer.getCampaignNames(prefix).Select(e=> new { e.campaignName }).Take(10);
           string result = Newtonsoft.Json.JsonConvert.SerializeObject(names);
            return Json(names, JsonRequestBehavior.AllowGet);
        }

        public ActionResult _partialRunningCampaigns(string electionTypeNAME, string electionYear, string politicalPartyName, string campaignName)
        {
            return PartialView("_partialRunningCampaigns", cmpSer.SearchRunningCampaigns_Result(electionTypeNAME, electionYear, politicalPartyName, campaignName));
        }
        [HttpGet]
        public ActionResult _partialActivateDeactiveateCampaign(long cID)
        {
            cmpSer.get(cID);
            return PartialView("_partialActivateDeactiveateCampaign", cmpSer.get(cID));
        }

        [HttpPost]
        public ActionResult _partialActivateDeactiveateCampaign(campaign _cmp)
        {
            cmpSer._save(_cmp);
            TempData["Result"] = "Success";
            return RedirectToAction("RunningCampaigns", "RunningCampaign");
        }
        [HttpGet]
        public ActionResult CampaignPriceList()

        {
            ViewBag.ElectionType = new SelectList((_ElectionService.getElectionTypes().Select(e => new { e.electionTypeID, e.electionTypeNAME })), "electionTypeID", "electionTypeNAME");
            return View();
        }

        public ActionResult _partialCampaignPrices(string electionTypeNAME, string year, bool isActive)
        {
            return PartialView("_partialCampaignPrices", cmpSer.sp_SearchCampaignPrices_Result(electionTypeNAME, year, isActive));
        }

   

        [HttpGet]
        public ActionResult _partialNewPrice()
        {
            campaignPrice _cmpPrice = new campaignPrice();
            //ViewBag.ElectionType = new SelectList((_ElectionService.getElectionTypes().Select(e => new { e.electionTypeID, e.electionTypeNAME })), "electionTypeID", "electionTypeNAME");
            ViewBag.electionTypeID = _ElectionService.getElectionTypes();
            return PartialView("_partialNewPrice", _cmpPrice);
        }
        [HttpPost]
        public ActionResult NewPrice(campaignPrice _newCmpPrice)
        {
            campaignPrice newCmpPrice_ = new campaignPrice();
            newCmpPrice_.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            newCmpPrice_.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            newCmpPrice_.dataIsCreated = BaseUtil.GetCurrentDateTime();
            newCmpPrice_.dataIsUpdated = BaseUtil.GetCurrentDateTime();
            newCmpPrice_.electionTypeID = _newCmpPrice.electionTypeID;
            newCmpPrice_.isActive = _newCmpPrice.isActive;
            newCmpPrice_.price = _newCmpPrice.price;
            newCmpPrice_.year = _newCmpPrice.year;

            int addResult = 0;

            addResult = cmpSer.createCampaignPrice(newCmpPrice_);
            TempData["Result"] = "Edited";
            return RedirectToAction("CampaignPriceList", "RunningCampaign");

        }


        [HttpGet]
        public ActionResult CreateCampaign()
        {
            ViewBag.electionTypeID = _ElectionService.getElectionTypes();
            ViewBag.electionID = _ElectionService.getAllElections();
            ViewBag.stateID = _stateService.getAllStates().Select(e => new { e.stateID, e.stateName });
            ViewBag.lokSabhaConstituencyID = _LSCServices.getAlllokSabhaConstituencyConstituency(1).Select(e => new { e.lokSabhaConstituencyID, e.lokSabhaConstituencyName });
            ViewBag.vidhanSabhaConstituencyID = _VSCServices.getvidhanSabhaConstituencyByStateID(1).Select(e => new { e.vidhanSabhaConstituencyID, e.vidhanSabhaConstituencyName });
            ViewBag.wardID = _WardServices.getZoneByStateIDAndMUncipalCorporationID(1, 1, 0,0).Select(e => new { e.wardID, e.wardName });
            //ViewBag.politicalparty = _PoliticalPartyService.getAll_PoliticalPartyListByStateID(1, "");
            return View();
        }

        [HttpPost]
        public ActionResult CreateCampaign(campaign _campaign)
        {
            _campaign.campaignName = _campaign.campaignName;
            _campaign.electionTypeID = _campaign.electionTypeID;
            _campaign.electionID = _campaign.electionID;
            _campaign.politicalPartyID = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.politicalPartyID.ToString()));
            if (_campaign.electionTypeID == 1)
            {
                _campaign.lokSabhaConstituencyID = _campaign.lokSabhaConstituencyID;
                _campaign.vidhanSabhaConstituencyID = null;
                _campaign.wardID = null;
            }
            if (_campaign.electionTypeID == 2)
            {
                _campaign.lokSabhaConstituencyID = null;
                _campaign.vidhanSabhaConstituencyID = _campaign.vidhanSabhaConstituencyID;
                _campaign.wardID = null;
            }
            _campaign.volunteerID = Convert.ToUInt32(BaseUtil.GetSessionValue(AdminInfo.volunteerID.ToString())); 
            _campaign.dataIsCreated = BaseUtil.GetCurrentDateTime();
            _campaign.dataIsUpdated = BaseUtil.GetCurrentDateTime();
            _campaign.isActive = true;
            _campaign.isOLD = false;
            _campaign.isPaymentComplete = false;
            _campaign.createdBy = Convert.ToUInt32(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            _campaign.modifiedBy = Convert.ToUInt32(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            _campaign.price = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    cmpSer.createCampaign(_campaign);
                    TempData["result"] = "Success";
                }
            }
            catch (Exception e)
            {
                TempData["result"] = e.Message;
            }
            return RedirectToAction("CreateCampaign", "RunningCampaign");
        }

        [HttpGet]
        public ActionResult MyCampaigns()
        {
            IEnumerable<campaign> _cmp;
            _cmp = cmpSer.getMyCampaigns(Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.volunteerID.ToString()))).ToList();
            return View(_cmp);
        }

        [HttpGet]
        public ActionResult AssignVolunteers(int ?cmpID)
        {       if (cmpID != null)
                {
                var c = cmpSer.get((Int32)cmpID);
                if (c != null)
                {
                    ViewBag.campaignName = ((campaign)c).campaignName;
                }
                else
                {
                    ViewBag.campaignName = "";
                        }
                }
          
            ViewBag.stateID = _stateService.getAllStates().Select(e => new { e.stateID, e.stateName });
            ViewBag.lokSabhaConstituencyID = _LSCServices.getAlllokSabhaConstituencyConstituency(1).Select(e => new { e.lokSabhaConstituencyID, e.lokSabhaConstituencyName });
            ViewBag.vidhanSabhaConstituencyID = _VSCServices.getvidhanSabhaConstituencyByStateID(1).Select(e => new { e.vidhanSabhaConstituencyID, e.vidhanSabhaConstituencyName });
            return View();
        }

        [HttpPost]
        public ActionResult _partialAssign(string cmpID, string stateID, string lkID, string vsID)
        {
            string pID = BaseUtil.GetSessionValue(AdminInfo.politicalPartyID.ToString());
            ViewBag.usertypes = cmpSer.get().Select(e => new { e.userTypeID, e.userTypeName }).OrderByDescending(e => e.userTypeID).Take(3);
            var result = cmpSer.getVolunteers(cmpID,pID, stateID, lkID, vsID);
            TempData["cID"] = cmpID;
            return PartialView(result);
        }

        [HttpPost]
        public string assignVolunteer(string usertype, string vID, string cID)
        {
            string result = "Error";


            if (cmpSer.createVolunteerRelationship(usertype, vID, cID) == 1) {
                result = "Success";
            }          
            return result;
        }

        
        public ActionResult _partialAssignAreaPageIncharge(string usertype, string vID, string cID, string voterName)
        {
            ViewBag.areaList = cmpSer.getAreaListByCampignID(Convert.ToInt32(cID)).Select(e => new { e.areaID, e.areaName });
            PageInchargeAssignAreaviewmodel _assigarea = new PageInchargeAssignAreaviewmodel();
            _assigarea.volunteerID = Convert.ToInt32(vID);
            _assigarea.campaignID = Convert.ToInt32(cID);  
            _assigarea.voterName= voterName;
            return PartialView("_partialAssignAreaPageIncharge", _assigarea);
        }
       
        public ActionResult AssignAreaPageIncharge(PageInchargeAssignAreaviewmodel _obj)
        {
            int result = 0;

            result = cmpSer.assignPageInchargeArea(_obj);
            if (result == 1)
            {
                TempData["Creation"] = "Success";
                return RedirectToAction("AssignVolunteers", new { cmpID = _obj.campaignID });
            }
            TempData["Creation"] = "unsuccess";
            return View(_obj);
        }

        [HttpGet]
        public ActionResult _partialAssignPollingBooth(Int64 cID, Int64 vID, string voterName)
        {
            AssignPollingBoothToPollingBoothIncharge oAssignPollingBoothToPollingBoothIncharge = new AssignPollingBoothToPollingBoothIncharge();
            oAssignPollingBoothToPollingBoothIncharge.voluntearID = vID;
            oAssignPollingBoothToPollingBoothIncharge.campaignid = cID;
            oAssignPollingBoothToPollingBoothIncharge.voterName = voterName;
            ViewBag.pollingBoothID_ = _PollingBoothService.get_PollingBoothListByCampaignID(cID).Select(e => new { e.pollingBoothID, e.pollingBoothName, e.address });
            return PartialView("_partialAssignPollingBooth", oAssignPollingBoothToPollingBoothIncharge);

        }
        [HttpPost]
        public ActionResult _partialAssignPollingBooth(AssignPollingBoothToPollingBoothIncharge oAssignPollingBoothToPollingBoothIncharge)
        {
            int result = 0;
            result= _PollingBoothService.AssignPollingBoothToAssignPollingBoothIncharge(oAssignPollingBoothToPollingBoothIncharge);
            if (result == 1)
            {
                TempData["Creation"] = "Success";
                return RedirectToAction("AssignVolunteers", new { cmpID = oAssignPollingBoothToPollingBoothIncharge.campaignid });
            }
            TempData["Creation"] = "unsuccess";
            return View(oAssignPollingBoothToPollingBoothIncharge);
        }

        [HttpPost]
        public int DeletecampaignVolunteerRelationShip(Int64 cID, Int64 vID)
        {
            int result = 0;
            result = cmpSer.DeletecampaignVolunteerRelationShip(cID,vID);

            return result;
        }

        [HttpGet]
        public ActionResult PresentRelationships(int ?cmpID)
        {
            if (cmpID != null)
            {
                var c = cmpSer.get((Int32)cmpID);
                if (c != null)
                {
                    ViewBag.campaignName = ((campaign)c).campaignName;
                }
                else
                {
                    ViewBag.campaignName = "";
                }
            }
            ViewBag.usertypes = cmpSer.get().Select(e => new { e.userTypeID, e.userTypeName }).OrderByDescending(e=>e.userTypeID).Take(3);
            ViewBag.campaignID = cmpID;
            return View();
        }

        [HttpPost]
        public ActionResult PresentRelationships(string cmpID,string userTypeID)
        {
            var result = cmpSer.getAllRelationshipsInCampaignByUserType(cmpID, userTypeID);
            return PartialView("_partialViewAllRelationships", result);
        }
    }
}