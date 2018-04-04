
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using electo.Models.SP_Models;
namespace electo.Models.IRepositories
{
    interface IVotersServices
    {
        #region HR IService Function
        IEnumerable<sp_Voters_GetAll_Result> GetAll ();
        sp_Voters_GetById_Result GetById (long Id);
        IEnumerable<sp_Voters_GetByPageInchargeId_Result> GetByPageInchargeId(long Id);
        
        //20180228
        IEnumerable<sp_Voters_GetByStateId_Result> GetByStateId(long Id);
        IEnumerable<sp_Voters_GetByAreaId_Result> GetByAreaId(long Id);
        IEnumerable<sp_Voters_GetByVidhanSabhaConstituencyId_Result> GetByVidhanSabhaConstituencyId(long Id);
        IEnumerable<sp_Voters_GetByLokSabhaConstituencyId_Result> GetByLokSabhaConstituencyId(long Id);
        IEnumerable<sp_Voters_GetByWardId_Result> GetByWardId(long Id);

        //20180313
        //public Repositories<sp_Voters_DeleteByVoterId> sp_Voters_DeleteByVoterId_
        string DeleteVoter(long Id);
        //20180314
        int UpdateDetail(sp_Voters_UpdateDetail businessObject);

        //20180319
        int VerifyVoterByPageIncharge(sp_Voters_VerifyByPageIncharge businessObject);

        //20180322
        //public Repositories<sp_SectionIncharge_GetAllByBoothIncharge_Result> sp_SectionIncharge_GetAllByBoothIncharge_Result_
        IEnumerable<sp_SectionIncharge_GetAllByBoothIncharge_Result> GetAllByBoothIncharge(long CampaignId, long BoothInchargeId);
        #endregion
        IEnumerable<sp_getPageInchargeLocation_Result> getPageInchargeLocation(long CampaignId, long PageInchargeId, DateTime VisitedDate);
    }
}
