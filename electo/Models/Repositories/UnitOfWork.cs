using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using electo.Models.Repositories;
using electo.WebServicesController;
using static electo.Models.SP_Models.StoredProcedureModels;
using electo.Models.SP_Models;
namespace electo.Models.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly electoEntities _context;

        private Repositories<sp_LoginUser_Result> _loginVolunteerRepository { get; set; }
        private Repositories<sp_GetNewCampaignRequests_Result> _getNewCampaignRequests_Result { get; set; }
        private Repositories<sp_GetUpcomingElections_Result> _getUpcomingElections_Result { get; set; }
        private Repositories<sp_GetRunningCampaigns_Result> _getRunningCampaigns_Result { get; set; }
        private Repositories<sp_GetNewEnquiries_Result> _getNewEnquiries_Result { get; set; }
        private Repositories<electionType> _electionType { get; set; }
        private Repositories<enquiryType> _enquiryType { get; set; }
        private Repositories<sp_electionList_Result> _sp_electionList_Result { get; set; }
        private Repositories<sp_GetRunningCampaigns_Result> _RunningCampaigns_Result { get; set; }
        private Repositories<campaign> _getDetails1 { get; set; }
        private Repositories<campaign> _saveDetails { get; set; }
        private Repositories<campaignPrice> _savePriceDetails { get; set; }
        private Repositories<state> _state { get; set; }
        private Repositories<district> _district { get; set; }
        private Repositories<vidhanSabhaConstituency> _VidhanSabhaConsistuency { get; set; }
        private Repositories<lokSabhaConstituency> _lokSabhaConstituency { get; set; }
        private Repositories<sp_areaList_Result> _sp_areaList_Result { get; set; }
        private Repositories<sp_getVidhanSabhaLsit_Result> _sp_getVidhanSabhaLsit_Result { get; set; }
        private Repositories<sp_pollingBoothList_Result> _sp_pollingBoothList_Result { get; set; }
        private Repositories<sp_GetNewEnquiries_Result> _sp_GetNewEnquiries_Result { get; set; }
        private Repositories<enquiry> _getEnquiryDetails { get; set; }
        private Repositories<enquiry> _saveEnquiryDetails { get; set; }
        private Repositories<eventType> _eventType { get; set; }
        private Repositories<questionType> _questionType { get; set; }
        private Repositories<sp_politicalPartyList_Result> _sp_politicalPartyList_Result { get; set; }
        private Repositories<sp_createParty_Result> _sp_createParty_Result { get; set; }
        private Repositories<campaignPrice> _newCampaignPrice { get; set; }
        private Repositories<sp_SearchCampaignPrices_Result> _sp_SearchCampaignPrices_Result { get; set; }
        private Repositories<campaignPrice> _getPriceDetails { get; set; }
        private Repositories<sp_partyAddressList_Result> _sp_partyAddressList_Result { get; set; }
        private Repositories<politicalParty> _politicalParty { get; set; }
        private Repositories<politicalPartyAddress> _politicalPartyAddress { get; set; }
        private Repositories<loginVolunteer> _loginVolunteer { get; set; }
        private Repositories<userType> _userType { get; set; }
        private Repositories<sp_getVoterDetailsByVoterID_Result> _sp_getVoterDetailsByVoterID_Result { get; set; }
        private Repositories<sp_CreateUser> _sp_CreateUser { get; set; }
        private Repositories<monthName> _monthName { get; set; }
        private Repositories<tblyear> _tblyear { get; set; }
        private Repositories<electionName> _electionName { get; set; }
        private Repositories<municipalCorporationName> _municipalCorporationName { get; set; }
        private Repositories<zoneMunicipality> _zoneMunicipality { get; set; }
        private Repositories<wardConstituency> _wardConstituency { get; set; }
        private Repositories<areaName> _createArea { get; set; }
        private Repositories<pollingBooth> _createPollingBooth { get; set; }
        private Repositories<electionName> _getAllElections { get; set; }
        private Repositories<loginVolunteer> _getUserDetails { get; set; }
        private Repositories<loginVolunteer> _saveUserDetails { get; set; }
        private Repositories<loginVolunteer> _saveLogoutDetails { get; set; }
        private Repositories<campaignPrice> _getAllPrices { get; set; }
        private Repositories<campaign> _createCampaign { get; set; }
        private Repositories<campaign> _getMyCampaigns { get; set; }       
        private Repositories<sp_GetVolunteers_Result> _Assign { get; set; }
        private Repositories<userType> _get { get; set; }
        private Repositories<compaignVolunteerRelationship> _createVolunteerRelationship { get; set; }
        public Repositories<sp_CheckUserInCampaign_Result> _checkUser { get; set; }
        public Repositories<compaignVolunteerRelationship> _updateRelationShip { get; set; }
        public Repositories<news> _createNews { get; set; }
        public Repositories<sp_GetLatestNews_Result> _getNews { get; set; }
        public Repositories<sp_getAreaListByCampignID_Result> _getAreaListByCampignID { get; set; } 
        public Repositories<pageInchargeAssignedArea> _assignPageInchargeArea { get; set; }
        public Repositories<sp_GetAllSectionInchargeByCampaign_Result> _getAllSectionInchargeByCampaign { get; set; }
        public Repositories<sp_getAllRelationshipsInCampaignByUserType_Result_> _getAllRelationshipsInCampaignByUserType { get; set; }
        public Repositories<sp_GetVoters_List_Result> _getVoters { get; set; }
        public Repositories<sp_GetAllEventTypes_Result> _getEventTypes { get; set; }
        public Repositories<surveyRespons> _submitResponse { get; set; }


        private Repositories <language> _language { get; set; }
        private Repositories<sp_getAllParties_NoParams_Result> _sp_getAllParties_NoParams_Result { get; set; }
        private Repositories<survey> _survey { get; set; }
        private Repositories<sp_createSurveyQuestion_Result> _sp_createSurveyQuestion_Result { get; set; }
        private Repositories<sp_createEvent> _sp_createEvent { get; set; }
        private Repositories<Biography_s> _Biography_s { get; set; }
        private Repositories<sp_GetAllDataEntryOperators_Result> _getAllDataEntryOperators { get; set; }
        private Repositories<pollingBooth_andInchargRelationship> _pollingBooth_andInchargRelationship { get; set; }


        #region HR Property 1
        private Repositories<sp_Campaigns_GetAll_Result> _sp_Campaigns_GetAll { get; set; }
        private Repositories<sp_Campaigns_GetByElectionId_Result> _sp_Campaigns_GetByElectionId { get; set; }
        private Repositories<sp_Campaigns_GetByElectionTypeId_Result> _sp_Campaigns_GetByElectionTypeId { get; set; }
        private Repositories<sp_Campaigns_GetById_Result> _sp_Campaigns_GetById { get; set; }
        private Repositories<sp_Campaigns_GetByLokSabhaConstituencyId_Result> _sp_Campaigns_GetByLokSabhaConstituencyId { get; set; }
        private Repositories<sp_Campaigns_GetByPoliticalPartyId_Result> _sp_Campaigns_GetByPoliticalPartyId { get; set; }
        private Repositories<sp_Campaigns_GetByVidhanSabhaConstituencyId_Result> _sp_Campaigns_GetByVidhanSabhaConstituencyId { get; set; }
        private Repositories<sp_Campaigns_GetByVolunteerId_Result> _sp_Campaigns_GetByVolunteerId { get; set; }
        private Repositories<sp_Campaigns_GetByWardId_Result> _sp_Campaigns_GetByWardId { get; set; }
        //20180222
        private Repositories<sp_Area_GetAll_Result> _sp_Area_GetAll { get; set; }
        private Repositories<sp_Area_GetByPageInchargeId_Result> _sp_Area_GetByPageInchargeId { get; set; }
        //private Repositories<sp_Area_GetByVolunteerId_Result> _sp_Area_GetByVolunteerId { get; set; }
        private Repositories<sp_Event_GetByCampaignIdANDEventTypeID_Result> _sp_Event_GetByCampaignId { get; set; }
        private Repositories<sp_Event_GetByEventTypeId_Result> _sp_Event_GetByEventTypeId { get; set; }
        private Repositories<sp_Survey_GetAll_Result> _sp_Survey_GetAll { get; set; }
        private Repositories<sp_Survey_GetByCampaignId_Result> _sp_Survey_GetByCampaignId { get; set; }
        private Repositories<sp_SurveyQuestion_GetBySurveyId_Result> _sp_SurveyQuestion_GetBySurveyId { get; set; }
        private Repositories<sp_Voters_GetAll_Result> _sp_Voters_GetAll { get; set; }
        private Repositories<sp_Voters_GetById_Result> _sp_Voters_GetById { get; set; }
        private Repositories<sp_Voters_GetByPageInchargeId_Result> _sp_Voters_GetByPageInchargeId { get; set; }
        //20180228
        private Repositories<sp_Voters_GetByStateId_Result> _sp_Voters_GetByStateId { get; set; }
        private Repositories<sp_Voters_GetByAreaId_Result> _sp_Voters_GetByAreaId { get; set; }
        private Repositories<sp_Voters_GetByVidhanSabhaConstituencyId_Result> _sp_Voters_GetByVidhanSabhaConstituencyId { get; set; }
        private Repositories<sp_Voters_GetByLokSabhaConstituencyId_Result> _sp_Voters_GetByLokSabhaConstituencyId { get; set; }
        private Repositories<sp_Voters_GetByWardId_Result> _sp_Voters_GetByWardId { get; set; }

        //20180312
        private Repositories<sp_PageInchargeComments_ByCampaignId_Result> _sp_PageInchargeComments_ByCampaignId { get; set; }

        //20180313
        private Repositories<sp_SurveyAnalysis_BySurveyId_Result> _sp_SurveyAnalysis_BySurveyId { get; set; }
        private Repositories<sp_Voters_DeleteByVoterId> _sp_Voters_DeleteByVoterId { get; set; }

        //20180314
        private Repositories<sp_Voters_UpdateDetail> _sp_Voters_UpdateDetail { get; set; }
        //20180319
        private Repositories<sp_Voters_VerifyByPageIncharge> _sp_Voters_VerifyVoterByPageIncharge { get; set; }
        //20180322
        private Repositories<sp_SectionIncharge_GetAllByBoothIncharge_Result> _sp_SectionIncharge_GetAllByBoothIncharge_Result { get; set; }
        #endregion

        private Repositories<voterList> _voterList { get; set; }


        public UnitOfWork()
        {
            _context = new electoEntities();
        }

        public Repositories<surveyRespons> submitResponse_
        {
            get
            {
                if (this._submitResponse == null)
                    this._submitResponse = new Repositories<surveyRespons>(_context);
                return _submitResponse;
            }
        }

        public Repositories<sp_GetAllEventTypes_Result> getEventTypes_
        {
            get
            {
                if (this._getEventTypes == null)
                    this._getEventTypes = new Repositories<sp_GetAllEventTypes_Result>(_context);
                return _getEventTypes;
            }
        }

        public Repositories<sp_GetVoters_List_Result> getVoters_
        {
            get
            {
                if (this._getVoters == null)
                    this._getVoters = new Repositories<sp_GetVoters_List_Result>(_context);
                return _getVoters;
            }
        }

        public Repositories<sp_GetAllDataEntryOperators_Result> getAllDataEntryOperators_
        {
            get
            {
                if (this._getAllDataEntryOperators == null)
                    this._getAllDataEntryOperators = new Repositories<sp_GetAllDataEntryOperators_Result>(_context);
                return _getAllDataEntryOperators;
            }
        }

        public Repositories<voterList> voterList_
        {
            get
            {
                if (this._voterList == null)
                    this._voterList = new Repositories<voterList>(_context);
                return _voterList;
            }
        }
        public Repositories<sp_getAllRelationshipsInCampaignByUserType_Result_> getAllRelationshipsInCampaignByUserType_
        {
            get
            {
                if (this._getAllRelationshipsInCampaignByUserType == null)
                    this._getAllRelationshipsInCampaignByUserType = new Repositories<sp_getAllRelationshipsInCampaignByUserType_Result_>(_context);
                return _getAllRelationshipsInCampaignByUserType;
            }
        }

        public Repositories<sp_GetAllSectionInchargeByCampaign_Result> getAllSectionInchargeByCampaign_
        {
            get
            {
                if (this._getAllSectionInchargeByCampaign == null)
                    this._getAllSectionInchargeByCampaign = new Repositories<sp_GetAllSectionInchargeByCampaign_Result>(_context);
                return _getAllSectionInchargeByCampaign;
            }
        }

        public Repositories<pollingBooth_andInchargRelationship> pollingBooth_andInchargRelationship_
        {
            get
            {
                if (this._pollingBooth_andInchargRelationship == null)
                    this._pollingBooth_andInchargRelationship = new Repositories<pollingBooth_andInchargRelationship>(_context);
                return _pollingBooth_andInchargRelationship;
            }
        }

        public Repositories<pageInchargeAssignedArea> assignPageInchargeArea_
        {
            get
            {
                if (this._assignPageInchargeArea == null)
                    this._assignPageInchargeArea = new Repositories<pageInchargeAssignedArea>(_context);
                return _assignPageInchargeArea;
            }
        }

        public Repositories<sp_getAreaListByCampignID_Result> getAreaListByCampignID_
        {
            get
            {
                if (this._getAreaListByCampignID == null)
                    this._getAreaListByCampignID = new Repositories<sp_getAreaListByCampignID_Result>(_context);
                return _getAreaListByCampignID;
            }
        }

        public Repositories<sp_GetLatestNews_Result> getNews_
        {
            get
            {
                if (this._getNews == null)
                    this._getNews = new Repositories<sp_GetLatestNews_Result>(_context);
                return _getNews;
            }
        }

        public Repositories<news> createNews_
        {
            get
            {
                if (this._createNews == null)
                    this._createNews = new Repositories<news>(_context);
                return _createNews;
            }
        }


        public Repositories<Biography_s> Biography_s_
        {
            get
            {
                if (this._Biography_s == null)
                    this._Biography_s = new Repositories<Biography_s>(_context);
                return _Biography_s;
            }
        }
        public Repositories<compaignVolunteerRelationship> updateRelationShip_
        {
            get
            {
                if (this._updateRelationShip == null)
                    this._updateRelationShip = new Repositories<compaignVolunteerRelationship>(_context);
                return _updateRelationShip;
            }
        }

        public Repositories<sp_CheckUserInCampaign_Result> checkUser_
        {
            get
            {
                if (this._checkUser == null)
                    this._checkUser = new Repositories<sp_CheckUserInCampaign_Result>(_context);
                return _checkUser;
            }
        }

        public Repositories<compaignVolunteerRelationship> createVolunteerRelationship_
        {
            get
            {
                if (this._createVolunteerRelationship == null)
                    this._createVolunteerRelationship = new Repositories<compaignVolunteerRelationship>(_context);
                return _createVolunteerRelationship;
            }
        }

        public Repositories<userType> get_
        {
            get
            {
                if (this._get == null)
                    this._get = new Repositories<userType>(_context);
                return _get;
            }
        }

        public Repositories<sp_GetVolunteers_Result> Assign_
        {
            get
            {
                if (this._Assign == null)
                    this._Assign = new Repositories<sp_GetVolunteers_Result>(_context);
                return _Assign;
            }
        }


        public Repositories<campaign> getMyCampaigns_
        {
            get
            {
                if (this._getMyCampaigns == null)
                    this._getMyCampaigns = new Repositories<campaign>(_context);
                return _getMyCampaigns;
            }
        }
        public Repositories<sp_createEvent> sp_createEvent_
        {
            get
            {
                if (this._sp_createEvent == null)
                    this._sp_createEvent = new Repositories<sp_createEvent>(_context);
                return _sp_createEvent;
            }
        }

        public Repositories<campaign> createCampaign_
        {
            get
            {
                if (this._createCampaign == null)
                    this._createCampaign = new Repositories<campaign>(_context);
                return _createCampaign;
            }
        }

        public Repositories<campaignPrice> getAllPrices_
        {
            get
            {
                if (this._getAllPrices == null)
                    this._getAllPrices = new Repositories<campaignPrice>(_context);
                return _getAllPrices;
            }
        }
        public Repositories<sp_createSurveyQuestion_Result> sp_createSurveyQuestion_Result_
        {
            get
            {
                if (this._sp_createSurveyQuestion_Result == null)
                    this._sp_createSurveyQuestion_Result = new Repositories<sp_createSurveyQuestion_Result>(_context);
                return _sp_createSurveyQuestion_Result;
            }
        }
        public Repositories<survey> survey_
        {
            get
            {
                if (this._survey == null)
                    this._survey = new Repositories<survey>(_context);
                return _survey;
            }
        }
        public Repositories<loginVolunteer> saveLogoutDetails_
        {
            get
            {
                if (this._saveLogoutDetails == null)
                    this._saveLogoutDetails = new Repositories<loginVolunteer>(_context);
                return _saveLogoutDetails;
            }
        }

        public Repositories<loginVolunteer> saveUserDetails_
        {
            get
            {
                if (this._saveUserDetails == null)
                    this._saveUserDetails = new Repositories<loginVolunteer>(_context);
                return _saveUserDetails;
            }
        }

        public Repositories<loginVolunteer> getUserDetails_
        {
            get
            {
                if (this._getUserDetails == null)
                    this._getUserDetails = new Repositories<loginVolunteer>(_context);
                return _getUserDetails;
            }
        }

        public Repositories<electionName> getAllElections_
        {
            get
            {
                if (this._getAllElections == null)
                    this._getAllElections = new Repositories<electionName>(_context);
                return _getAllElections;
            }
        }

        public Repositories<pollingBooth> createPollingBooth_
        {
            get
            {
                if (this._createPollingBooth == null)
                    this._createPollingBooth = new Repositories<pollingBooth>(_context);
                return _createPollingBooth;
            }
        }

        public Repositories<areaName> createArea_
        {
            get
            {
                if (this._createArea == null)
                    this._createArea = new Repositories<areaName>(_context);
                return _createArea;
            }
        }

        public Repositories<language> language_
        {
            get
            {
                if (this._language == null)
                    this._language = new Repositories<language>(_context);
                return _language;
            }
        }
        public Repositories<wardConstituency> wardConstituency_
        {
            get
            {
                if (this._wardConstituency == null)
                    this._wardConstituency = new Repositories<wardConstituency>(_context);
                return _wardConstituency;
            }
        }
        public Repositories<zoneMunicipality> zoneMunicipality_
        {
            get
            {
                if (this._zoneMunicipality == null)
                    this._zoneMunicipality = new Repositories<zoneMunicipality>(_context);
                return _zoneMunicipality;
            }
        }

        public Repositories<municipalCorporationName> municipalCorporationName_
        {
            get
            {
                if (this._municipalCorporationName == null)
                    this._municipalCorporationName = new Repositories<municipalCorporationName>(_context);
                return _municipalCorporationName;
            }
        }

        public Repositories<sp_getAllParties_NoParams_Result> sp_getAllParties_NoParams_Result_
        {
            get
            {
                if (this._sp_getAllParties_NoParams_Result == null)
                    this._sp_getAllParties_NoParams_Result = new Repositories<sp_getAllParties_NoParams_Result>(_context);
                return _sp_getAllParties_NoParams_Result;
            }
        }
        public Repositories<tblyear> tblyear_
        {
            get
            {
                if (this._tblyear == null)
                    this._tblyear = new Repositories<tblyear>(_context);
                return _tblyear;
            }
        }
        public Repositories<electionName> electionName_
        {
            get
            {
                if (this._electionName == null)
                    this._electionName = new Repositories<electionName>(_context);
                return _electionName;
            }
        }
        public Repositories<monthName> monthName_
        {
            get
            {
                if (this._monthName == null)
                    this._monthName = new Repositories<monthName>(_context);
                return _monthName;
            }
        }
        public Repositories<sp_CreateUser> sp_CreateUser_
        {
            get
            {
                if (this._sp_CreateUser == null)
                    this._sp_CreateUser = new Repositories<sp_CreateUser>(_context);
                return _sp_CreateUser;
            }
        }
        public Repositories<sp_Campaigns_GetByWardId_Result> sp_Campaigns_GetByWardId_
        {
            get
            {
                if (this._sp_Campaigns_GetByWardId == null)
                    this._sp_Campaigns_GetByWardId = new Repositories<sp_Campaigns_GetByWardId_Result>(_context);
                return _sp_Campaigns_GetByWardId;
            }
        }

        public Repositories<userType> userType_
        {
            get
            {
                if (this._userType == null)
                    this._userType = new Repositories<userType>(_context);
                return _userType;
            }
        }

        public Repositories<politicalParty> politicalParty_
        {
            get
            {
                if (this._politicalParty == null)
                    this._politicalParty = new Repositories<politicalParty>(_context);
                return _politicalParty;
            }
        }

        public Repositories<loginVolunteer> loginVolunteer_
        {
            get
            {
                if (this._loginVolunteer == null)
                    this._loginVolunteer = new Repositories<loginVolunteer>(_context);
                return _loginVolunteer;
            }
        }


        public Repositories<campaignPrice> newCampaignPrice_
        {
            get
            {
                if (this._newCampaignPrice == null)
                    this._newCampaignPrice = new Repositories<campaignPrice>(_context);
                return _newCampaignPrice;
            }
        }
        public Repositories<politicalPartyAddress> politicalPartyAddress_
        {
            get
            {
                if (this._politicalPartyAddress == null)
                    this._politicalPartyAddress = new Repositories<politicalPartyAddress>(_context);
                return _politicalPartyAddress;
            }
        }
        public Repositories<sp_partyAddressList_Result> sp_partyAddressList_Result_
        {
            get
            {
                if (this._sp_partyAddressList_Result == null)
                    this._sp_partyAddressList_Result = new Repositories<sp_partyAddressList_Result>(_context);
                return _sp_partyAddressList_Result;
            }
        }
        public Repositories<campaignPrice> savePriceDetails_
        {
            get
            {
                if (this._savePriceDetails == null)
                    this._savePriceDetails = new Repositories<campaignPrice>(_context);
                return _savePriceDetails;
            }
        }


        public Repositories<campaignPrice> _getPriceDetails_
        {
            get
            {
                if (this._getPriceDetails == null)
                    this._getPriceDetails = new Repositories<campaignPrice>(_context);
                return _getPriceDetails;
            }
        }

        public Repositories<sp_SearchCampaignPrices_Result> sp_SearchCampaignPrices_Result_
        {
            get
            {
                if (this._sp_SearchCampaignPrices_Result == null)
                    this._sp_SearchCampaignPrices_Result = new Repositories<sp_SearchCampaignPrices_Result>(_context);
                return _sp_SearchCampaignPrices_Result;
            }
        }



        public Repositories<sp_createParty_Result> sp_createParty_Result_
        {
            get
            {
                if (this._sp_createParty_Result == null)
                    this._sp_createParty_Result = new Repositories<sp_createParty_Result>(_context);
                return _sp_createParty_Result;
            }
        }

        public Repositories<sp_politicalPartyList_Result> sp_politicalPartyList_Result_
        {
            get
            {
                if (this._sp_politicalPartyList_Result == null)
                    this._sp_politicalPartyList_Result = new Repositories<sp_politicalPartyList_Result>(_context);
                return _sp_politicalPartyList_Result;
            }
        }

        public Repositories<questionType> questionType_
        {
            get
            {
                if (this._questionType == null)
                    this._questionType = new Repositories<questionType>(_context);
                return _questionType;
            }
        }

        public Repositories<eventType> eventType_
        {
            get
            {
                if (this._eventType == null)
                    this._eventType = new Repositories<eventType>(_context);
                return _eventType;
            }
        }


        public Repositories<enquiry> saveDetails
        {
            get
            {
                if (this._saveEnquiryDetails == null)
                    this._saveEnquiryDetails = new Repositories<enquiry>(_context);
                return _saveEnquiryDetails;
            }
        }

        public Repositories<enquiry> GetEnquiryDetails
        {
            get
            {
                if (this._getEnquiryDetails == null)
                    this._getEnquiryDetails = new Repositories<enquiry>(_context);
                return _getEnquiryDetails;
            }
        }

        public Repositories<sp_GetNewEnquiries_Result> sp_GetNewEnquiries_Result
        {
            get
            {
                if (this._sp_GetNewEnquiries_Result == null)
                    this._sp_GetNewEnquiries_Result = new Repositories<sp_GetNewEnquiries_Result>(_context);
                return _sp_GetNewEnquiries_Result;
            }
        }

        public Repositories<sp_getVidhanSabhaLsit_Result> sp_getVidhanSabhaLsit_Result_
        {
            get
            {
                if (this._sp_getVidhanSabhaLsit_Result == null)
                    this._sp_getVidhanSabhaLsit_Result = new Repositories<sp_getVidhanSabhaLsit_Result>(_context);
                return _sp_getVidhanSabhaLsit_Result;
            }
        }


        public Repositories<state> state_
        {
            get
            {
                if (this._state == null)
                    this._state = new Repositories<state>(_context);
                return _state;
            }
        }
        public Repositories<district> district_
        {
            get
            {
                if (this._district == null)
                    this._district = new Repositories<district>(_context);
                return _district;
            }
        }

        public Repositories<vidhanSabhaConstituency> VidhanSabhaConsistuency_
        {
            get
            {
                if (this._VidhanSabhaConsistuency == null)
                    this._VidhanSabhaConsistuency = new Repositories<vidhanSabhaConstituency>(_context);
                return _VidhanSabhaConsistuency;
            }
        }
        public Repositories<lokSabhaConstituency> _lokSabhaConstituency_
        {
            get
            {
                if (this._lokSabhaConstituency == null)
                    this._lokSabhaConstituency = new Repositories<lokSabhaConstituency>(_context);
                return _lokSabhaConstituency;
            }
        }
        public Repositories<sp_areaList_Result> sp_areaList_Result_
        {
            get
            {
                if (this._sp_areaList_Result == null)
                    this._sp_areaList_Result = new Repositories<sp_areaList_Result>(_context);
                return _sp_areaList_Result;
            }
        }
        public Repositories<sp_pollingBoothList_Result> sp_pollingBoothList_Result_
        {
            get
            {
                if (this._sp_pollingBoothList_Result == null)
                    this._sp_pollingBoothList_Result = new Repositories<sp_pollingBoothList_Result>(_context);
                return _sp_pollingBoothList_Result;
            }
        }


        public Repositories<sp_GetRunningCampaigns_Result> RunningCampaigns_Result
        {
            get
            {
                if (this._RunningCampaigns_Result == null)
                    this._RunningCampaigns_Result = new Repositories<sp_GetRunningCampaigns_Result>(_context);
                return _RunningCampaigns_Result;
            }
        }

        public Repositories<campaign> GetDetails_
        {
            get
            {
                if (this._getDetails1 == null)
                    this._getDetails1 = new Repositories<campaign>(_context);
                return _getDetails1;
            }
        }

        public Repositories<campaign> SaveDetails
        {
            get
            {
                if (this._saveDetails == null)
                    this._saveDetails = new Repositories<campaign>(_context);
                return _saveDetails;
            }
        }

        public Repositories<electionType> electionType
        {
            get
            {
                if (this._electionType == null)
                    this._electionType = new Repositories<electionType>(_context);
                return _electionType;
            }
        }

        public Repositories<enquiryType> enquiryType
        {
            get
            {
                if (this._enquiryType == null)
                    this._enquiryType = new Repositories<enquiryType>(_context);
                return _enquiryType;
            }
        }

        public Repositories<sp_electionList_Result> sp_electionList_Result
        {
            get
            {
                if (this._sp_electionList_Result == null)
                    this._sp_electionList_Result = new Repositories<sp_electionList_Result>(_context);
                return _sp_electionList_Result;
            }
        }



        public Repositories<sp_LoginUser_Result> loginVolunteerRepository
        {
            get
            {
                if (this._loginVolunteerRepository == null)
                    this._loginVolunteerRepository = new Repositories<sp_LoginUser_Result>(_context);
                return _loginVolunteerRepository;
            }
        }

        public Repositories<sp_GetNewCampaignRequests_Result> getNewCampaignRequests_Result
        {
            get
            {
                if (this._getNewCampaignRequests_Result == null)
                    this._getNewCampaignRequests_Result = new Repositories<sp_GetNewCampaignRequests_Result>(_context);
                return _getNewCampaignRequests_Result;
            }
        }

        public Repositories<sp_GetUpcomingElections_Result> GetUpcomingElections_Result
        {
            get
            {
                if (this._getUpcomingElections_Result == null)
                    this._getUpcomingElections_Result = new Repositories<sp_GetUpcomingElections_Result>(_context);
                return _getUpcomingElections_Result;
            }
        }

        public Repositories<sp_GetRunningCampaigns_Result> GetRunningCampaigns_Result
        {
            get
            {
                if (this._getRunningCampaigns_Result == null)
                    this._getRunningCampaigns_Result = new Repositories<sp_GetRunningCampaigns_Result>(_context);
                return _getRunningCampaigns_Result;
            }
        }

        public Repositories<sp_GetNewEnquiries_Result> GetNewEnquiries_Result
        {
            get
            {
                if (this._getNewEnquiries_Result == null)
                    this._getNewEnquiries_Result = new Repositories<sp_GetNewEnquiries_Result>(_context);
                return _getNewEnquiries_Result;
            }
        }

        #region HR Property 2
        public Repositories<sp_Campaigns_GetAll_Result> sp_Campaigns_GetAll_Result_
        {
            get
            {
                if (this._sp_Campaigns_GetAll == null)
                {
                    this._sp_Campaigns_GetAll = new Repositories<sp_Campaigns_GetAll_Result>(_context);
                }
                return _sp_Campaigns_GetAll;
            }
        }
        public Repositories<sp_Campaigns_GetById_Result> sp_Campaigns_GetById_Result_
        {
            get
            {
                if (this._sp_Campaigns_GetById == null)
                {
                    this._sp_Campaigns_GetById = new Repositories<sp_Campaigns_GetById_Result>(_context);
                }
                return _sp_Campaigns_GetById;
            }
        }
        public Repositories<sp_Campaigns_GetByElectionTypeId_Result> sp_Campaigns_GetByElectionTypeId_Result_
        {
            get
            {
                if (this._sp_Campaigns_GetByElectionTypeId == null)
                {
                    this._sp_Campaigns_GetByElectionTypeId = new Repositories<sp_Campaigns_GetByElectionTypeId_Result>(_context);
                }
                return _sp_Campaigns_GetByElectionTypeId;
            }
        }
        public Repositories<sp_Campaigns_GetByElectionId_Result> sp_Campaigns_GetByElectionId_Result_
        {
            get
            {
                if (this._sp_Campaigns_GetByElectionId == null)
                {
                    this._sp_Campaigns_GetByElectionId = new Repositories<sp_Campaigns_GetByElectionId_Result>(_context);
                }
                return _sp_Campaigns_GetByElectionId;
            }
        }
        public Repositories<sp_Campaigns_GetByLokSabhaConstituencyId_Result> _getDetails
        {
            get
            {
                if (this._sp_Campaigns_GetByLokSabhaConstituencyId == null)
                {
                    this._sp_Campaigns_GetByLokSabhaConstituencyId = new Repositories<sp_Campaigns_GetByLokSabhaConstituencyId_Result>(_context);
                }
                return _sp_Campaigns_GetByLokSabhaConstituencyId;
            }
        }
        public Repositories<sp_Campaigns_GetByPoliticalPartyId_Result> sp_Campaigns_GetByPoliticalPartyId_Result_
        {
            get
            {
                if (this._sp_Campaigns_GetByPoliticalPartyId == null)
                {
                    this._sp_Campaigns_GetByPoliticalPartyId = new Repositories<sp_Campaigns_GetByPoliticalPartyId_Result>(_context);
                }
                return _sp_Campaigns_GetByPoliticalPartyId;
            }
        }
        public Repositories<sp_Campaigns_GetByVidhanSabhaConstituencyId_Result> sp_Campaigns_GetByVidhanSabhaConstituencyId_Result_
        {
            get
            {
                if (this._sp_Campaigns_GetByVidhanSabhaConstituencyId == null)
                {
                    this._sp_Campaigns_GetByVidhanSabhaConstituencyId = new Repositories<sp_Campaigns_GetByVidhanSabhaConstituencyId_Result>(_context);
                }
                return _sp_Campaigns_GetByVidhanSabhaConstituencyId;
            }
        }
        public Repositories<sp_Campaigns_GetByVolunteerId_Result> sp_Campaigns_GetByVolunteerId_Result_
        {
            get
            {
                if (this._sp_Campaigns_GetByVolunteerId == null)
                {
                    this._sp_Campaigns_GetByVolunteerId = new Repositories<sp_Campaigns_GetByVolunteerId_Result>(_context);
                }
                return _sp_Campaigns_GetByVolunteerId;
            }
        }
        public Repositories<sp_Campaigns_GetByWardId_Result> sp_Campaigns_GetByWardId_Result_
        {
            get
            {
                if (this._sp_Campaigns_GetByWardId == null)
                {
                    this._sp_Campaigns_GetByWardId = new Repositories<sp_Campaigns_GetByWardId_Result>(_context);
                }
                return _sp_Campaigns_GetByWardId;
            }
        }
        //20180222
        //private Repositories<sp_Area_GetAll_Result> _sp_Area_GetAll { get; set; }
        public Repositories<sp_Area_GetAll_Result> sp_Area_GetAll_Result_
        {
            get
            {
                if (this._sp_Area_GetAll == null)
                {
                    this._sp_Area_GetAll = new Repositories<sp_Area_GetAll_Result>(_context);
                }
                return _sp_Area_GetAll;
            }
        }
        //private Repositories<sp_Area_GetByPageInchargeId_Result> _sp_Area_GetByPageInchargeId { get; set; }
        public Repositories<sp_Area_GetByPageInchargeId_Result> sp_Area_GetByPageInchargeId_Result_
        {
            get
            {
                if (this._sp_Area_GetByPageInchargeId == null)
                {
                    this._sp_Area_GetByPageInchargeId = new Repositories<sp_Area_GetByPageInchargeId_Result>(_context);
                }
                return _sp_Area_GetByPageInchargeId;
            }
        }
        ////private Repositories<sp_Area_GetByVolunteerId_Result> _sp_Area_GetByVolunteerId { get; set; }
        //public Repositories<sp_Area_GetByVolunteerId_Result> sp_Area_GetByVolunteerId_Result_
        //{
        //    get
        //    {
        //        if (this._sp_Area_GetByVolunteerId == null)
        //        {
        //            this._sp_Area_GetByVolunteerId = new Repositories<sp_Area_GetByVolunteerId_Result>(_context);
        //        }
        //        return _sp_Area_GetByVolunteerId;
        //    }
        //}
        //private Repositories<sp_Event_GetByCampaignId_Result> _sp_Event_GetByCampaignId { get; set; }
        public Repositories<sp_Event_GetByCampaignIdANDEventTypeID_Result> sp_Event_GetByCampaignId_Result_
        {
            get
            {
                if (this._sp_Event_GetByCampaignId == null)
                {
                    this._sp_Event_GetByCampaignId = new Repositories<sp_Event_GetByCampaignIdANDEventTypeID_Result>(_context);
                }
                return _sp_Event_GetByCampaignId;
            }
        }
        //private Repositories<sp_Event_GetByEventTypeId_Result> _sp_Event_GetByEventTypeId { get; set; }
        public Repositories<sp_Event_GetByEventTypeId_Result> sp_Event_GetByEventTypeId_Result_
        {
            get
            {
                if (this._sp_Event_GetByEventTypeId == null)
                {
                    this._sp_Event_GetByEventTypeId = new Repositories<sp_Event_GetByEventTypeId_Result>(_context);
                }
                return _sp_Event_GetByEventTypeId;
            }
        }

        //private repositories<sp_survey_getall_result> _sp_survey_getall { get; set; }
        //private Repositories<sp_Survey_GetAll_Result> _sp_Survey_GetAll { get; set; }
        public Repositories<sp_Survey_GetAll_Result> sp_Survey_GetAll_Result_
        {
            get
            {
                if (this._sp_Survey_GetAll == null)
                {
                    this._sp_Survey_GetAll = new Repositories<sp_Survey_GetAll_Result>(_context);
                }
                return _sp_Survey_GetAll;
            }
        }
        //private repositories<sp_survey_getbycampaignid_result> _sp_survey_getbycampaignid { get; set; }
        public Repositories<sp_Survey_GetByCampaignId_Result> sp_Survey_GetByCampaignId_Result_
        {
            get
            {
                if (this._sp_Survey_GetByCampaignId == null)
                {
                    this._sp_Survey_GetByCampaignId = new Repositories<sp_Survey_GetByCampaignId_Result>(_context);
                }
                return _sp_Survey_GetByCampaignId;
            }
        }
        //private repositories<sp_surveyquestion_getbysurveyid_result> _sp_surveyquestion_getbysurveyid { get; set; }
        public Repositories<sp_SurveyQuestion_GetBySurveyId_Result> sp_SurveyQuestion_GetBySurveyId_Result_
        {
            get
            {
                if (this._sp_SurveyQuestion_GetBySurveyId == null)
                {
                    this._sp_SurveyQuestion_GetBySurveyId = new Repositories<sp_SurveyQuestion_GetBySurveyId_Result>(_context);
                }
                return _sp_SurveyQuestion_GetBySurveyId;
            }
        }
        //private repositories<sp_voters_getall_result> _sp_voters_getall { get; set; }
        public Repositories<sp_Voters_GetAll_Result> sp_Voters_GetAll_Result_
        {
            get
            {
                if (this._sp_Voters_GetAll == null)
                {
                    this._sp_Voters_GetAll = new Repositories<sp_Voters_GetAll_Result>(_context);
                }
                return _sp_Voters_GetAll;
            }
        }
        //private repositories<sp_voters_getbyid_result> _sp_voters_getbyid { get; set; }
        public Repositories<sp_Voters_GetById_Result> sp_Voters_GetById_Result_
        {
            get
            {
                if (this._sp_Voters_GetById == null)
                {
                    this._sp_Voters_GetById = new Repositories<sp_Voters_GetById_Result>(_context);
                }
                return _sp_Voters_GetById;
            }
        }
        //private repositories<sp_voters_getbypageinchargeid_result> _sp_voters_getbypageinchargeid { get; set; }
        public Repositories<sp_Voters_GetByPageInchargeId_Result> sp_Voters_GetByPageInchargeId_Result_
        {
            get
            {
                if (this._sp_Voters_GetByPageInchargeId == null)
                {
                    this._sp_Voters_GetByPageInchargeId = new Repositories<sp_Voters_GetByPageInchargeId_Result>(_context);
                }
                return _sp_Voters_GetByPageInchargeId;
            }
        }



        //20180228
        //private Repositories<sp_Voters_GetByStateId_Result> _sp_Voters_GetByStateId { get; set; }
        public Repositories<sp_Voters_GetByStateId_Result> sp_Voters_GetByStateId_Result_
        {
            get
            {
                if (this._sp_Voters_GetByStateId == null)
                {
                    this._sp_Voters_GetByStateId = new Repositories<sp_Voters_GetByStateId_Result>(_context);
                }
                return _sp_Voters_GetByStateId;
            }
        }
        //private Repositories<sp_Voters_GetByAreaId_Result> _sp_Voters_GetByAreaId { get; set; }
        public Repositories<sp_Voters_GetByAreaId_Result> sp_Voters_GetByAreaId_Result_
        {
            get
            {
                if (this._sp_Voters_GetByAreaId == null)
                {
                    this._sp_Voters_GetByAreaId = new Repositories<sp_Voters_GetByAreaId_Result>(_context);
                }
                return _sp_Voters_GetByAreaId;
            }
        }
        //private Repositories<sp_Voters_GetByVidhanSabhaConstituencyId_Result> _sp_Voters_GetByVidhanSabhaConstituencyId { get; set; }
        public Repositories<sp_Voters_GetByVidhanSabhaConstituencyId_Result> sp_Voters_GetByVidhanSabhaConstituencyId_Result_
        {
            get
            {
                if (this._sp_Voters_GetByVidhanSabhaConstituencyId == null)
                {
                    this._sp_Voters_GetByVidhanSabhaConstituencyId = new Repositories<sp_Voters_GetByVidhanSabhaConstituencyId_Result>(_context);
                }
                return _sp_Voters_GetByVidhanSabhaConstituencyId;
            }
        }
        //private Repositories<sp_Voters_GetByLokSabhaConstituencyId_Result> _sp_Voters_GetByLokSabhaConstituencyId { get; set; }
        public Repositories<sp_Voters_GetByLokSabhaConstituencyId_Result> sp_Voters_GetByLokSabhaConstituencyId_Result_
        {
            get
            {
                if (this._sp_Voters_GetByLokSabhaConstituencyId == null)
                {
                    this._sp_Voters_GetByLokSabhaConstituencyId = new Repositories<sp_Voters_GetByLokSabhaConstituencyId_Result>(_context);
                }
                return _sp_Voters_GetByLokSabhaConstituencyId;
            }
        }
        //private Repositories<sp_Voters_GetByWardId_Result> _sp_Voters_GetByWardId { get; set; }
        public Repositories<sp_Voters_GetByWardId_Result> sp_Voters_GetByWardId_Result_
        {
            get
            {
                if (this._sp_Voters_GetByWardId == null)
                {
                    this._sp_Voters_GetByWardId = new Repositories<sp_Voters_GetByWardId_Result>(_context);
                }
                return _sp_Voters_GetByWardId;
            }
        }

        //private Repositories<sp_PageInchargeComments_ByCampaignId_Result> _sp_PageInchargeComments_ByCampaignId { get; set; }
        public Repositories<sp_PageInchargeComments_ByCampaignId_Result> sp_PageInchargeComments_ByCampaignId_Result_
        {
            get
            {
                if (this._sp_PageInchargeComments_ByCampaignId == null)
                {
                    this._sp_PageInchargeComments_ByCampaignId = new Repositories<sp_PageInchargeComments_ByCampaignId_Result>(_context);
                }
                return _sp_PageInchargeComments_ByCampaignId;
            }
        }

        //private Repositories<sp_SurveyAnalysis_BySurveyId_Result> _sp_SurveyAnalysis_BySurveyId { get; set; }
        public Repositories<sp_SurveyAnalysis_BySurveyId_Result> sp_SurveyAnalysis_BySurveyId_Result_
        {
            get
            {
                if (this._sp_SurveyAnalysis_BySurveyId == null)
                {
                    this._sp_SurveyAnalysis_BySurveyId = new Repositories<sp_SurveyAnalysis_BySurveyId_Result>(_context);
                }
                return _sp_SurveyAnalysis_BySurveyId;
            }
        }
        //private Repositories<sp_Voters_DeleteByVoterId> _sp_Voters_DeleteByVoterId { get; set; }
        public Repositories<sp_Voters_DeleteByVoterId> sp_Voters_DeleteByVoterId_
        {
            get
            {
                if (this._sp_Voters_DeleteByVoterId == null)
                    this._sp_Voters_DeleteByVoterId = new Repositories<sp_Voters_DeleteByVoterId>(_context);
                return _sp_Voters_DeleteByVoterId;
            }
        }
        //private Repositories<sp_Voters_UpdateDetail> _sp_Voters_UpdateDetail { get; set; }
        public Repositories<sp_Voters_UpdateDetail> sp_Voters_UpdateDetail_
        {
            get
            {
                if (this._sp_Voters_UpdateDetail == null)
                    this._sp_Voters_UpdateDetail = new Repositories<sp_Voters_UpdateDetail>(_context);
                return _sp_Voters_UpdateDetail;
            }
        }
        //private Repositories<sp_Voters_VerifyByPageIncharge> _sp_Voters_VerifyVoterByPageIncharge { get; set; }
        //public Repositories <sp_Voters_VerifyByPageIncharge> sp_Voters_VerifyByPageIncharge_
        //{
        //    get
        //    {
        //        if (this._sp_Voters_VerifyVoterByPageIncharge == null)
        //        {
        //            this._sp_Voters_VerifyVoterByPageIncharge = new Repositories<sp_Voters_VerifyByPageIncharge>(_context);
        //        }
        //        return _sp_Voters_VerifyVoterByPageIncharge;
        //    }
        //}

        //20180322
        public Repositories<sp_SectionIncharge_GetAllByBoothIncharge_Result> sp_SectionIncharge_GetAllByBoothIncharge_Result_
        {
            get
            {
                if (this._sp_SectionIncharge_GetAllByBoothIncharge_Result == null)
                    this._sp_SectionIncharge_GetAllByBoothIncharge_Result = new Repositories<sp_SectionIncharge_GetAllByBoothIncharge_Result>(_context);
                return _sp_SectionIncharge_GetAllByBoothIncharge_Result;
            }
        }
        #endregion


        // public IAuthorRepository Authors { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}