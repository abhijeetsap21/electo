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
    public class LokSabhaController : BaseClass
    {
        private readonly ILSCServices _ILSCServices;
        private readonly IstateService _stateService;
        private readonly IDistrictServices _DistrictServices;
        public LokSabhaController()
        {
            _ILSCServices = new LSCServices();
             _stateService = new stateService();
            _DistrictServices = new DistrictServices();
        }

        // GET: District
        public ActionResult Index()
        {
            ViewBag.States = new SelectList((_stateService.getAllStates().Select(e => new { e.stateID, e.stateName })), "stateID", "stateName");
            return View();
        }

        public ActionResult _partialLoKSabhaList(int stateId)
        {

            var ILSC_List = _ILSCServices.getAlllokSabhaConstituencyConstituency(stateId);
            return PartialView("_partialLoKSabhaList", ILSC_List);
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
            ViewBag.districtID = _DistrictServices.getDistrictByStateID(1).Select(e => new { e.districtID, e.districtName });
            ViewBag.stateID = _stateService.getAllStates();
            return View();
        }
        [HttpPost]
        public ActionResult Create(lokSabhaConstituency olokSabhaConstituency)
        {
            int result = 0;
            result = _ILSCServices.create(olokSabhaConstituency);
            if (result == 1)
            {
                TempData["Result"] = "Success";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Result"] = "unsuccess";
                return View(olokSabhaConstituency);
            }
            
        }
    }
}