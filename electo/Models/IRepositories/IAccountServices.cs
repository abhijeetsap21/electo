using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface IAccountServices
    {
        sp_LoginUser_Result UserLogin(String userID, string password);
        string forgetpassword(string Email);
        int ResetPassword(string newPassword, long LoginID);
        IEnumerable<politicalParty> getAll();
        IEnumerable<userType> getAllUserTypes();
        IEnumerable< sp_getVoterDetailsByVoterID_Result> getDet(string voterIDNumber);
        string  createUser(string _voterID, string  _politicalPartyID, string _dataIsCreated, string _dataIsUpdated, string _createdBy, string _modifiedBy, string _userID,  string _mobile, string _fullName, bool _isActive,bool _isBlocked, string AAdharNumber, int userTypeid);
        int ActivateCreateCompaign(long volunteerID);
        IEnumerable<sp_getAllParties_NoParams_Result> getAllPoliticalParty();
        loginVolunteer getUserDetails(long loginID);
        int saveUserDetails(loginVolunteer _loginVolunteer);
        int saveLogoutDetails(long loginID, DateTime currentDateTime);
        IEnumerable<sp_searchUserLoginStatus_Result> getUserLoginStatus(int userTypeID, string userID);
        sp_LoginUser_App_Result UserLoginApp(String userID, string password, int userTypeID);
    }
}
