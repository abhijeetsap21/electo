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
    
    public partial class sp_getVoterDetailsByVoterID_Result
    {
        public long voterID { get; set; }
        public string Regional_Name { get; set; }
        public string voterFather_HusbandName { get; set; }
        public string voterIDNumber { get; set; }
        public string voterAadharNumber { get; set; }
        public Nullable<System.DateTime> dateOfBirth { get; set; }
        public string address { get; set; }
        public string emailId { get; set; }
        public string mobile { get; set; }
        public string fullName { get; set; }
        public string userTypeName { get; set; }
        public Nullable<long> volunteerID { get; set; }
        public string politicalPartyName { get; set; }
    }
}