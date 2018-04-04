using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using electo.Models;
using electo.Models.Repositories;
using electo.Models.IRepositories;
using electo.Models.BaseClass;

namespace electo.Controllers
{
    public class voterListController : BaseClass
    {
        private electoEntities db = new electoEntities();

        private readonly IvoterListService voterListService_;
        private readonly ILSCServices LSCServices_;
        private readonly IVSCServices VSCServices_;
        private readonly IstateService stateService_;
        private readonly IAreaService AreaService_;
        private readonly IwardServices wardServices_;
        private readonly IlanguageServices languageServices_;
        private readonly IDistrictServices DistrictServices_;
       public voterListController()
        {
            LSCServices_ = new LSCServices();
            VSCServices_ = new VSCServices();
            voterListService_ = new voterListService();
            stateService_ = new stateService();
            AreaService_ = new AreaService();
            wardServices_ = new wardServices();
            languageServices_ = new languageServices();
            DistrictServices_ = new DistrictServices();
        }

        // GET: voterList
        public ActionResult Index()
        {
            int usertypeID = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.userType.ToString()));
            if (usertypeID == 1)
            {
                ViewBag.dataEntryOperators = new SelectList((voterListService_.getAllDataEntryOperators().Select(e => new { e.loginID, e.fullName })), "loginID", "fullName");
            }
            return View();
        }
        [HttpPost]
        public ActionResult _partialVoterDetails(string voterID, string date, string userID)
        {
            var result = voterListService_.getVoters(voterID, date, userID);
            return PartialView("_partialVoterDetails", result);
        }
        // GET: voterList/Create
        public ActionResult Create()
        {
            ViewBag.regionalLanguage = languageServices_.getAll_LangaugeList();//, "languageID", "language1");
            ViewBag.areaID = db.areaNames.Select(e => new { e.areaID, e.areaName1 }).ToList(); //, "areaID", "areaName1");
            ViewBag.lokSabhaConstituencyID = LSCServices_.getAlllokSabhaConstituencyConstituency(1);// "lokSabhaConstituencyID", "lokSabhaConstituencyName");
            ViewBag.stateID = stateService_.getAllStates();//, "stateID", "stateName");
            ViewBag.vidhanSabhaConstituencyID = VSCServices_.getvidhanSabhaConstituencyByStateIDANDLKSCID(1, 1, "");//, "vidhanSabhaConstituencyID", "vidhanSabhaConstituencyName");
            ViewBag.wardID = wardServices_.getZoneByStateIDAndMUncipalCorporationID(1, 1, 1,1);//, "wardID", "wardName");
           
            ViewBag.genderID = db.genders.Select(e=>new { e.genderId,e.gender1}).ToList();

            voterList ovoterList= new voterList();
            
            return View(ovoterList);
        }
        public ActionResult Create1(voterList ovoterList)
        {
            ViewBag.regionalLanguage = languageServices_.getAll_LangaugeList();//, "languageID", "language1");
            ViewBag.areaID = db.areaNames.Select(e => new { e.areaID, e.areaName1 }).ToList();//, "areaID", "areaName1");
            ViewBag.lokSabhaConstituencyID = db.lokSabhaConstituencies.Select(e => new { e.lokSabhaConstituencyID, e.lokSabhaConstituencyName });// "lokSabhaConstituencyID", "lokSabhaConstituencyName");
            ViewBag.stateID = db.states.Select(e => new { e.stateID, e.stateName });//, "stateID", "stateName");
            ViewBag.vidhanSabhaConstituencyID = db.vidhanSabhaConstituencies.Select(e => new { e.vidhanSabhaConstituencyID, e.vidhanSabhaConstituencyName });//, "vidhanSabhaConstituencyID", "vidhanSabhaConstituencyName");
            ViewBag.wardID = db.wardConstituencies.Select(e => new { e.wardID, e.wardName });//, "wardID", "wardName");
         
            ViewBag.genderID = db.genders.Select(e => new { e.genderId, e.gender1 }).ToList();         

            return View("Create", ovoterList);
        }

        public ActionResult _partialVoterDetails()
        {
            return PartialView();
        }

        
        [HttpPost]      
        public ActionResult Create(electo.Models.voterList voterList)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result= voterListService_.createNewVoter(voterList);
            }
            if (result == 1)
            {
                TempData["Creation"] = "Success";                
            }
            else {
                TempData["Creation"] = "unsuccess";
            }          
           
            return RedirectToAction("Create1",voterList);
        }

        // GET: voterList/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            voterList voterList = null;
            voterList = voterListService_.getVoterByID((long)id);
            if (voterList == null)
            {
                return HttpNotFound();
            }

            ViewBag.regionalLanguage = languageServices_.getAll_LangaugeList();//, "languageID", "language1");
            ViewBag.areaID = db.areaNames.Select(e => new { e.areaID, e.areaName1 }).ToList();//, "areaID", "areaName1");
            ViewBag.lokSabhaConstituencyID = db.lokSabhaConstituencies.Select(e => new { e.lokSabhaConstituencyID, e.lokSabhaConstituencyName });// "lokSabhaConstituencyID", "lokSabhaConstituencyName");
            ViewBag.stateID = db.states.Select(e => new { e.stateID, e.stateName });//, "stateID", "stateName");
            ViewBag.vidhanSabhaConstituencyID = db.vidhanSabhaConstituencies.Select(e => new { e.vidhanSabhaConstituencyID, e.vidhanSabhaConstituencyName });//, "vidhanSabhaConstituencyID", "vidhanSabhaConstituencyName");
            ViewBag.wardID = db.wardConstituencies.Select(e => new { e.wardID, e.wardName });//, "wardID", "wardName");
           
            ViewBag.genderID = db.genders.Select(e => new { e.genderId, e.gender1 }).ToList();
            return View(voterList);
        }

       
        [HttpPost]        
        public ActionResult Edit(voterList voterList)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = voterListService_.UpdateVoter(voterList);
            }
            if (result == 1)
            {
                TempData["Creation"] = "Success";
            }
            else
            {
                TempData["Creation"] = "unsuccess";
            }

           
            ViewBag.regionalLanguage = languageServices_.getAll_LangaugeList();//, "languageID", "language1");
            ViewBag.areaID = db.areaNames.Select(e => new { e.areaID, e.areaName1 }).ToList();//, "areaID", "areaName1");
            ViewBag.lokSabhaConstituencyID = db.lokSabhaConstituencies.Select(e => new { e.lokSabhaConstituencyID, e.lokSabhaConstituencyName });// "lokSabhaConstituencyID", "lokSabhaConstituencyName");
            ViewBag.stateID = db.states.Select(e => new { e.stateID, e.stateName });//, "stateID", "stateName");
            ViewBag.vidhanSabhaConstituencyID = db.vidhanSabhaConstituencies.Select(e => new { e.vidhanSabhaConstituencyID, e.vidhanSabhaConstituencyName });//, "vidhanSabhaConstituencyID", "vidhanSabhaConstituencyName");
            ViewBag.wardID = db.wardConstituencies.Select(e => new { e.wardID, e.wardName });//, "wardID", "wardName");
           
            ViewBag.genderID = db.genders.Select(e => new { e.genderId, e.gender1 }).ToList();
            return View(voterList);
        }

      
    }
}
