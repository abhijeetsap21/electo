using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace electo.Models.Repositories
{
    public class PageInchargeComment : IPageInchargeComment
    {
        private readonly UnitOfWork uow;

        public PageInchargeComment()
        {
            uow = new Models.Repositories.UnitOfWork();
        }
        #region HR Service Function
        //20180312
        //IEnumerable<sp_PageInchargeComments_ByCampaignId_Result> GetByCampaignId(long Id);
        public IEnumerable<sp_PageInchargeComments_ByCampaignId_Result> GetByCampaignId(long _boothInchargeId, long _campaignId)
        {
            var BoothInchargeId = new SqlParameter("@BoothInchargeId", _boothInchargeId);
            var CampaignId = new SqlParameter("@CampaignId", _campaignId);
            var objPageInchargeCommentList = uow.sp_PageInchargeComments_ByCampaignId_Result_.SQLQuery<sp_PageInchargeComments_ByCampaignId_Result>("sp_PageInchargeComments_ByCampaignId @CampaignId,@BoothInchargeId",  CampaignId, BoothInchargeId);
            if (objPageInchargeCommentList != null)
            {
                return objPageInchargeCommentList;
            }
            return null;
        }
        #endregion
    }
}