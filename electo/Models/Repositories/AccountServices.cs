using electo.Models.IRepositories;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Data;
using System.Web.Mvc;
using System.Collections.Generic;

namespace electo.Models.Repositories
{
    public class AccountServices : Controller, IAccountServices
    {

        private readonly UnitOfWork uow;
        
        public AccountServices()
        {
            uow = new UnitOfWork();
        }

        public sp_LoginUser_Result UserLogin(String userID, string password)
        {

            var param_userID = new SqlParameter("@userID", userID);
            var param_password = new SqlParameter("@password", BaseUtil.encrypt(password));
            
            try
            {
                return  uow.loginVolunteerRepository.SQLQuery<sp_LoginUser_Result>("sp_LoginUser @password,@userID", param_password, param_userID).FirstOrDefault();
            }
            catch { }
            return null;

        }
        public sp_LoginUser_App_Result UserLoginApp(String userID, string password, int userTypeID)
        {

            var param_userID = new SqlParameter("@userID", userID);
            var param_password = new SqlParameter("@password", password);
            var userTypeID_ = new SqlParameter("@userType", userTypeID);
            try
            {
                return uow.loginVolunteerRepository.SQLQuery<sp_LoginUser_App_Result>("sp_LoginUser_App @password,@userID,@userType", param_password, param_userID,userTypeID_).FirstOrDefault();

            }
            catch (Exception e)
            {

            }
            return null;

        }
        public string forgetpassword(string Email)
        {
            string result = string.Empty;
            var emial = Email.ToString();
            var emial1 = uow.loginVolunteer_.Find(e => e.userID == emial).Select(e => new { e.userID, e.loginID, e.fullName }).FirstOrDefault();
            if (emial1 != null)
            {
                string newPassword = baseClass.GetRandomPasswordString(6);
                int success = 0;
                success = ResetPassword(newPassword, emial1.loginID);
                if (success == 1)
                {
                    //----------------------------use below code to send emailer------------------------------------------------------------

                    StreamReader sr = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath("/emailers/ForgetPassword.html"));
                    string HTML_Body = sr.ReadToEnd();
                    string final_Html_Body = HTML_Body.Replace("#name", emial1.fullName).Replace("#password", newPassword);
                    sr.Close();
                    string To = emial1.userID.ToString();
                    string mail_Subject = "Password Changed";
                    result = BaseUtil.sendEmailer(To, mail_Subject, final_Html_Body, "");
                    //----------------------------end to send emailer------------------------------------------------------------
                    if (result == "ok")//if mail send
                    {
                        result = "success";
                    }
                    else
                    {
                        result = "failure ";
                    }
                }
            }
            else
            {
                result = "user not found";
            }
            return result;
        }

        public int ResetPassword(string newPassword, long LoginID)
        {
            int result = 0;
            var t = BaseUtil.encrypt(newPassword);
            var LoginID_ = new SqlParameter("@loginID", LoginID);
            var newPassword_ = new SqlParameter("@password", t);
            result = uow.loginVolunteer_.SQLQuery<int>("sp_resetPassword @loginID, @password", LoginID_, newPassword_).FirstOrDefault();
            if (result == 1)
            {
                result = 1;
            }
            return result;
        }

         public IEnumerable<politicalParty> getAll()
        {
            var politicalPartyList = uow.politicalParty_.GetAll().ToList();
            return politicalPartyList;
        }
        public IEnumerable<userType> getAllUserTypes()
        {
            var userTypeList = uow.userType_.GetAll().ToList();
            return userTypeList;
        }
        public IEnumerable< sp_getVoterDetailsByVoterID_Result> getDet(string voterIDNumber)
        {
            var voterIDNumber_ = new SqlParameter("@voterIDNumber", voterIDNumber);
            try
            {
                var result = uow.sp_Campaigns_GetByWardId_.SQLQuery<sp_getVoterDetailsByVoterID_Result>("sp_getVoterDetailsByVoterID @voterIDNumber", voterIDNumber_).ToList();
                return result;
            }
            catch { }
            return null;
        }
           
        
        public string createUser(string _voterID, string _politicalPartyID, string _dataIsCreated, string _dataIsUpdated, string _createdBy
            , string _modifiedBy, string _userID, string _mobile, string _fullName, bool _isActive, bool _isBlocked, string _AadharCardNumber, int userTypeid)
        {
            string returnResult = string.Empty;// User created and mail has been sent to user, User created, please recover your password,User not created, user already exists

            int result = 0;

            string _password = baseClass.GetRandomPasswordString(6);
            string encriptedPwd = BaseUtil.encrypt(_password);

            DateTime dt = Convert.ToDateTime(_dataIsCreated);
            DateTime dt2 = Convert.ToDateTime(_dataIsUpdated);

            var voterID_ = new SqlParameter("@voterID", _voterID);
            var politicalPartyID_ = new SqlParameter("@politicalPartyID", _politicalPartyID);
            var dataIsCreated_ = new SqlParameter("@dataIsCreated", dt);
            var dataIsUpdated_ = new SqlParameter("@dataIsUpdated", dt2);
            var createdBy_ = new SqlParameter("@createdBy", _createdBy);
            var modifiedBy_ = new SqlParameter("@modifiedBy", _modifiedBy);
            var userID_ = new SqlParameter("@userID", _userID);            
            var password_ = new SqlParameter("@password", encriptedPwd);
            var mobile_ = new SqlParameter("@mobile", _mobile);
            var fullName_ = new SqlParameter("@fullName", _fullName);
            var isActive_ = new SqlParameter("@isActive", _isActive);
            var isBlocked_ = new SqlParameter("@isBlocked", _isBlocked);
            var userPhoto_ = new SqlParameter("@userPhoto", "http://electo.qendidate.com/Logo/Emptyuser.jpg");
            var AadharCardNumber_= new SqlParameter("@AadharCardNumber", _AadharCardNumber); 
                var userTypeid_ = new SqlParameter("@userTypeid", userTypeid);
            try
            {
                result = uow.sp_CreateUser_.SQLQuery<int>("sp_CreateUser @voterID,@politicalPartyID,@dataIsCreated,@dataIsUpdated,@createdBy,@modifiedBy,@userID,@password,@mobile,@fullName,@isActive,@isBlocked, @AadharCardNumber,@userTypeid,@userPhoto",
                                                                         voterID_, politicalPartyID_, dataIsCreated_, dataIsUpdated_, createdBy_, modifiedBy_, userID_,  password_, mobile_, fullName_, isActive_, isBlocked_, AadharCardNumber_, userTypeid_, userPhoto_).FirstOrDefault();


                if (result == 0)
                {
                    returnResult = "User not created";

                }
                else if (result == 2)
                {
                    returnResult = " User already exists";

                }
                else
                {
                    //----------------------------use below code to send emailer------------------------------------------------------------

                    StreamReader sr = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath("/emailers/NewVolunteerRegistrtion.html"));
                    string HTML_Body = sr.ReadToEnd();
                    string final_Html_Body = HTML_Body.Replace("#name", _fullName).Replace("#password", _password).Replace("#userID",_userID.ToString());
                    sr.Close();
                    string To = _userID.ToString();
                    string mail_Subject = "Thank you for registring in mulburry Application ";
                    returnResult = BaseUtil.sendEmailer(To, mail_Subject, final_Html_Body, "");
                    //----------------------------end to send emailer------------------------------------------------------------
                    if (returnResult == "ok")//if mail send
                    {
                        returnResult = "User created and mail has been sent to user";
                    }
                    else
                    {
                        returnResult = "User created, Please ask user to recover password ";
                    }

                }
            }

            catch (Exception e)
            {

            }
            return returnResult;


        }

        public int ActivateCreateCompaign(long volunteerID)
        {
            int result = 0;
            var volunteerID_ = new SqlParameter("@volunteerID", volunteerID);
            try
            {
                result = uow.sp_CreateUser_.SQLQuery<int>("sp_update_volunteerList @volunteerID", volunteerID_).FirstOrDefault();
            }

            catch (Exception e)
            {

            }
            return result;
        }

        public int saveLogoutDetails(long loginID, DateTime currentDateTime)
        {
            int result = 0;
            long? val = loginID;
            
            var loginID_ = new SqlParameter("@loginID", null);
            var currentDateTime_ = new SqlParameter("@loginID", null);
            if (val != null)
            {
                loginID_ = new SqlParameter("@loginID", loginID);
            }
            if (currentDateTime != null)
            {
                currentDateTime_ = new SqlParameter("@logoutTime", currentDateTime);
            }
            try
            {
                uow.saveLogoutDetails_.SQLQuery<int>("sp_updateLastLoginTime @loginID,@logoutTime", loginID_, currentDateTime_);
                result = 1;
            }
            catch (Exception e)
            {
                result = 0;
            }
            return result;
        }

        public IEnumerable<sp_getAllParties_NoParams_Result> getAllPoliticalParty()
        {           

            var result = (dynamic)null;
            try
            {
                 result = uow.sp_getAllParties_NoParams_Result_.SQLQuery<sp_getAllParties_NoParams_Result>("sp_getAllParties_NoParams").ToList();
            }
            catch(Exception e)
            {
            }
            return result;
        }

        public IEnumerable<sp_searchUserLoginStatus_Result> getUserLoginStatus(int userTypeID, string userID)
        {     
            var userTypeID_ = new SqlParameter("@userTypeID", userTypeID);
            var userID_ = new SqlParameter("@userID", userID);
            var result = (dynamic)null;
            try
            {
                result = uow.sp_getAllParties_NoParams_Result_.SQLQuery<sp_searchUserLoginStatus_Result>("sp_searchUserLoginStatus @userTypeID, @userID", userTypeID_, userID_).ToList();
            }
            catch (Exception e)
            {
            }
            return result;

        }

        public loginVolunteer getUserDetails(long loginID)
        {
            var result = (dynamic)null;
            try
            {
                result = uow.getUserDetails_.GetByID(loginID);
            }
            catch (Exception e)
            {
            }
            return result;
        }

        public int saveUserDetails(loginVolunteer _loginVolunteer)
        {
            int result = 0;
            try
            {
                uow.saveUserDetails_.Update(_loginVolunteer);
                result = 1;
            }
            catch (Exception e)
            {
                result = 0;
            }
            return result;
        }

       

        public int updateUserLoginStatus(long loginID, long updateBy,bool isActive)
        {

            var loginID_ = new SqlParameter("@loginID", loginID);
            var updateBy_ = new SqlParameter("@updateBy", updateBy);
            var isActive_ = new SqlParameter("@isActive", isActive);
            var dataIsUpdated_ = new SqlParameter("@dataIsUpdated", BaseUtil.GetCurrentDateTime()); 
            var result = (dynamic)null;
            try
            {
                result = uow.sp_getAllParties_NoParams_Result_.SQLQuery<int>("sp_updateUserLoginStatus @loginID, @updateBy,@isActive,@dataIsUpdated ", loginID_, updateBy_, isActive_, dataIsUpdated_).FirstOrDefault();
            }
            catch (Exception e)
            {
            }
            return result;
        }
    }
}