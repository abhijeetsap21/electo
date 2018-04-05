using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using electo.Models.IRepositories;
using static electo.Models.SP_Models.StoredProcedureModels;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace electo.Models.Repositories
{
    public class CampaignService : ICampaignService
    {
        private readonly UnitOfWork uow;
        public CampaignService()
        {
            uow = new UnitOfWork();
        }
        public IEnumerable<sp_SearchRunningCampaigns_Result> SearchRunningCampaigns_Result(string electionTypeNAME, string electionYear, string politicalPartyName, string campaignName)
        {
            var PartyName_ = new SqlParameter("@partyname", SqlString.Null);
            var campaignname_ = new SqlParameter("@campaignname", SqlString.Null);

            if (politicalPartyName == "")
            {
                PartyName_ = new SqlParameter("@partyname", SqlString.Null);
            }
            else
            {
               PartyName_ = new SqlParameter("@partyname", politicalPartyName);
            }
            if (campaignName == "")
            {
                campaignname_ = new SqlParameter("@campaignname", SqlString.Null);
            }
            else
            {
                campaignname_ = new SqlParameter("@campaignname", campaignName);
            }


            var ElectionType_ = new SqlParameter("@electiontype", electionTypeNAME);
                        
            var  year_ = new SqlParameter("@year", electionYear);            
            var RunningCampaigns_Result = uow.RunningCampaigns_Result.SQLQuery<sp_SearchRunningCampaigns_Result>("sp_SearchRunningCampaigns @electiontype,@partyname,@year,@campaignname", ElectionType_, PartyName_, year_, campaignname_).ToList();
            return RunningCampaigns_Result;
        }

        public IEnumerable<campaign> getCampaignNames(string prefix)
        {
            // var names = uow.getCampaignNames_.Find(prefix)        
            electoEntities db = new electoEntities();
            var names = db.campaigns.Where(e => e.campaignName.StartsWith(prefix)).ToList();
            return names;               
                
        }
        public IEnumerable<campaign> getCompaignListByElectionIDandCreatedByID(Int64 createdBy)
        {
            var campaignList = uow.GetDetails_.Find(e => e.createdBy == createdBy ).ToList();
            return campaignList;
        }

        public campaign get(long cID)
        {
            var campaignDetails = uow.GetDetails_.GetByID(cID);
            return campaignDetails; 
        }

        public campaign _save(campaign _campaign)
        {
            _campaign.dataIsUpdated = BaseUtil.GetCurrentDateTime();
            _campaign.modifiedBy =Convert.ToInt64( BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            uow.SaveDetails.Update(_campaign);
            return _campaign;
        }


        public IEnumerable<sp_SearchCampaignPrices_Result> sp_SearchCampaignPrices_Result(string electionTypeNAME, string year, bool isActive)
        {          
                                   
            var ElectionType_ = new SqlParameter("@electiontype", electionTypeNAME);
            var year_ = new SqlParameter("@year", year);
            var isActive_ = new SqlParameter("@isActive", isActive);
            
            var CampaignPrices_Result = uow.sp_SearchCampaignPrices_Result_.SQLQuery<sp_SearchCampaignPrices_Result>("sp_SearchCampaignPrices @electiontype,@year,@isActive", ElectionType_, year_, isActive_).ToList();
            return CampaignPrices_Result;
        }

        public campaignPrice getCampaign(int ID)
        {
            var priceDetails = uow._getPriceDetails_.GetByID(ID);
            return priceDetails;
        }      

        public int createCampaignPrice(campaignPrice newCmpPrice_)
        {
            var electionTypeID_ = new SqlParameter("@electiontype", newCmpPrice_.electionTypeID);
            var year_ = new SqlParameter("@year", newCmpPrice_.year);
            var price_ = new SqlParameter("@price", newCmpPrice_.price);
            var dataIsCreated_ = new SqlParameter("@dataIsCreated", newCmpPrice_.dataIsCreated);
            var dataIsUpdated_ = new SqlParameter("@dataIsUpdated", newCmpPrice_.dataIsUpdated);
            var createdBy_ = new SqlParameter("@createdBy", newCmpPrice_.createdBy);
            var modifiedBy_ = new SqlParameter("@modifiedBy", newCmpPrice_.modifiedBy);
            var isActive_ = new SqlParameter("@isActive", newCmpPrice_.isActive);         

            int result = 0;
            try
            {
                result = uow.newCampaignPrice_.SQLQuery<int>("sp_AddNewCampaignPrice @electiontype, @year, @price, @dataIsCreated, @dataIsUpdated, @createdBy,  @modifiedBy, @isActive",
                     electionTypeID_, year_, price_, dataIsCreated_, dataIsUpdated_, createdBy_, modifiedBy_, isActive_).FirstOrDefault();
            }
            catch (Exception e)
            {
            }
            return result;

        }

        public IEnumerable<campaignPrice> getAllPrices(int electionTypeID)
        {
            var result = uow.getAllPrices_.Find(e => e.electionTypeID == electionTypeID);
            return result;
        }

        public void createCampaign(campaign _campaign)
        {

            uow.createCampaign_.Add(_campaign);
        }
        public IEnumerable<campaign> getMyCampaigns(int volunteerID)
        {
            var result = uow.getMyCampaigns_.Find(e => e.volunteerID == volunteerID);
            return result;
        }

        public IEnumerable<sp_GetVolunteers_Result> getVolunteers(string cmpID, string pID, string stateID, string lkID, string vsID)
        {
            var politicalParty_ = new SqlParameter("@politicalParty", 1);
            var stateID_ = new SqlParameter("@stateID", SqlString.Null);
            var vsID_ = new SqlParameter("@vidhanSabhaConstituencyID", SqlString.Null);
            var lkID_ = new SqlParameter("@lokSabhaConstituencyID", SqlString.Null);
            var cmpID_ = new SqlParameter("@campaignID",cmpID);

            if (stateID == "")
            {
                stateID_ = new SqlParameter("@stateID", SqlString.Null);
            }
            else
            {
                stateID_ = new SqlParameter("@stateID", stateID);
            }
            if (lkID == "")
            {
                lkID_ = new SqlParameter("@lokSabhaConstituencyID", SqlString.Null);
            }
            else
            {
                lkID_ = new SqlParameter("@lokSabhaConstituencyID", lkID);
            }
            if (vsID == "")
            {
                vsID_ = new SqlParameter("@vidhanSabhaConstituencyID", SqlString.Null);
            }
            else
            {
                vsID_ = new SqlParameter("@vidhanSabhaConstituencyID", vsID);
            }
            var result = uow.Assign_.SQLQuery<sp_GetVolunteers_Result>("sp_GetVolunteers @politicalParty,@stateID,@vidhanSabhaConstituencyID,@lokSabhaConstituencyID,@campaignID", politicalParty_, stateID_, vsID_, lkID_, cmpID_).ToList();
            return result;
        }

        public IEnumerable<userType> get()
        {
            var result = uow.get_.GetAll();
            return result;

        }

       
        public sp_CheckUserInCampaign_Result checkUser(long volunteerID,long campaignID)
        {
            var volunteerID_ = new SqlParameter("@volunteerID", volunteerID);
            var campaignID_ = new SqlParameter("@campaignID", campaignID);
            var result = uow.checkUser_.SQLQuery<sp_CheckUserInCampaign_Result>("sp_CheckUserInCampaign @volunteerID,@campaignID", volunteerID_, campaignID_).FirstOrDefault();
            return result;
        }
        

        public IEnumerable<sp_getAreaListByCampignID_Result> getAreaListByCampignID(long cmpID)
        {
            var cmpID_ = new SqlParameter("@CampignID", cmpID);
            var result = uow.getAreaListByCampignID_.SQLQuery<sp_getAreaListByCampignID_Result>("sp_getAreaListByCampignID @CampignID", cmpID_).ToList();
            return result;

        }

        public int assignPageInchargeArea(PageInchargeAssignAreaviewmodel _obj)   
        {
            int result;

             pageInchargeAssignedArea opollingBooth_andInchargRelationship = new pageInchargeAssignedArea();
            opollingBooth_andInchargRelationship.campaignID = _obj.campaignID;
            opollingBooth_andInchargRelationship.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            opollingBooth_andInchargRelationship.dataIsCreated = BaseUtil.GetCurrentDateTime();
            opollingBooth_andInchargRelationship.dataIsUpdated = BaseUtil.GetCurrentDateTime();
            opollingBooth_andInchargRelationship.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            opollingBooth_andInchargRelationship.areaID = _obj.areaID;
            opollingBooth_andInchargRelationship.volunteerID = _obj.volunteerID;
            opollingBooth_andInchargRelationship.isActive = true;
            try
            {
                uow.assignPageInchargeArea_.Add(opollingBooth_andInchargRelationship);
                result = 1;
            }

            catch (Exception e)
            {
                result = 0;
            }
            return result;
        }

        public IEnumerable<sp_GetAllSectionInchargeByCampaign_Result> getAllSectionInchargeByCampaign(long cmpID)
        {
            var cmpID_ = new SqlParameter("@cmpID", cmpID);
            var result = uow.getAllSectionInchargeByCampaign_.SQLQuery<sp_GetAllSectionInchargeByCampaign_Result>("sp_GetAllSectionInchargeByCampaign @cmpID", cmpID_).ToList();
            return result;
        }

        #region HR Service Function
        public IEnumerable<sp_Campaigns_GetAll_Result> GetAll()
        {
            var objCampaignList = uow.sp_Campaigns_GetAll_Result_.SQLQuery<sp_Campaigns_GetAll_Result>("sp_Campaigns_GetAll");
            if (objCampaignList != null)
            {
                return objCampaignList;
            }
            return null;
        }

        public sp_Campaigns_GetById_Result GetById(long Id)
        {
            var CampaignId = new SqlParameter("@CampaignId", Id);

            var objCampaign = uow.sp_Campaigns_GetById_Result_.SQLQuery<sp_Campaigns_GetById_Result>("sp_Campaigns_GetById @CampaignId", CampaignId).SingleOrDefault();

            if (objCampaign != null)
            {
                return objCampaign;
            }
            return null;
        }

        public IEnumerable<sp_Campaigns_GetByElectionTypeId_Result> GetByElectionTypeId(long Id)
        {
            var ElectionTypeId = new SqlParameter("@ElectionTypeId", Id);

            var objCampaignList = uow.sp_Campaigns_GetByElectionTypeId_Result_.SQLQuery<sp_Campaigns_GetByElectionTypeId_Result>("sp_Campaigns_GetByElectionTypeId @ElectionTypeId", ElectionTypeId).ToList();

            if (objCampaignList != null)
            {
                return objCampaignList;
            }
            return null;
        }

        public IEnumerable<sp_Campaigns_GetByElectionId_Result> GetByElectionId(long Id)
        {
            var ElectionId = new SqlParameter("@ElectionId", Id);

            var objCampaignList = uow.sp_Campaigns_GetByElectionId_Result_.SQLQuery<sp_Campaigns_GetByElectionId_Result>("sp_Campaigns_GetByElectionId @ElectionId", ElectionId).ToList();

            if (objCampaignList != null)
            {
                return objCampaignList;
            }
            return null;
        }

        public IEnumerable<sp_Campaigns_GetByLokSabhaConstituencyId_Result> GetByLokSabhaConstituencyId(long Id)
        {
            var LokSabhaConstituencyId = new SqlParameter("@LokSabhaConstituencyId", Id);

            var objCampaignList = uow._getDetails.SQLQuery<sp_Campaigns_GetByLokSabhaConstituencyId_Result>("sp_Campaigns_GetByLokSabhaConstituencyId @LokSabhaConstituencyId", LokSabhaConstituencyId).ToList();

            if (objCampaignList != null)
            {
                return objCampaignList;
            }
            return null;
        }

        public IEnumerable<sp_Campaigns_GetByPoliticalPartyId_Result> GetByPoliticalPartyId(long Id)
        {
            var PoliticalPartyId = new SqlParameter("@PoliticalPartyId", Id);

            var objCampaignList = uow.sp_Campaigns_GetByPoliticalPartyId_Result_.SQLQuery<sp_Campaigns_GetByPoliticalPartyId_Result>("sp_Campaigns_GetByPoliticalPartyId @PoliticalPartyId", PoliticalPartyId).ToList();

            if (objCampaignList != null)
            {
                return objCampaignList;
            }
            return null;
        }

        public IEnumerable<sp_Campaigns_GetByVidhanSabhaConstituencyId_Result> GetByVidhanSabhaConstituencyId(long Id)
        {
            var VidhanSabhaConstituencyId = new SqlParameter("@VidhanSabhaConstituencyId", Id);

            var objCampaignList = uow.sp_Campaigns_GetByVidhanSabhaConstituencyId_Result_.SQLQuery<sp_Campaigns_GetByVidhanSabhaConstituencyId_Result>("sp_Campaigns_GetByVidhanSabhaConstituencyId @VidhanSabhaConstituencyId", VidhanSabhaConstituencyId).ToList();

            if (objCampaignList != null)
            {
                return objCampaignList;
            }
            return null;
        }

        public IEnumerable<sp_Campaigns_GetByVolunteerId_Result> GetByVolunteerId(long Id)
        {
            var VolunteerId = new SqlParameter("@VolunteerId", Id);

            var objCampaignList = uow.sp_Campaigns_GetByVolunteerId_Result_.SQLQuery<sp_Campaigns_GetByVolunteerId_Result>("sp_Campaigns_GetByVolunteerId @VolunteerId", VolunteerId).ToList();

            if (objCampaignList != null)
            {
                return objCampaignList;
            }
            return null;
        }

        public IEnumerable<sp_Campaigns_GetByWardId_Result> GetByWardId(long Id)
        {
            var WardId = new SqlParameter("@WardId", Id);

            var objCampaignList = uow.sp_Campaigns_GetByWardId_Result_.SQLQuery<sp_Campaigns_GetByWardId_Result>("sp_Campaigns_GetByWardId @WardId", WardId).ToList();

            if (objCampaignList != null)
            {
                return objCampaignList;
            }
            return null;
        }
        #endregion

        public int createVolunteerRelationship(string usertype, string vID, string cID)
        {
         int result=0;
        string sqlQuery = "sp_assignRelationshipBetweenVolunteerANDCampaign @campaignID='" + cID + "', @volunteerID='" + vID + "'," +
                                                                                "@dataIsUpdated='" + BaseUtil.GetCurrentDateTime() + "'," +
                                                                                 "@modifiedBy='" + Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString())) + "',@userTypeID='" + usertype + "', @insert=1";

            try
            {
                result = uow.assignPageInchargeArea_.SQLQuery<int>(sqlQuery).FirstOrDefault();

            }
            catch (Exception e)
            {
                result = 0;
            }
            return result;

        }


        public int DeletecampaignVolunteerRelationShip(Int64 cID, Int64 vID)
        {
            int result = 0;
            string sqlQuery = "sp_assignRelationshipBetweenVolunteerANDCampaign @campaignID='" + cID + "', @volunteerID='" + vID + "'";

            try
            {
                result = uow.assignPageInchargeArea_.SQLQuery<int>(sqlQuery).FirstOrDefault();

            }
            catch (Exception e)
            {
                result = 0;
            }
            return result;

        }

        public IEnumerable<sp_getAllRelationshipsInCampaignByUserType_Result_> getAllRelationshipsInCampaignByUserType(string cmpID, string userTypeID)
        {
            var userTypeID_ = new SqlParameter("@userTypeID", userTypeID);
            var cmpID_ = new SqlParameter("@cmpID", cmpID);
            var result = uow.getAllRelationshipsInCampaignByUserType_.SQLQuery<sp_getAllRelationshipsInCampaignByUserType_Result_>("sp_getAllRelationshipsInCampaignByUserType @userTypeID ,@cmpID", userTypeID_, cmpID_).ToList();
            return result;

        }
    }
}