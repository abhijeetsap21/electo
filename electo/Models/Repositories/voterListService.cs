using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using static electo.Models.SP_Models.StoredProcedureModels;

namespace electo.Models.Repositories
{
    public class voterListService: IvoterListService
    {
        private readonly UnitOfWork uow;
        public voterListService()
        {
            uow = new UnitOfWork();
        }
        public int createNewVoter(voterList ovoterList_Copy)
        {

            ovoterList_Copy.createdBy = Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            ovoterList_Copy.modifiedBy = Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            ovoterList_Copy.dataIsCreated = BaseUtil.GetCurrentDateTime();
            ovoterList_Copy.dataIsUpdated = BaseUtil.GetCurrentDateTime();               
                ovoterList_Copy.isActive = true;
            ovoterList_Copy.mobileNo = null;
            ovoterList_Copy.voterAadharNumber = null;
            ovoterList_Copy.voterIDIssueDate = null;
            ovoterList_Copy.voterImageURL = null;               
            
            int result;
            try
            {
                uow.voterList_.Add(ovoterList_Copy);
                result = 1;
            }

            catch (Exception e)
            {
                result = 0;
            }
            return result;
        }
        public IEnumerable<sp_GetAllDataEntryOperators_Result> getAllDataEntryOperators()
        {
            var result = uow.getAllDataEntryOperators_.SQLQuery<sp_GetAllDataEntryOperators_Result>("sp_GetAllDataEntryOperators").ToList();
            return result;
        }

        public IEnumerable<sp_GetVoters_List_Result> getVoters(string voterID, string date, string userID)
        {
            var voterID_ = new SqlParameter("@VoterIdNumber", SqlString.Null);
            var userID_ = new SqlParameter("@createdBy", userID);
            var date_ = new SqlParameter("@createdDate", SqlString.Null);
            if (voterID != "")
            {
                voterID_ = new SqlParameter("@VoterIdNumber", voterID);
            }
            if (date != "")
            {
                date_ = new SqlParameter("@createdDate", date);
            }
            var result = uow.getVoters_.SQLQuery<sp_GetVoters_List_Result>("sp_GetVoters_List @VoterIdNumber,@createdBy,@createdDate", voterID_, userID_, date_).ToList();
            return result;
        }
        public voterList getVoterByID(long voterID)
        {
            var voterList_ = uow.voterList_.GetByID(voterID);
            return voterList_;
        }

        public int UpdateVoter(voterList ovoterList_Copy)
        {

           
            ovoterList_Copy.modifiedBy = Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));           
            ovoterList_Copy.dataIsUpdated = BaseUtil.GetCurrentDateTime();
            ovoterList_Copy.isActive = true;
            ovoterList_Copy.mobileNo = null;
            ovoterList_Copy.voterAadharNumber = null;
            ovoterList_Copy.voterIDIssueDate = null;
            ovoterList_Copy.voterImageURL = null;

            int result;
            try
            {
                uow.voterList_.Update(ovoterList_Copy);
                result = 1;
            }

            catch (Exception e)
            {
                result = 0;
            }
            return result;
        }
    }
}