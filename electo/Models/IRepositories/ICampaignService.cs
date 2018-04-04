using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static electo.Models.SP_Models.StoredProcedureModels;

namespace electo.Models.IRepositories
{
    interface ICampaignService
    {
        IEnumerable<sp_SearchRunningCampaigns_Result> SearchRunningCampaigns_Result(string electionTypeNAME, string electionYear, string politicalPartyName, string campaignName);
        campaign get(long cID);
        campaign _save(campaign _campaign);
        IEnumerable<sp_SearchCampaignPrices_Result> sp_SearchCampaignPrices_Result(string electionTypeNAME, string year, bool isActive);
        campaignPrice getCampaign(int ID);      
        int createCampaignPrice(campaignPrice newCmpPrice_);
        IEnumerable<campaign> getCompaignListByElectionIDandCreatedByID(Int64 createdBy, int electionTypeID);
        IEnumerable<campaignPrice> getAllPrices(int electionTypeID);
        void createCampaign(campaign _campaign);
        IEnumerable<campaign> getMyCampaigns(int volunteerID);
        IEnumerable<sp_GetVolunteers_Result> getVolunteers(string cmpID,string pID, string stateID, string lkID, string vsID);
        IEnumerable<userType> get();
        int createVolunteerRelationship(string usertype, string vID, string cID);
        sp_CheckUserInCampaign_Result checkUser(long volunteerID,long campaignID);       
        IEnumerable<sp_getAreaListByCampignID_Result> getAreaListByCampignID(long cmpID);
        int assignPageInchargeArea(PageInchargeAssignAreaviewmodel _obj);        
        IEnumerable<sp_GetAllSectionInchargeByCampaign_Result> getAllSectionInchargeByCampaign (long cmpID );
        IEnumerable<sp_getAllRelationshipsInCampaignByUserType_Result_> getAllRelationshipsInCampaignByUserType(string cmpID, string userTypeID);

        #region HR IService Function
        IEnumerable<sp_Campaigns_GetAll_Result> GetAll();
        sp_Campaigns_GetById_Result GetById(long Id);
        IEnumerable<sp_Campaigns_GetByElectionTypeId_Result> GetByElectionTypeId(long Id);
        IEnumerable<sp_Campaigns_GetByElectionId_Result> GetByElectionId(long Id);
        IEnumerable<sp_Campaigns_GetByLokSabhaConstituencyId_Result> GetByLokSabhaConstituencyId(long Id);
        IEnumerable<sp_Campaigns_GetByPoliticalPartyId_Result> GetByPoliticalPartyId(long Id);
        IEnumerable<sp_Campaigns_GetByVidhanSabhaConstituencyId_Result> GetByVidhanSabhaConstituencyId(long Id);
        IEnumerable<sp_Campaigns_GetByVolunteerId_Result> GetByVolunteerId(long Id);
        IEnumerable<sp_Campaigns_GetByWardId_Result> GetByWardId(long Id);
        #endregion
        int DeletecampaignVolunteerRelationShip(Int64 cID, Int64 vID);
    }
}
