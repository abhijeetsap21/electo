using electo.Models;
using electo.Models.BaseClass;
using electo.Models.IRepositories;
using electo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace electo.Controllers
{
    [CustomErrorHandling]
    public class AreaController : BaseClass
    {
        private readonly IAreaService _AreaServices;
        private readonly IstateService _stateService;
        private readonly IElectionService _ElectionService;
        private readonly IVSCServices _VSCServices;
        private readonly IDistrictServices _DistrictServices;
        private readonly ILSCServices _LSCServices;
        private readonly IwardServices _WardServices;
        private readonly IPollingBooth _PollingBoothService;
       
        private readonly ImuncipalCorporationServices _mncipalCorp;
       public AreaController()
        {
            _AreaServices = new AreaService();
            _stateService = new stateService();
            _ElectionService = new ElectionService();
            _VSCServices = new VSCServices();
            _DistrictServices = new DistrictServices();
            _LSCServices = new LSCServices();
            _WardServices = new wardServices();            
            _mncipalCorp = new muncipalCorporationServices();
            _PollingBoothService = new PollingBoothService();
        }

        public ActionResult GetConstituency(int stateId, int ElectionTypeId) {
            string result = string.Empty;
            if (ElectionTypeId == 2)
            {
                var lstConstituency = _VSCServices.getvidhanSabhaConstituencyByStateID(stateId).Select(e => new { e.vidhanSabhaConstituencyID, e.vidhanSabhaConstituencyName });

                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                 result = javaScriptSerializer.Serialize(lstConstituency);
            }
            if (ElectionTypeId == 1)
            {
                var lstConstituency = _LSCServices.getAlllokSabhaConstituencyConstituency(stateId).Select(e => new { e.lokSabhaConstituencyID, e.lokSabhaConstituencyName });

                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                result = javaScriptSerializer.Serialize(lstConstituency);
            }

            if (ElectionTypeId == 3)
            {
                var lstConstituency = _mncipalCorp.getmuncipalCorporationByStateID(stateId).Select(e => new { e.municipalCorporationID, e.municipalCorporationName1 });

                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                result = javaScriptSerializer.Serialize(lstConstituency);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // GET: Area
        public ActionResult Index()
        {
            ViewBag.ElectionType = new SelectList((_ElectionService.getElectionTypes().Select(e => new { e.electionTypeID, e.electionTypeNAME })), "electionTypeID", "electionTypeNAME");
            ViewBag.States = new SelectList((_stateService.getAllStates().Select(e => new { e.stateID, e.stateName })), "stateID", "stateName");

            return View();
        }

        public ActionResult _partialAreaLIst(int ElectionTypeId, int stateId, int ddl_Constituency)
        {
            var AreaLIst = _AreaServices.getAll_areaList(ElectionTypeId,stateId,ddl_Constituency);
            return PartialView("_PartialAreaList", AreaLIst);
        }

        public ActionResult getAll_areaList( Int64 wardID)
        {
            var _AreaList = _AreaServices.GetAll().Where(e=>e.wardID== wardID).Select(e => new { e.areaID, e.areaName });

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            var result = javaScriptSerializer.Serialize(_AreaList);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.stateID = _stateService.getAllStates().Select(e => new { e.stateID, e.stateName });
            ViewBag.lokSabhaConstituencyID = _LSCServices.getAlllokSabhaConstituencyConstituency(1).Select(e => new { e.lokSabhaConstituencyID, e.lokSabhaConstituencyName });
            ViewBag.vidhanSabhaConstituencyID = _VSCServices.getvidhanSabhaConstituencyByStateID(1).Select(e => new { e.vidhanSabhaConstituencyID, e.vidhanSabhaConstituencyName });
            ViewBag.districtID = _DistrictServices.getDistrictByStateID(1).Select(e => new { e.districtID, e.districtName });
            ViewBag.wardID = _WardServices.getZoneByStateIDAndMUncipalCorporationID(1, 1, 0,0).Select(e => new { e.wardID, e.wardName });
            ViewBag.electionID = _ElectionService.getAllElections().Select(e => new { e.electionID , e.electionName1});
            ViewBag.pollingBoothID = _PollingBoothService.get_PollingBoothList(0,0,0,2).Select(e => new { e.pollingBoothID, e.pollingBoothName });

            return View("Create");
        }

        [HttpPost]
        public ActionResult Create (areaName _areaName)
        {
            areaName areaName_ = new areaName();
            areaName_.areaName1 = _areaName.areaName1;
            areaName_.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString())); 
            areaName_.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            areaName_.lokSabhaConstituencyID = _areaName.lokSabhaConstituencyID;
            areaName_.vidhanSabhaConstituencyID = _areaName.vidhanSabhaConstituencyID;
            areaName_.wardID = _areaName.wardID;
            areaName_.districtID = _areaName.districtID;
            areaName_.stateID = _areaName.stateID;
            areaName_.dataIsCreated = BaseUtil.GetCurrentDateTime();
            areaName_.dataIsUpdated = BaseUtil.GetCurrentDateTime();
            areaName_.isActive = true;          
            areaName_.pollingBoothID = _areaName.pollingBoothID;
            int  result = _AreaServices.createArea(areaName_);
            if (result == 1)
            {
                TempData["Creation"] = "Success";
                return RedirectToAction("Index");
            }
            ViewBag.stateID = _stateService.getAllStates().Select(e => new { e.stateID, e.stateName });
            ViewBag.lokSabhaConstituencyID = _LSCServices.getAlllokSabhaConstituencyConstituency(1).Select(e => new { e.lokSabhaConstituencyID, e.lokSabhaConstituencyName });
            ViewBag.vidhanSabhaConstituencyID = _VSCServices.getvidhanSabhaConstituencyByStateID(1).Select(e => new { e.vidhanSabhaConstituencyID, e.vidhanSabhaConstituencyName });
            ViewBag.districtID = _DistrictServices.getDistrictByStateID(1).Select(e => new { e.districtID, e.districtName });
            ViewBag.wardID = _WardServices.getZoneByStateIDAndMUncipalCorporationID(1, 1, 0,0).Select(e => new { e.wardID, e.wardName });
            TempData["Creation"] = "unsuccess";
            return View(_areaName);
        }
    
    }
}