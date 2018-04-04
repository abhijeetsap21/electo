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
    public class MuncipalCorporationController : BaseClass
    {
        // GET: MuncipalCorporation
       
        private readonly IDistrictServices _DistrictServices;
        private readonly IstateService _stateService;
        private readonly ImuncipalCorporationServices _muncipalCorporationServices;
        public MuncipalCorporationController()
        {
            _DistrictServices = new DistrictServices();
            _stateService = new stateService();
            _muncipalCorporationServices = new muncipalCorporationServices();
        }

        // GET: District
        public ActionResult Index()
        {
            ViewBag.States = new SelectList((_stateService.getAllStates().Select(e => new { e.stateID, e.stateName })), "stateID", "stateName");
            return View();
        }

        public ActionResult _partialMuncipalCorporationList(int stateId)
        {

            var _muncipalCorporationList = _muncipalCorporationServices.getmuncipalCorporationByStateID(stateId);
            return PartialView("_partialMuncipalCorporationList", _muncipalCorporationList);
        }

        public ActionResult getDistrictListByStateID(int stateId)
        {
            var DistrictList = _DistrictServices.getDistrictByStateID(stateId).Select(e => new { e.districtID, e.districtName });

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(DistrictList);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.stateID = _stateService.getAllStates();
            ViewBag.districtID = _DistrictServices.getDistrictByStateID(1).Select(e => new { e.districtID, e.districtName });
            return View();
        }
        [HttpPost]
        public ActionResult Create(municipalCorporationName omunicipalCorporationName)
        {
            int result = 0;
            result = _muncipalCorporationServices.create(omunicipalCorporationName);
            if (result == 1)
            {
                TempData["Result"] = "Success";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Result"] = "unsuccess";
                return View(omunicipalCorporationName);
            }

            
        }
    }
}