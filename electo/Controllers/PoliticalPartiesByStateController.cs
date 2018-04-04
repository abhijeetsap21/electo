using electo.Models;
using electo.Models.BaseClass;
using electo.Models.IRepositories;
using electo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace electo.Controllers
{
    [CustomErrorHandling]
    public class PoliticalPartiesByStateController : BaseClass
    {
        private readonly IstateService _stateService;
        private readonly IPoliticalPartyService _PoliticalPartyService;
        private readonly IDistrictServices _DistrictServices;

        public PoliticalPartiesByStateController()
        {
            _stateService = new stateService();
            _PoliticalPartyService = new PoliticalPartyService();
            _DistrictServices = new DistrictServices();

        }
        // GET: PoliticalPartiesByState
        public ActionResult Index()
        {
            ViewBag.States = new SelectList((_stateService.getAllStates().Select(e => new { e.stateID, e.stateName })), "stateID", "stateName");
            return View();
        }

        public ActionResult _partialPoliticalPartiesByStateList(  int stateId, string partyName)
        {   if (partyName == "0" || partyName==null)
            {
                partyName = "";
            }

            var AreaLIst = _PoliticalPartyService.getAll_PoliticalPartyListByStateID( stateId, partyName);
            return PartialView("_partialPoliticalPartiesByStateList", AreaLIst);
        }
        [HttpGet]
        public ActionResult Create()
        {
            CreatePartyViewModel oCreatePartyViewModel = new CreatePartyViewModel();
            ViewBag.stateID = _stateService.getAllStates();
            ViewBag.districtID = _DistrictServices.getDistrictByStateID(1).Select(e => new { e.districtID, e.districtName });
            return View(oCreatePartyViewModel);
        }
        [HttpPost]
        public ActionResult Create( CreatePartyViewModel oCreatePartyViewModel, FormCollection frm, HttpPostedFileBase files)
        {
            String fileName = "";
            if (files != null)
            {
                fileName = Guid.NewGuid() + "_" + Path.GetFileName(files.FileName);
                var path = Path.Combine(Server.MapPath("~/Logo/"), fileName);
                files.SaveAs(path);
                oCreatePartyViewModel._politicalParty.politicalPartyLogo = "http://electo.qendidate.com/Logo/" + fileName;
            }
            else
            {
                oCreatePartyViewModel._politicalParty.politicalPartyLogo = "http://electo.qendidate.com/Logo/" + "emptyLogo.jpg";
            }
            oCreatePartyViewModel._politicalParty.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            oCreatePartyViewModel._politicalParty.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            oCreatePartyViewModel._politicalParty.dataIsCreated = BaseUtil.GetCurrentDateTime();
            oCreatePartyViewModel._politicalParty.dataIsUpdated = BaseUtil.GetCurrentDateTime();           
            oCreatePartyViewModel._politicalPartyAddress.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            oCreatePartyViewModel._politicalPartyAddress.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            oCreatePartyViewModel._politicalPartyAddress.dataIsCreated = BaseUtil.GetCurrentDateTime();
            oCreatePartyViewModel._politicalPartyAddress.dataIsUpdated = BaseUtil.GetCurrentDateTime();

            int result = 0;
            try
            {
                result = _PoliticalPartyService.createParty(oCreatePartyViewModel);
            }
            catch { }
            if (result == 1)
            {
                TempData["msg"] = "New party created successfully";
                return RedirectToAction("Index");
            }

            ViewBag.stateID = _stateService.getAllStates();
            ViewBag.districtID = _DistrictServices.getDistrictByStateID(1).Select(e => new { e.districtID, e.districtName });
            TempData["msg"] = "Data not saved";
            return View(oCreatePartyViewModel);
        }

        public ActionResult GetDistrictbyState(int stateId)
        {

            var lstDistrict = _DistrictServices.getDistrictByStateID(stateId).Select(e => new { e.districtID, e.districtName });

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(lstDistrict);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult _partialMorePartyAddress(int politicalPartyID)
        {
            var MorePartyAddresList = _PoliticalPartyService.PoliticalPartyAddressList(politicalPartyID);         
            return PartialView("_partialMorePartyAddress", MorePartyAddresList);
        }

        public ActionResult _PartialNewAddress(int politicalPartyID)
        {
            ViewBag.stateID = _stateService.getAllStates();
            ViewBag.politicalPartyID = politicalPartyID;
            ViewBag.districtID = _DistrictServices.getDistrictByStateID(1).Select(e => new { e.districtID, e.districtName });
            return PartialView("_PartialNewAddress");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult saveNewAddress(politicalPartyAddress opoliticalPartyAddress , FormCollection frm)
        {
            opoliticalPartyAddress.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            opoliticalPartyAddress.dataIsCreated = BaseUtil.GetCurrentDateTime();
            opoliticalPartyAddress.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            opoliticalPartyAddress.dataIsUpdated = BaseUtil.GetCurrentDateTime();         
            opoliticalPartyAddress.isActive = true;
            opoliticalPartyAddress.isDelete = false;
            bool result = false;
            if (ModelState.IsValid)
            {
                result = _PoliticalPartyService.saveNewAddress(opoliticalPartyAddress);
            }
            if (result)
            {
                TempData["msg"] = "New address saved";
            }
            else
            {
                TempData["msg"] = "Address not saved";
            }
            TempData["stateID"] = opoliticalPartyAddress.stateID;
            ViewBag.stateID = _stateService.getAllStates();
            ViewBag.politicalPartyID = opoliticalPartyAddress.politicalPartyID;
            return RedirectToAction("Index");
        }
        }
}