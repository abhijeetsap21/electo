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
    public class WardController : BaseClass
    {
        // GET: Ward
        private readonly IwardServices wardConstituency_;
        private readonly IstateService _stateService;
        private readonly ImuncipalCorporationServices _muncipalCorporationServices;
        private readonly IzoneServices _zoneServices;
        private readonly IDistrictServices _DistrictServices;
        private readonly IVSCServices VSCServices_;

        public WardController()
        {
            wardConstituency_ = new wardServices();
            _stateService = new stateService();
              _muncipalCorporationServices = new muncipalCorporationServices();
            _DistrictServices = new DistrictServices();
            _zoneServices = new zoneServices();
            VSCServices_ = new VSCServices();
        }

        public ActionResult Index()
        {
            ViewBag.States = new SelectList((_stateService.getAllStates().Select(e => new { e.stateID, e.stateName })), "stateID", "stateName");            
            return View();
        }

        public ActionResult _partialWardList(int stateId, int MPCorporation, int districtID)
        {
            var wardList = wardConstituency_.getZoneByStateIDAndMUncipalCorporationID(stateId, MPCorporation, districtID,0);
            return PartialView("_partialWardList", wardList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.stateID = _stateService.getAllStates().Select(e => new { e.stateID, e.stateName });
            ViewBag.municipalCorporationID = _muncipalCorporationServices.getmuncipalCorporationByStateID(1).Select(e => new { e.municipalCorporationID, e.municipalCorporationName1 });
            ViewBag.districtID = _DistrictServices.getDistrictByStateID(1).Select(e => new { e.districtID, e.districtName });
            ViewBag.zoneID = _zoneServices.getZoneByStateIDAndMUncipalCorporationID(1,1).Select(e => new { e.zoneID, e.zoneName });
            ViewBag.vidhanSabhaConstituencyID = VSCServices_.getvidhanSabhaConstituencyByStateID(1).Select(e => new { e.vidhanSabhaConstituencyID, e.vidhanSabhaConstituencyName });
            return View();
        }

        [HttpPost]
        public ActionResult Create(wardConstituency owardConstituency)
        {
            bool result = false;
            owardConstituency.dataIsCreated = BaseUtil.GetCurrentDateTime();
            owardConstituency.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            owardConstituency.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            owardConstituency.dataIsUpdated = BaseUtil.GetCurrentDateTime();

            if (ModelState.IsValid)
            {
                result = wardConstituency_.CreateWardConstituency(owardConstituency);
            }
            if (result)
            {
                TempData["Result"] = "Success";
                return RedirectToAction("Index");
            }
            ViewBag.stateID = _stateService.getAllStates().Select(e => new { e.stateID, e.stateName });
            ViewBag.municipalCorporationID = _muncipalCorporationServices.getmuncipalCorporationByStateID(1).Select(e => new { e.municipalCorporationID, e.municipalCorporationName1 });
            ViewBag.districtID = _DistrictServices.getDistrictByStateID(1).Select(e => new { e.districtID, e.districtName });
            TempData["Result"] = "unsuccess";
            return View(owardConstituency);
        }

        public ActionResult getWardByStateIDAndMUncipalCorporationID(int stateId, int MPCorporation, int districtID, int vidhanSabhaConstituencyID)
        {
            var DistrictList = wardConstituency_.getZoneByStateIDAndMUncipalCorporationID(stateId, MPCorporation, districtID, vidhanSabhaConstituencyID).Select(e => new { e.wardID, e.wardName });
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(DistrictList);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        

    }
}