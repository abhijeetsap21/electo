using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static electo.Models.SP_Models.StoredProcedureModels;

namespace electo.Models.Repositories
{
    public class DashBoardServices : IDashBoardServices
    {
        private readonly UnitOfWork uow;
        public DashBoardServices()
        {
            uow = new UnitOfWork();
        }

        public IEnumerable<sp_GetNewCampaignRequests_Result> GetNewCampaignRequests_Result()
        {
            var GetNewCampaignRequests_Result = uow.getNewCampaignRequests_Result.SQLQuery<sp_GetNewCampaignRequests_Result>("sp_GetNewCampaignRequests");
            return GetNewCampaignRequests_Result;
        }

        public IEnumerable<sp_GetNewEnquiries_Result> GetNewEnquiries_Result()
        {
            var GetRunningCampaigns_Result = uow.getNewCampaignRequests_Result.SQLQuery<sp_GetNewEnquiries_Result>("sp_GetNewEnquiries");
            return GetRunningCampaigns_Result;
        }

        public IEnumerable<sp_GetRunningCampaigns_Result> GetRunningCampaigns_Result()
        {
            var GetRunningCampaigns_Result = uow.getNewCampaignRequests_Result.SQLQuery<sp_GetRunningCampaigns_Result>("sp_GetRunningCampaigns");
            return GetRunningCampaigns_Result;
        }

        public IEnumerable<sp_GetUpcomingElections_Result> GetUpcomingElections_Result()
        {
            var GetUpcomingElections_Result = uow.getNewCampaignRequests_Result.SQLQuery<sp_GetUpcomingElections_Result>("sp_GetUpcomingElections");
            return GetUpcomingElections_Result;
        }
    }
}