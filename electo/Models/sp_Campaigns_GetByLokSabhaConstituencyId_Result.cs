//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace electo.Models
{
    using System;
    
    public partial class sp_Campaigns_GetByLokSabhaConstituencyId_Result
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
