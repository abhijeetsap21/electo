using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace electo.Models.Repositories
{
    public class SurveyServices :ISurveyServices
    {
        private readonly UnitOfWork uow;
        public SurveyServices()
        {
            uow = new UnitOfWork();
        }
        #region HR Service Function
        public IEnumerable<sp_Survey_GetAll_Result> GetAll()
        {
            var objSurveyList = uow.sp_Survey_GetAll_Result_.SQLQuery<sp_Survey_GetAll_Result>("sp_Survey_GetAll").ToList();
            if (objSurveyList != null)
            {
                return objSurveyList;
            }
            return null;
        }
        public IEnumerable<sp_Survey_GetByCampaignId_Result> GetByCampaignId(long Id)
        {
            var CampaignId = new SqlParameter("@CampaignId", Id);
            var objSurveyList = uow.sp_Survey_GetByCampaignId_Result_.SQLQuery<sp_Survey_GetByCampaignId_Result>("sp_Survey_GetByCampaignId @CampaignId", CampaignId).ToList();
            if (objSurveyList != null)
            {
                return objSurveyList;
            }
            return null;
        }
        #endregion

        public int create(survey osurvey)
        {
            int result = 0;
            osurvey.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            osurvey.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            osurvey.dataIsCreated = BaseUtil.GetCurrentDateTime();
            osurvey.dataIsUpdated = BaseUtil.GetCurrentDateTime();
            osurvey.isDelete = false;
            osurvey.campaignID= Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.campaignID.ToString()));
            try
            {
                uow.survey_.Add(osurvey);
                result = 1;
            }
            catch { }
            return result;
        }
    }
}