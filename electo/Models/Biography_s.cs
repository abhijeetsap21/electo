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
    using System.Collections.Generic;
    
    public partial class Biography_s
    {
        public int BiographyID { get; set; }
        public string personName { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public System.DateTime dataIsCreated { get; set; }
        public System.DateTime dataIsUpdated { get; set; }
        public long createdBy { get; set; }
        public long modifiedBy { get; set; }
    
        public virtual loginVolunteer loginVolunteer { get; set; }
        public virtual loginVolunteer loginVolunteer1 { get; set; }
    }
}
