using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static electo.Models.SP_Models.StoredProcedureModels;
using electo.Models;
using electo.Models.Repositories;
using electo.Models.IRepositories;


namespace electo.Controllers
{
    [CustomErrorHandling]
    public class EnquiriesController : Controller
    {
        private readonly IEnquiryServices _enquiryServices;
       
        // GET: Enquiries

        public EnquiriesController()
            {
            _enquiryServices = new EnquiryServices();

            }


        public ActionResult Enquiries()
        {
            ViewBag.EnquiryType = new SelectList((_enquiryServices.getEnquiryTypes().Select(e => new { e.enquiryTypeID, e.enquiryTypeName })), "enquiryTypeID", "enquiryTypeName");
            return View();            
        }

        public ActionResult _partialEnquiriesList(string enquirytype, string date, string mobile, bool isTaskCompleted)
        {
            return PartialView("_partialEnquiriesList",_enquiryServices.GetNewEnquiries_Result(enquirytype, date, mobile, isTaskCompleted));
        }

        [HttpGet]
        public ActionResult _partialEditEnquiry(long eID)
        {
            //_enquiryServices.get(eID);            
            return PartialView("_partialEditEnquiry", _enquiryServices.get(eID));
        }

        [HttpPost]
        public ActionResult _partialEditEnquiry(enquiry _enq)
        {
            _enquiryServices._save(_enq);
            TempData["Result"] = "Success";
            return RedirectToAction("Enquiries", "Enquiries");
        }

        [HttpGet]
        public ActionResult Create()
        {            
            ViewBag.electionTypeID = _enquiryServices.getEnquiryTypes();

            return View();
        }

        [HttpPost]
        public ActionResult Create(enquiry _enq)
        {
            enquiry _objEnq = new enquiry();
            _objEnq.dataIsCreated = BaseUtil.GetCurrentDateTime();
            _objEnq.dataIsUpdated = BaseUtil.GetCurrentDateTime();
            _objEnq.email = _enq.email;
            _objEnq.mobile = _enq.mobile;
            _objEnq.enquirerName = _enq.enquirerName;
            _objEnq.enquiryDescription = _enq.enquiryDescription;
            _objEnq.enquiryTypeID = _enq.enquiryTypeID;
            _objEnq.isTaskComplete = false;
            _objEnq.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString())); 
            if (ModelState.IsValid)
            {

                var result = _enquiryServices.create(_enq);              
            }
            ViewBag.electionTypeID = _enquiryServices.getEnquiryTypes();
            return View();
        }
    }
}