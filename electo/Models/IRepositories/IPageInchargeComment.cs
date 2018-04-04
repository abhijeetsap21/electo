using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface IPageInchargeComment
    {
        #region HR IService Function
        //20180312
        //private Repositories<sp_PageInchargeComments_ByCampaignId_Result> GetByCampaignId { get; set; }
        IEnumerable<sp_PageInchargeComments_ByCampaignId_Result> GetByCampaignId(long BoothInchargeId, long CampaignId);
        #endregion
    }
}
