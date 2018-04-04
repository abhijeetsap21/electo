using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace electo.Models.SP_Models
{
    public class sp_Campaigns_GetByElectionTypeId
    {
        public long campaignID { get; set; }
        public string campaignName { get; set; }
        public int electionTypeID { get; set; }
        public int electionID { get; set; }
        public int politicalPartyID { get; set; }
        public Nullable<int> lokSabhaConstituencyID { get; set; }
        public Nullable<int> vidhanSabhaConstituencyID { get; set; }
        public Nullable<int> wardID { get; set; }
        public long volunteerID { get; set; }
        public System.DateTime dataIsCreated { get; set; }
        public System.DateTime dataIsUpdated { get; set; }
        public long createdBy { get; set; }
        public long modifiedBy { get; set; }
        public bool isActive { get; set; }
        public bool isOLD { get; set; }
        public bool isPaymentComplete { get; set; }
        public Nullable<int> price { get; set; }
        public string electionTypeNAME { get; set; }
        public string electionName { get; set; }
        public string lokSabhaConstituencyName { get; set; }
        public string vidhanSabhaConstituencyName { get; set; }
        public string wardName { get; set; }
    }
}