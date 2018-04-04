using electo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using electo.Models;
using electo.Models.IRepositories;
using Newtonsoft.Json;
using static electo.Models.SP_Models.StoredProcedureModels;

namespace electo.WebServicesController
{
    public class AccountController : ApiController
    {
        private readonly IAccountServices _AccountServices;

        public AccountController()
        {
            _AccountServices = new AccountServices();
        }

        [HttpPost]
        public IHttpActionResult userLogin([FromBody]LoginViewModelApp _LoginViewModel)
        {
            if (ModelState.IsValid)
            {
                _LoginViewModel.Password = BaseUtil.encrypt(_LoginViewModel.Password);
                var _objloginVolunteer = _AccountServices.UserLoginApp(_LoginViewModel.Email, _LoginViewModel.Password, _LoginViewModel.userTypeID);
                if (_objloginVolunteer != null)
                {

                    var productEntities = _objloginVolunteer as sp_LoginUser_App_Result ?? _objloginVolunteer;
                    if (productEntities != null)
                        //return Request.CreateResponse(HttpStatusCode.OK, productEntities);
                    return Json(new { status = "Success", msg = "Record found", data = productEntities });
                }
                //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found");
                return Json(new { status = "Error", msg = "Record not found" });
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Invalid Model");
            return Json(new { status = "Error", msg = "Invalid Model" });
        }
        [HttpPost]
        public IHttpActionResult forgetpassword(string Email)
        {
            string result = string.Empty;
            if (ModelState.IsValid)
            {
                result = _AccountServices.forgetpassword(Email);
                if (result == "success")
                {
                    //return Request.CreateResponse(HttpStatusCode.OK, result);
                    return Json(new { status = "Success", msg = "Record found", data = result });
                }
                if(result == "failure")
                {
                    return Json(new { status = "Error", msg = "Error Sending Mail" });
                }
            }
            return Json(new { status = "Error", msg = "user not found" });
        }
        [HttpGet]
        public IHttpActionResult resetPassword(string newPassword, long loginID)
        {
            bool result = false;

            result = Convert.ToBoolean(_AccountServices.ResetPassword(newPassword, loginID));            
               if(result == true)
                {
                return Json(new { status = "Success", msg = "Record found"});
            }

            return Json(new { status = "Error", msg = "Invalid Model" });
        }

        [HttpGet]
        public IHttpActionResult getVoterByID(string voterID)
        {
            List<sp_getVoterDetailsByVoterIDApp> osp_getVoterDetailsByVoterIDApp_= new List<sp_getVoterDetailsByVoterIDApp>();
            var result = _AccountServices.getDet(voterID);
            if (result != null)
            {
                if (result.Count() != 0)
                {
                    sp_getVoterDetailsByVoterIDApp osp_getVoterDetailsByVoterIDApp;
                    foreach (var list_ in result)
                    {
                        osp_getVoterDetailsByVoterIDApp = new sp_getVoterDetailsByVoterIDApp();
                        osp_getVoterDetailsByVoterIDApp.address = list_.address;
                        if (list_.dateOfBirth != null)
                        {
                            osp_getVoterDetailsByVoterIDApp.dateOfBirth = (DateTime)list_.dateOfBirth;
                        }
                        osp_getVoterDetailsByVoterIDApp.Regional_Name = list_.Regional_Name;
                        osp_getVoterDetailsByVoterIDApp.volunteerID = list_.volunteerID;
                        osp_getVoterDetailsByVoterIDApp.voterFather_HusbandName = list_.voterFather_HusbandName;
                        osp_getVoterDetailsByVoterIDApp.voterID = list_.voterID;
                        osp_getVoterDetailsByVoterIDApp.voterIDNumber = list_.voterIDNumber;
                        osp_getVoterDetailsByVoterIDApp_.Add(osp_getVoterDetailsByVoterIDApp);
                    }
                    return Json(new { status = "Success", msg = "Record found", data = osp_getVoterDetailsByVoterIDApp_ });
                }
                else {
                    return Json(new { status = "Success", msg = "user not found" });
                }
               
            }

            return Json(new { status = "Error", msg = "user not found" });
        }
        [HttpGet]
        public IHttpActionResult getAllPartiees()
        {
            var result = _AccountServices.getAllPoliticalParty();
            if (result != null)
            {
                return Json(new { status = "Success", msg = "Record found", data = result });
            }

            return Json(new { status = "Error", msg = "Record not found" });
        }
        [HttpGet]       
        public HttpResponseMessage getAllParties()
        {
            var result = (_AccountServices.getAllPoliticalParty());
            var jsonResult = JsonConvert.SerializeObject(result);
            return Request.CreateResponse(HttpStatusCode.OK, jsonResult);
        }

        [HttpPost]
        public IHttpActionResult createUser([FromBody] CreateVolunteerLoginApp _createVolunteerLogin)
        {
           
            string _voterID = _createVolunteerLogin.voterID.ToString();
            string _politicalPartyID = _createVolunteerLogin.politicalPartyID.ToString();
            string _dataIsCreated = BaseUtil.GetCurrentDateTime().ToString();
            string _dataIsUpdated = BaseUtil.GetCurrentDateTime().ToString();
            long _createdBy = 1;          
            string _userID = _createVolunteerLogin.userID;   
            string _mobile = _createVolunteerLogin.mobile;
            string _fullName = _createVolunteerLogin.fullName;
            string _AadharCardNumber = _createVolunteerLogin.AadharCardNumber;
            bool _isActive = true;
            bool _isBlocked = false;
            int userTypeid =4;
            string returnResult = string.Empty;
            returnResult = _AccountServices.createUser(_voterID, _politicalPartyID, _dataIsCreated, _dataIsUpdated, _createdBy.ToString(), _createdBy.ToString(), _userID,  _mobile, _fullName, _isActive, _isBlocked, _AadharCardNumber,  userTypeid);

           
                return Json(new { status = "Success", msg = returnResult });            

        }

        [HttpPost]
        public HttpResponseMessage userLogin_([FromBody]LoginViewModel _LoginViewModel)
        {
            if (ModelState.IsValid)
            {
                _LoginViewModel.Password = BaseUtil.encrypt(_LoginViewModel.Password);
                var _objloginVolunteer = _AccountServices.UserLogin(_LoginViewModel.Email, _LoginViewModel.Password);
                if (_objloginVolunteer != null)
                {

                    var productEntities = _objloginVolunteer as sp_LoginUser_Result ?? _objloginVolunteer;
                    if (productEntities != null)
                        return Request.CreateResponse(HttpStatusCode.OK, productEntities);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User not found");
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Invalid Model");
        }
        [HttpPost]
        public HttpResponseMessage forgetpassword_(string Email)
        {
            string result = string.Empty;
            if (ModelState.IsValid)
            {
                result = _AccountServices.forgetpassword(Email);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Invalid Model");
        }
        [HttpGet]
        public HttpResponseMessage resetPassword_(string newPassword, long loginID)
        {
            bool result = false;

            result = Convert.ToBoolean(_AccountServices.ResetPassword(newPassword, loginID));
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}




