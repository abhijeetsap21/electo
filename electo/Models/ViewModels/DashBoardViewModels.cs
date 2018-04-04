using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using electo.Models.SP_Models;
using static electo.Models.SP_Models.StoredProcedureModels;

namespace electo.Models.ViewModels
{
    public class DashBoardViewModels
    {
        public IEnumerable<sp_GetNewCampaignRequests_Result> newCampaignRequests { get; set; }
        public IEnumerable<sp_GetNewEnquiries_Result> getNewEnquiries { get; set; }
        public IEnumerable<sp_GetRunningCampaigns_Result> getRunningCampaigns { get; set; }
        public IEnumerable<sp_GetUpcomingElections_Result> getUpcomingElections { get; set; }
    }
}