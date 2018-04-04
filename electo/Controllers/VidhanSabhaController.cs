using electo.Models;
using electo.Models.BaseClass;
using electo.Models.IRepositories;
using electo.Models.Repositories;
using electo.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace electo.Controllers
{
    [CustomErrorHandling]
    public class VidhanSabhaController : BaseClass
    {

        private readonly IVSCServices _VSCServices;
        private readonly IstateService _stateService;
        private readonly ILSCServices _LSCServices;
        private readonly IDistrictServices _DistrictServices;
        public VidhanSabhaController()
        {
            _VSCServices = new VSCServices();
            _stateService = new stateService();
            _LSCServices = new LSCServices();
            _DistrictServices = new DistrictServices();
        }

        // GET: VidhanSabha
        public ActionResult Index()
        {
            ViewBag.States = new SelectList((_stateService.getAllStates().Select(e => new { e.stateID, e.stateName })), "stateID", "stateName");
            return View();
        }


        public ActionResult GetLOCKSABHAConstituencyLsit(int stateId)
        {
            var lstConstituency = _LSCServices.getAlllokSabhaConstituencyConstituency(stateId).Select(e => new { e.lokSabhaConstituencyID, e.lokSabhaConstituencyName });

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(lstConstituency);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getDistrictListByStateID(int stateId)
        {
            var DistrictList = _DistrictServices.getDistrictByStateID(stateId).Select(e => new { e.districtID, e.districtName });

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(DistrictList);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getvidhanSabhaConstituencyByStateID(int stateId)
        {
            var DistrictList = _VSCServices.getvidhanSabhaConstituencyByStateID(stateId).Select(e => new { e.vidhanSabhaConstituencyID, e.vidhanSabhaConstituencyName });

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(DistrictList);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult _partialVidhanSabhaList(int stateId, int LSCID, string VSC_NAME)
        {
            var vidhanSabha = _VSCServices.getvidhanSabhaConstituencyByStateIDANDLKSCID(stateId, LSCID, VSC_NAME);
            return PartialView("_partialVidhanSabhaList", vidhanSabha);
        }

        public ActionResult getvidhanSabhaConstituencyByStateIDANDLKSCID(int stateId, int LSCID)
        {
            var vidhanSabha = _VSCServices.getvidhanSabhaConstituencyByStateIDANDLKSCID(stateId,LSCID,"").Select(e => new { e.vidhanSabhaConstituencyID, e.vidhanSabhaConstituencyName });

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(vidhanSabha);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.stateID = _stateService.getAllStates().Select(e => new { e.stateID, e.stateName });
            ViewBag.districtID = _DistrictServices.getDistrictByStateID(1).Select(e => new { e.districtID, e.districtName });
            ViewBag.lokSabhaConstituencyID = _LSCServices.getAlllokSabhaConstituencyConstituency(1).Select(e => new { e.lokSabhaConstituencyID, e.lokSabhaConstituencyName });
            ViewBag.msg = "";
            return View();
        }
        [HttpPost]
        public ActionResult Create(vidhanSabhaConstituency ovidhanSabhaConstituency, FormCollection frm)
        {
            bool result = false;
            ovidhanSabhaConstituency.dataIsCreated = BaseUtil.GetCurrentDateTime();
            ovidhanSabhaConstituency.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            ovidhanSabhaConstituency.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            ovidhanSabhaConstituency.dataIsUpdated = BaseUtil.GetCurrentDateTime();
            ovidhanSabhaConstituency.isActive = true;

            if (ModelState.IsValid)
            {
                result = _VSCServices.CreateVidhanSabha(ovidhanSabhaConstituency);
            }
            if (result)
            {
                TempData["Result"] = "Success";
                return RedirectToAction("Index");
            }
            ViewBag.msg = "Error ! Data not saved";
            ViewBag.stateID = _stateService.getAllStates().Select(e => new { e.stateID, e.stateName });
            ViewBag.districtID = _DistrictServices.getDistrictByStateID(1).Select(e => new { e.districtID, e.districtName });
            ViewBag.lokSabhaConstituencyID = _LSCServices.getAlllokSabhaConstituencyConstituency(1).Select(e => new { e.lokSabhaConstituencyID, e.lokSabhaConstituencyName });
            TempData["Result"] = "unsuccess";
            return View();
        }



    }
}