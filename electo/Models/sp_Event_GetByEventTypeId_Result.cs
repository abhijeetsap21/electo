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
    
    public partial class sp_Event_GetByEventTypeId_Result
    {
        public long eventID { get; set; }
        public int eventTypeID { get; set; }
        public Nullable<long> campaignID { get; set; }
        public System.DateTime dataIsCreated { get; set; }
        public System.DateTime dataIsUpdated { get; set; }
        public long createdBy { get; set; }
        public long modifiedBy { get; set; }
        public bool isDelete { get; set; }
        public string eventTitle { get; set; }
        public string eventDescription { get; set; }
        public string eventName { get; set; }
        public string campaignName { get; set; }
    }
}
