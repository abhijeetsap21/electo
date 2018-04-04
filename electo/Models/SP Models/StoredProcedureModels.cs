using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace electo.Models.SP_Models
{
    public class StoredProcedureModels
    {
        public  class sp_GetNewEnquiries_Result
        {
            public long enquiryID { get; set; }
            public string enquiryTypeName { get; set; }
            public string enquirerName { get; set; }
            public DateTime dataIsCreated { get; set; }
            public string mobile { get; set; }
            public bool isTaskComplete { get; set; }
        }

        public class sp_CheckUserInCampaign_Result
        {
            public long volunteerID { get; set; }
        }

        public  class sp_SearchRunningCampaigns_Result
        {
            public long campaignID { get; set; }            
            public string campaignName { get; set; }
            public string voterName { get; set; }
            public string electionTypeNAME { get; set; }
            public int electionYear { get; set; }
            public string politicalPartyName { get; set; }
            public bool isActive { get; set; }
        }

        public class sp_SearchCampaignPrices_Result
        {
            public int campaignPriceID { get; set; }
            public int price { get; set; }
            public string electionTypeNAME { get; set; }
            public string year { get; set; }
            public DateTime dataIsCreated { get; set; }
            public DateTime dataIsUpdated { get; set; }
            public bool isActive { get; set; }
        }
        public class sp_CreateUser
        {
            int result { get; set; }
        }
        public class sp_createEvent {
            public int eventTypeID { get; set; }
            public Int64 campaignID { get; set; }            
            public Int64 createdBy { get; set; }
            public string eventTitle { get; set; }
            public string eventDescription { get; set; }
            public string mediaURL { get; set; }
         }

        public  class sp_getAllRelationshipsInCampaignByUserType_Result_
        {
            public string voterName { get; set; }
            public string WorkingArea { get; set; }
            public string address { get; set; }
        }
        public class sp_Voters_DeleteByVoterId
        {
            int result { get; set; }
        }

        //public class sp_GetVoters_List_Result
        //{
        //    public long voterID { get; set; }
        //    public string voterName { get; set; }
        //    public string voterLastName { get; set; }
        //    public string voterFather_HusbandName { get; set; }
        //    public int vidhanSabhaConstituencyID { get; set; }
        //    public int lokSabhaConstituencyID { get; set; }
        //    public int wardID { get; set; }
        //    public int stateID { get; set; }
        //    public long areaID { get; set; }
        //    public System.DateTime dataIsCreated { get; set; }
        //    public System.DateTime dataIsUpdated { get; set; }
        //    public long createdBy { get; set; }
        //    public long modifiedBy { get; set; }
        //    public string plotNo { get; set; }
        //    public string streetNo { get; set; }
        //    public string address1 { get; set; }
        //    public string address2 { get; set; }
        //    public int pincode { get; set; }
        //    public int genderID { get; set; }
        //    public Nullable<System.DateTime> dateOfBirth { get; set; }
        //    public string voterAadharNumber { get; set; }
        //    public string voterIDNumber { get; set; }
        //    public Nullable<System.DateTime> voterIDIssueDate { get; set; }
        //    public Nullable<bool> isMarried { get; set; }
        //    public string voterImageURL { get; set; }
        //    public bool isActive { get; set; }           
        //    public Nullable<int> regionalLanguage { get; set; }
        //    public string mobileNo { get; set; }
        //    public Nullable<int> age { get; set; }
        //    public string vidhanSabhaConstituencyName { get; set; }
        //    public string lokSabhaConstituencyName { get; set; }
        //    public string wardName { get; set; }
        //    public string stateName { get; set; }
        //    public string areaName { get; set; }
        //    public string gender { get; set; }           
        //}

        public class sp_getVoterDetailsByVoterIDApp
        {
            public long voterID { get; set; }
            public string Regional_Name { get; set; }
            public string voterFather_HusbandName { get; set; }
            public string voterIDNumber { get; set; }           
            public System.DateTime dateOfBirth { get; set; }
            public string address { get; set; }            
            public Nullable<long> volunteerID { get; set; }
          
        }

        public class CreateVolunteerLoginApp
        {            
            public int politicalPartyID { get; set; }            
            public string mobile { get; set; }
            public string fullName { get; set; }            
            public string userID { get; set; }
            public string voterID { get; set; }
            public string AadharCardNumber { get; set; }            
        }

      
    }
}