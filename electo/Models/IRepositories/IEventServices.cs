using electo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static electo.Models.SP_Models.StoredProcedureModels;

namespace electo.Models.IRepositories
{
    interface IEventServices
    {
        #region HR IService Function
        IEnumerable<sp_Event_GetByCampaignId_Result> GetByCampaignId(long Id);
        IEnumerable<sp_Event_GetByEventTypeId_Result> GetByEventTypeId(long Id);
        IEnumerable<sp_Event_GetByCampaignIdANDEventTypeID_Result> GetByCampaignIdANDEventTypeID(long Id, int EventTypeId);
        #endregion
        int createEvent(sp_createEvent osp_createEvent);
    }
}
