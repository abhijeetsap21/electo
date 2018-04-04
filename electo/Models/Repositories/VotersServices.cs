using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using electo.Models.SP_Models;
namespace electo.Models.Repositories
{
    public class VotersServices : IVotersServices
    {
        private readonly UnitOfWork uow;
        public VotersServices()
        {
            uow = new UnitOfWork();
        }
        #region HR Service Function
        public IEnumerable<sp_Voters_GetAll_Result> GetAll()
        {
            var objVotersList = uow.sp_Voters_GetAll_Result_.SQLQuery<sp_Voters_GetAll_Result>("sp_Voters_GetAll").ToList();
            if (objVotersList != null)
            {
                return objVotersList;
            }
            return null;
        }
        public sp_Voters_GetById_Result GetById(long Id)
        {
            var VoterId = new SqlParameter("@VoterId", Id);
            var objVoter = uow.sp_Voters_GetById_Result_.SQLQuery<sp_Voters_GetById_Result>("sp_Voters_GetById @VoterId", VoterId).SingleOrDefault();
            if (objVoter != null)
            {
                return objVoter;
            }
            return null;
        }
        //IEnumerable<sp_Voters_GetByPageInchargeId_Result> GetByPageInchargeId(long Id);
        public IEnumerable<sp_Voters_GetByPageInchargeId_Result> GetByPageInchargeId(long Id)
        {
            var PageInchargeId = new SqlParameter("@PageInchargeId", Id);
            var objVoterList = uow.sp_Voters_GetByPageInchargeId_Result_.SQLQuery<sp_Voters_GetByPageInchargeId_Result>("sp_Voters_GetByPageInchargeId @PageInchargeId", PageInchargeId).ToList();
            if (objVoterList != null)
            {
                return objVoterList;
            }
            return null;
        }

        //20180228
        //IEnumerable<sp_Voters_GetByStateId_Result> GetByStateId(long Id);
        public IEnumerable<sp_Voters_GetByStateId_Result> GetByStateId(long Id)
        {
            var StateId = new SqlParameter("@StateId", Id);
            var objVoterList = uow.sp_Voters_GetByStateId_Result_.SQLQuery<sp_Voters_GetByStateId_Result>("sp_Voters_GetByStateId @StateId", StateId).ToList();
            if (objVoterList != null)
            {
                return objVoterList;
            }
            return null;
        }
        //IEnumerable<sp_Voters_GetByAreaId_Result> GetByAreaId(long Id);
        public IEnumerable<sp_Voters_GetByAreaId_Result> GetByAreaId(long Id)
        {
            var AreaId = new SqlParameter("@AreaId", Id);
            var objVoterList = uow.sp_Voters_GetByAreaId_Result_.SQLQuery<sp_Voters_GetByAreaId_Result>("sp_Voters_GetByAreaId @AreaId", AreaId).ToList();
            if (objVoterList != null)
            {
                return objVoterList;
            }
            return null;
        }
        //IEnumerable<sp_Voters_GetByVidhanSabhaConstituencyId_Result> GetByVidhanSabhaConstituencyId(long Id);
        public IEnumerable<sp_Voters_GetByVidhanSabhaConstituencyId_Result> GetByVidhanSabhaConstituencyId(long Id)
        {
            var VidhanSabhaConstituencyId = new SqlParameter("@VidhanSabhaConstituencyId", Id);
            var objVoterList = uow.sp_Voters_GetByVidhanSabhaConstituencyId_Result_.SQLQuery<sp_Voters_GetByVidhanSabhaConstituencyId_Result>("sp_Voters_GetByVidhanSabhaConstituencyId @VidhanSabhaConstituencyId", VidhanSabhaConstituencyId).ToList();
            if (objVoterList != null)
            {
                return objVoterList;
            }
            return null;
        }
        //IEnumerable<sp_Voters_GetByLokSabhaConstituencyId_Result> GetByLokSabhaConstituencyId(long Id);
        public IEnumerable<sp_Voters_GetByLokSabhaConstituencyId_Result> GetByLokSabhaConstituencyId(long Id)
        {
            var LokSabhaConstituencyId = new SqlParameter("@LokSabhaConstituencyId", Id);
            var objVoterList = uow.sp_Voters_GetByLokSabhaConstituencyId_Result_.SQLQuery<sp_Voters_GetByLokSabhaConstituencyId_Result>("sp_Voters_GetByLokSabhaConstituencyId @LokSabhaConstituencyId", LokSabhaConstituencyId).ToList();
            if (objVoterList != null)
            {
                return objVoterList;
            }
            return null;
        }
        //IEnumerable<sp_Voters_GetByWardId_Result> GetByWardId(long Id);
        public IEnumerable<sp_Voters_GetByWardId_Result> GetByWardId(long Id)
        {
            var WardId = new SqlParameter("@WardId", Id);
            var objVoterList = uow.sp_Voters_GetByWardId_Result_.SQLQuery<sp_Voters_GetByWardId_Result>("sp_Voters_GetByWardId @WardId", WardId).ToList();
            if (objVoterList != null)
            {
                return objVoterList;
            }
            return null;
        }
        //20180313
        //string DeleteVoter(long VoterId);
        public string DeleteVoter(long Id)
        {
            string returnResult = string.Empty;
            int result = 0;

            var VoterId = new SqlParameter("@VoterId", Id);
            try
            {
                result = uow.sp_Voters_DeleteByVoterId_.SQLQuery<int>("sp_Voters_DeleteByVoterId @VoterId", VoterId).FirstOrDefault();
                if (result == 1)
                {
                    returnResult = "Voter data deleted successfully.";
                }
                else
                {
                    returnResult = "Error in deleting record. Try again.";
                }
            }
            catch (Exception e)
            {
            }
            return returnResult;
        }
        //20180314
        //int UpdateDetail(sp_Voters_UpdateDetail businessObject);
        public int UpdateDetail(sp_Voters_UpdateDetail businessObject)
        {
            int result = 0;
            var CampaignId = new SqlParameter("@CampaignId", businessObject.CampaignId);
            var PageInchargeId = new SqlParameter("@PageInchargeId", businessObject.PageInchargeId);
            var VoterId = new SqlParameter("@VoterId", businessObject.VoterId);
            var VoterName = new SqlParameter("@VoterName", businessObject.VoterName);
            var VoterLastName = new SqlParameter("@VoterLastName", businessObject.VoterName);
            var Father_HusbandName = new SqlParameter("@Father_HusbandName", businessObject.Father_HusbandName);
            var Gender = new SqlParameter("@GenderId", businessObject.Gender);
            var DOB = new SqlParameter("@DOB", businessObject.DOB);
            var Address = new SqlParameter("@Address", businessObject.Address);
            var Phone = new SqlParameter("@Phone", businessObject.Phone);
            var ChangeType = new SqlParameter("@ChangeType", businessObject.ChangeType);
            var CommentDetail = new SqlParameter("@CommentDetail", businessObject.CommentDetail);
            var latitude= new SqlParameter("@latitude", businessObject.latitude);
            var longitude = new SqlParameter("@longitude", businessObject.longitude);
            var dataIsCreated = new SqlParameter("@dataIsCreated", BaseUtil.GetCurrentDateTime());
            var volunteerID = new SqlParameter("@volunteerID", businessObject.volunteerID);
            var plotNo =new SqlParameter("@plotNo", businessObject.plotNo);
            try
            {
                result = uow.sp_Voters_UpdateDetail_.SQLQuery<int>("sp_Voters_UpdateDetail @CampaignId,@PageInchargeId,@VoterId,@VoterName,@VoterLastName,@Father_HusbandName,@GenderId,@DOB,@Address,@Phone,@ChangeType,@CommentDetail,@latitude, @longitude, @dataIsCreated,@volunteerID,@plotNo", CampaignId, PageInchargeId, VoterId, VoterName, VoterLastName, Father_HusbandName, Gender, DOB, Address, Phone, ChangeType, CommentDetail, latitude, longitude, dataIsCreated,volunteerID, plotNo).FirstOrDefault();
                return result;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        //20180319
        public int VerifyVoterByPageIncharge(sp_Voters_VerifyByPageIncharge businessObject)
        {
            int result = 0;
            string query = "sp_Voters_VerifyByPageIncharge   @CampaignId ='" + businessObject.CampaignId + "'" +
                                                 ",@PageInchargeId='" + businessObject.PageInchargeId + "'" +
                                                 ",@VoterId='" + businessObject.VoterId + "'" +
                                                 ",@latitude='" + businessObject.latitude + "'" +
                                                 ",@longitude='" + businessObject.longitude + "'" +
                                                 ", @dataIsCreated ='" +BaseUtil.GetCurrentDateTime() + "'";
            try
            {
                result = uow.sp_Voters_UpdateDetail_.SQLQuery<int>(query).FirstOrDefault();
               
            }
            catch { }
            return result;
        }
        //20180322
        //IEnumerable<sp_SectionIncharge_GetAllByBoothIncharge_Result> GetAllByBoothIncharge(long CampaignId, long BoothInchargeId);
        public IEnumerable<sp_SectionIncharge_GetAllByBoothIncharge_Result> GetAllByBoothIncharge(long CampaignId, long BoothInchargeId)
        {
            var _CampaignId = new SqlParameter("@CampaignId", CampaignId);
            var _BoothInchargeId = new SqlParameter("@BoothInchargeId", BoothInchargeId);

            var objVoterList = uow.sp_SectionIncharge_GetAllByBoothIncharge_Result_.SQLQuery<sp_SectionIncharge_GetAllByBoothIncharge_Result>("sp_SectionIncharge_GetAllByBoothIncharge @CampaignId,@BoothInchargeId", _CampaignId, _BoothInchargeId).ToList();
            if (objVoterList != null)
            {
                return objVoterList;
            }
            return null;
        }
        #endregion

        public IEnumerable<sp_getPageInchargeLocation_Result> getPageInchargeLocation(long CampaignId, long PageInchargeId, DateTime VisitedDate)
        {
            var _CampaignId = new SqlParameter("@CampaignId", CampaignId);
            var _PageInchargeId = new SqlParameter("@PageInchargeId", PageInchargeId);
            var _VisitedDate = new SqlParameter("@dataIsCreated", VisitedDate);
            var PageInchargeLocation_ = uow.sp_SectionIncharge_GetAllByBoothIncharge_Result_.SQLQuery<sp_getPageInchargeLocation_Result>("sp_getPageInchargeLocation @CampaignId,@PageInchargeId,@dataIsCreated", _CampaignId, _PageInchargeId, _VisitedDate).ToList();
            if (PageInchargeLocation_ != null)
            {
                return PageInchargeLocation_;
            }
            return null;
        }
    }
}