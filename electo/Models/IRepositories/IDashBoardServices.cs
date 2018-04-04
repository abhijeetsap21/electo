using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static electo.Models.SP_Models.StoredProcedureModels;

namespace electo.Models.IRepositories
{
    interface IDashBoardServices
    {
        IEnumerable<sp_GetNewCampaignRequests_Result> GetNewCampaignRequests_Result();
        IEnumerable<sp_GetNewEnquiries_Result> GetNewEnquiries_Result();
        IEnumerable<sp_GetRunningCampaigns_Result> GetRunningCampaigns_Result();
        IEnumerable<sp_GetUpcomingElections_Result> GetUpcomingElections_Result();
    }
}
