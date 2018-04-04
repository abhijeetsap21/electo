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
    public class zoneController : BaseClass
    {

       
        private readonly IstateService _stateService;      
        private readonly ImuncipalCorporationServices _muncipalCorporationServices;
        private readonly IzoneServices _zoneServices;
        private readonly IDistrictServices _DistrictServices;
        public zoneController()
        {
            _zoneServices = new zoneServices();
             _stateService = new stateService();
            _muncipalCorporationServices = new muncipalCorporationServices();
            _DistrictServices = new DistrictServices();
        }


        // GET: zone
        public ActionResult Index()
        {
            ViewBag.States = new SelectList((_stateService.getAllStates().Select(e => new { e.stateID, e.stateName })), "stateID", "stateName");
           
            return View();
        }

        public ActionResult getMuncipalCorporationListByStateID(int stateId)
        {
           var muncipalList = _muncipalCorporationServices.getmuncipalCorporationByStateID(stateId).Select(e => new { e.municipalCorporationID, e.municipalCorporationName1 });

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(muncipalList);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getDistrictListByStateID(int stateId)
        {
            var districtList = _DistrictServices.getDistrictByStateID(stateId).Select(e => new { e.districtID, e.districtName });

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(districtList);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getZoneListBymuncipalCorpID(int stateId, int MPCorporation)
        {
            var ZoneList = _zoneServices.getZoneByStateIDAndMUncipalCorporationID(stateId, MPCorporation).Select(e => new { e.zoneID, e.zoneName });

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(ZoneList);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult _partialZoneList(int stateId, int MPCorporation)
        {
            var ZoneList = _zoneServices.getZoneByStateIDAndMUncipalCorporationID(stateId, MPCorporation);
            return PartialView("_partialZoneList", ZoneList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.stateID = _stateService.getAllStates().Select(e => new { e.stateID, e.stateName });
            ViewBag.municipalCorporationID = _muncipalCorporationServices.getmuncipalCorporationByStateID(1).Select(e => new { e.municipalCorporationID, e.municipalCorporationName1 });
            ViewBag.districtID = _DistrictServices.getDistrictByStateID(1).Select(e => new { e.districtID, e.districtName });
            return View();
        }
        [HttpPost]
        public ActionResult Create(zoneMunicipality ozoneMunicipality)
        {
            bool result = false;
            ozoneMunicipality.dataIsCreated = BaseUtil.GetCurrentDateTime();
            ozoneMunicipality.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            ozoneMunicipality.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            ozoneMunicipality.dataIsUpdatd = BaseUtil.GetCurrentDateTime();          

            if (ModelState.IsValid)
            {
                result = _zoneServices.CreateVidhanSabha(ozoneMunicipality);
            }
            if (result)
            {
                TempData["Result"] = "Success";
                return RedirectToAction("Index");
            }
            ViewBag.stateID = _stateService.getAllStates().Select(e => new { e.stateID, e.stateName });
            ViewBag.municipalCorporationID = _muncipalCorporationServices.getmuncipalCorporationByStateID(1).Select(e => new { e.municipalCorporationID, e.municipalCorporationName1 });
            TempData["Result"] = "unuccess";
            return View();
        }


    }
}