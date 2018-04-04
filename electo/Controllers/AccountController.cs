using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using electo.Models;
using electo.Models.Repositories;
using System.IO;
using electo.Models.BaseClass;
using electo.Models.IRepositories;
using System.Web.Script.Serialization;

namespace electo.Controllers
{
    [CustomErrorHandling]
    public class AccountController : BaseClass
    {

        private readonly IAccountServices _IAccountServices;      
        private readonly IElectionService _ElectionService;
        private readonly ICampaignService _CampaignService;
       public AccountController()
        {
            _IAccountServices = new AccountServices();
            _ElectionService = new ElectionService();
            _CampaignService = new CampaignService();
        }
        private AccountServices _accServices = new AccountServices();

        // GET: Account
        [HttpGet]
        public ActionResult login()
        {
            LoginViewModel _LoginViewModel = new LoginViewModel();
            return View(_LoginViewModel);
        }
        [HttpPost]
        public ActionResult login(LoginViewModel _LoginViewModel)
        {
            if (ModelState.IsValid)
            {
              
                var result = _IAccountServices.UserLogin(_LoginViewModel.Email, _LoginViewModel.Password);
                if (result != null)
                {

                    if (result.loginID == 0)
                    {
                        ViewBag.msg = result.message;
                        return View();
                    }

                    BaseUtil.SetSessionValue(AdminInfo.LoginID.ToString(), result.loginID.ToString());
                    BaseUtil.SetSessionValue(AdminInfo.FullName.ToString(), result.voterName.ToString());
                    BaseUtil.SetSessionValue(AdminInfo.userPhoto.ToString(), result.userPhoto.ToString());                    
                    BaseUtil.SetSessionValue(AdminInfo.userType.ToString(), result.userTypeID.ToString());
                    BaseUtil.SetSessionValue(AdminInfo.volunteerID.ToString(), result.volunteerID.ToString());
                    BaseUtil.SetSessionValue(AdminInfo.politicalPartyID.ToString(), result.politicalPartyID.ToString());
                    string pass = BaseUtil.Decrypt(result.password.ToString());
                    BaseUtil.SetSessionValue(AdminInfo.unikKey.ToString(), pass);


                    if (result.userTypeID == 3 || result.userTypeID == 1)
                    {
                         return RedirectToAction("Dashboard", "dashboard");
                    }
                   else if (result.userTypeID == 4)
                    {
                        TempData["createNewCompaign"] = result.createNewCompaign.ToString();
                        return RedirectToAction("CAdmin");
                    }
                    else {
                        ViewBag.msg = "You are not authorized to access this website";
                        return View();
                    }

                   
                }
                ViewBag.msg = "Userid and password not found";
                return View();
            }
            ViewBag.msg = "invalid model";
            return View();
        }

        public ActionResult Logout()
        {
            if (BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()) != "")
            {
                long loginID = Convert.ToUInt32(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
                DateTime currentDateTime = BaseUtil.GetCurrentDateTime();
                _accServices.saveLogoutDetails(loginID, currentDateTime);
            }
            Session.Abandon();
            return RedirectToAction("login");
        }
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(LoginIdViewModel oLoginIdViewModel)
        {
            string result = string.Empty;
           
            result = _IAccountServices.forgetpassword(oLoginIdViewModel.Email);
            TempData["Result"] = result;
            return View("Login");
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(ChangePasswordViewModel oChangePasswordViewModel)
        {
            if (oChangePasswordViewModel.OldPassword != BaseUtil.GetSessionValue(AdminInfo.unikKey.ToString()))
            {
                ViewBag.msg = "old";
                return View();
            }
            bool result = false;
            loginVolunteer _loginVolunteer = new loginVolunteer();          
            result =Convert.ToBoolean( _IAccountServices.ResetPassword(oChangePasswordViewModel.NewPassword, Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()))));

            if (result)
            {
                ViewBag.msg = "Success";
            }
            else
            {
                ViewBag.msg = "Failure";
            }
            return View();
        }

       

        public ActionResult SearchVolunteerUser()
        {
            return View();
        }
        public ActionResult getVoterDetails(string voterIDNumber)
        {
           
            //var result = oWebApiRepositories.getVoterByID("Account", "getVoterByID", voterIDNumber);
            var result = _accServices.getDet(voterIDNumber);
            return PartialView("_partialVoterDetails", result);
        }
      
       
        public ActionResult CreateUser(long voterID)
        {
            ViewBag.PoliticalPartyID = _accServices.getAll();
            ViewBag.userTypeID = _accServices.getAllUserTypes();
            ViewBag.voterID = voterID;
            return PartialView("CreateUser");
        }
        [HttpPost]
        public ActionResult Create(CreateVolunteerLogin _createVolunteerLogin)
        {
            string returnResult = string.Empty;// User created and mail has been sent to user, User created, please recover your password,User not created, user already exists
            _createVolunteerLogin.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString())) ;           
            //string encriptedPwd = BaseUtil.encrypt(_password);
            string  result = string.Empty;


            result = _IAccountServices.createUser(_createVolunteerLogin.voterID,
                                                    _createVolunteerLogin.politicalPartyID.ToString(), BaseUtil.GetCurrentDateTime().ToString(), BaseUtil.GetCurrentDateTime().ToString(),
                                                  BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()),BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()),
                                                    _createVolunteerLogin.userID, _createVolunteerLogin.mobile, _createVolunteerLogin.fullName, _createVolunteerLogin.isActive, _createVolunteerLogin.isBlocked,
                                                    _createVolunteerLogin.AadharCardNumber, _createVolunteerLogin.userTypeID);      
           
             TempData["returnResult"]  = result;
            return RedirectToAction("SearchVolunteerUser");     
        }



        public int ActivateCreateCompaign(long volunteerID)
        {
            int result = 0;
            result= _accServices.ActivateCreateCompaign(volunteerID);
            return result;
        }
        [HttpGet]
        public ActionResult UpdateProfile(long loginID)
        {
            loginVolunteer _loginvolunteer = _accServices.getUserDetails(loginID);
            return View(_loginvolunteer);
        }

        [HttpPost]
        public ActionResult UpdateProfile(loginVolunteer _loginVolunteer, HttpPostedFileBase files)
        {
            String fileName = "";
            if (files != null)
            {
                fileName = Guid.NewGuid() + "_" + Path.GetFileName(files.FileName);
                var path = Path.Combine(Server.MapPath("~/Logo/"), fileName);
                files.SaveAs(path);
                _loginVolunteer.userPhoto = "http://electo.qendidate.com/Logo/" + fileName;
            }

            else
            {
                _loginVolunteer.userPhoto = "http://electo.qendidate.com/Logo/" + "Emptyuser.jpg";
            }

            _loginVolunteer.dataIsUpdated = BaseUtil.GetCurrentDateTime();
            var modified = BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString());
            _loginVolunteer.modifiedBy = Convert.ToUInt32(modified);
            int result = _accServices.saveUserDetails(_loginVolunteer);
            if (result == 1)
            {
                TempData["Result"] = "Success";
            }
            else {
                TempData["Result"] = "Failure";
            }
            return View(_loginVolunteer);
        }

        public ActionResult Index()
        {
            
            ViewBag.userTypeID = new SelectList((_accServices.getAllUserTypes().Select(e => new { e.userTypeID, e.userTypeName })), "userTypeID", "userTypeName");
            return View();
        }

        public ActionResult _partialViewUserLoginStatus(int userTypeID, string userID)
        {
            var UserLoginStatusList = _accServices.getUserLoginStatus(userTypeID, userID);

            return PartialView("_partialViewUserLoginStatus", UserLoginStatusList);
        }

        public int updateUserLoginStatus(long loginID, bool isActive)
        {
            int result = 0;
            result = _accServices.updateUserLoginStatus(loginID, Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString())), isActive);
            return result;
        }

        [HttpGet]
        public ActionResult CAdmin()
        {
            ViewBag.electionTypeID = _ElectionService.getElectionTypes().Select(e => new { e.electionTypeID, e.electionTypeNAME });//), "electionTypeID", "electionTypeNAME");
            ViewBag.campaignID = _CampaignService.getCompaignListByElectionIDandCreatedByID(0, 0).Select(e=>new { e.campaignID, e.campaignName });
            ViewBag.IsCampaignCreationActive = TempData["createNewCompaign"];
            return View();
        }
        [HttpPost]
        public ActionResult CAdmin(CompaignAdmin oCompaignAdmin, FormCollection frm)
        {
            BaseUtil.SetSessionValue(AdminInfo.electionType.ToString(), frm["hdn_electionType"].ToString());
            BaseUtil.SetSessionValue(AdminInfo.campaign.ToString(), frm["hdn_campaignID"].ToString());
           
            BaseUtil.SetSessionValue(AdminInfo.campaignID.ToString(), oCompaignAdmin.campaignID.ToString());
            return RedirectToAction("Index", "CampaignActivity");
        }
        public ActionResult getCampaignList(int ElectionTypeId)
        {
            var CampaignList = _CampaignService.getCompaignListByElectionIDandCreatedByID(Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString())), ElectionTypeId).Select(e => new { e.campaignID, e.campaignName });
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
           
            return Json(javaScriptSerializer.Serialize(CampaignList), JsonRequestBehavior.AllowGet);
        }


       

    }
}