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
    
    public partial class sp_Voters_GetByVidhanSabhaConstituencyId_Result
    {
        public long voterID { get; set; }
        public string voterName { get; set; }
        public string voterLastName { get; set; }
        public string voterFather_HusbandName { get; set; }
        public int vidhanSabhaConstituencyID { get; set; }
        public int lokSabhaConstituencyID { get; set; }
        public int wardID { get; set; }
        public int stateID { get; set; }
        public long areaID { get; set; }
        public System.DateTime dataIsCreated { get; set; }
        public System.DateTime dataIsUpdated { get; set; }
        public long createdBy { get; set; }
        public long modifiedBy { get; set; }
        public string plotNo { get; set; }
        public string streetNo { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public int pincode { get; set; }
        public int genderID { get; set; }
        public Nullable<System.DateTime> dateOfBirth { get; set; }
        public string voterAadharNumber { get; set; }
        public string voterIDNumber { get; set; }
        public Nullable<System.DateTime> voterIDIssueDate { get; set; }
        public Nullable<bool> isMarried { get; set; }
        public string voterImageURL { get; set; }
        public bool isActive { get; set; }
        public Nullable<int> regionalLanguage { get; set; }
        public string mobileNo { get; set; }
        public Nullable<int> age { get; set; }
        public string vidhanSabhaConstituencyName { get; set; }
        public string lokSabhaConstituencyName { get; set; }
        public string wardName { get; set; }
        public string stateName { get; set; }
        public string areaName { get; set; }
        public string gender { get; set; }
    }
}
