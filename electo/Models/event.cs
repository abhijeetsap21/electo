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
    
    public partial class @event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public @event()
        {
            this.eventMedias = new HashSet<eventMedia>();
        }
    
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
    
        public virtual campaign campaign { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eventMedia> eventMedias { get; set; }
        public virtual eventType eventType { get; set; }
        public virtual loginVolunteer loginVolunteer { get; set; }
        public virtual loginVolunteer loginVolunteer1 { get; set; }
    }
}
