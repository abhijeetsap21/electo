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
    
    public partial class sp_getVidhanSabhaLsit_Result
    {
        public int lokSabhaConstituencyID { get; set; }
        public int vidhanSabhaConstituencyID { get; set; }
        public string vidhanSabhaConstituencyName { get; set; }
        public string stateName { get; set; }
        public string lokSabhaConstituencyName { get; set; }
        public string districtName { get; set; }
        public System.DateTime dataIsCreated { get; set; }
        public bool isActive { get; set; }
        public int stateID { get; set; }
        public int districtID { get; set; }
    }
}
