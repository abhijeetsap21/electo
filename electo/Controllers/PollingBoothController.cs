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
    public class PollingBoothController : BaseClass
    {
        private readonly IVSCServices _VSCServices;
        private readonly IstateService _stateService;
        private readonly ILSCServices _LSCServices;
        private readonly IElectionService _ElectionService;
        private readonly IPollingBooth _PollingBooth;
        private readonly IDistrictServices _DistrictServices;
        private readonly IwardServices _WardServices;
        private readonly IAreaService _AreaServices;
        private readonly IPollingBooth _pollingBoothService;
        public PollingBoothController()
        {
            _VSCServices = new VSCServices();
            _stateService = new stateService();
            _LSCServices = new LSCServices();
            _ElectionService = new ElectionService();
            _PollingBooth = new PollingBoothService();
            _DistrictServices = new DistrictServices();
            _WardServices = new wardServices();
            _AreaServices = new AreaService();
            _pollingBoothService = new PollingBoothService();
        }

        // GET: PollingBooth
        public ActionResult Index()
        {
            ViewBag.ElectionType = new SelectList((_ElectionService.getElectionTypes().Select(e => new { e.electionTypeID, e.electionTypeNAME })), "electionTypeID", "electionTypeNAME");
            ViewBag.States = new SelectList((_stateService.getAllStates().Select(e => new { e.stateID, e.stateName })), "stateID", "stateName");

            return View();
        }

        public ActionResult _partialPoolingBoothList(int ElectionTypeId, int stateId,int ddl_Constituency)
        {
            IEnumerable<sp_pollingBoothList_Result> PoolingBoothList;
            if (ElectionTypeId == 1)
            {
                PoolingBoothList = _PollingBooth.get_PollingBoothList(stateId, ddl_Constituency, 0 ,0);
            }
           else if (ElectionTypeId ==2)
            {
                PoolingBoothList = _PollingBooth.get_PollingBoothList(stateId, 0, ddl_Constituency,0);
            }
             else 
            {
                PoolingBoothList = _PollingBooth.get_PollingBoothList(stateId, 0,0, ddl_Constituency);
            }         
                

            return PartialView("_partialPoolingBoothLIst", PoolingBoothList);
        }


        public ActionResult getPollingBoothList(int wardID)
        {            
            var pollingBoothList = _PollingBooth.get_PollingBoothList(0,0,0, wardID).Select(e => new { e.pollingBoothID, e.pollingBoothName });
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(pollingBoothList);
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
            return View();
        }

        [HttpPost]
        public ActionResult Create(pollingBooth _pollingBooth)
        {
            pollingBooth pollingBooth_ = new pollingBooth();
            pollingBooth_.pollingBoothName = _pollingBooth.pollingBoothName;
            pollingBooth_.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            pollingBooth_.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            pollingBooth_.lokSabhaConstituencyID = _pollingBooth.lokSabhaConstituencyID;
            pollingBooth_.vidhanSabhaConstituencyID = _pollingBooth.vidhanSabhaConstituencyID;
            pollingBooth_.wardID = _pollingBooth.wardID;
            pollingBooth_.districtID = _pollingBooth.districtID;
            pollingBooth_.stateID = _pollingBooth.stateID;
            pollingBooth_.dataIsCreated = BaseUtil.GetCurrentDateTime();
            pollingBooth_.dataIsUpdated = BaseUtil.GetCurrentDateTime();
            pollingBooth_.isActive = true;
            pollingBooth_.plotNo = _pollingBooth.plotNo;
            pollingBooth_.streetNo = _pollingBooth.streetNo;
            pollingBooth_.address1 = _pollingBooth.address1;
            pollingBooth_.address2 = _pollingBooth.address2;
            pollingBooth_.pincode = _pollingBooth.pincode;
            int result =  _pollingBoothService.createPollingBooth(pollingBooth_);          

            if (result == 1)
            {
                TempData["Result"] = "Success";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Result"] = "unsuccess";
                return View(pollingBooth_);
            }
        }
    }
}