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
    
    public partial class sp_LoginUser_Result
    {
        public long loginID { get; set; }
        public long voterID { get; set; }
        public Nullable<long> volunteerID { get; set; }
        public string userID { get; set; }
        public int userTypeID { get; set; }
        public System.DateTime lastLogin { get; set; }
        public string voterName { get; set; }
        public string message { get; set; }
        public string politicalPartyLogo { get; set; }
        public Nullable<int> politicalPartyID { get; set; }
        public string password { get; set; }
        public string mobile { get; set; }
        public string userPhoto { get; set; }
        public Nullable<bool> createNewCompaign { get; set; }
    }
}
