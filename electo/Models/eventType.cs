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
    
    public partial class eventType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public eventType()
        {
            this.events = new HashSet<@event>();
        }
    
        public int eventTypeID { get; set; }
        public string eventName { get; set; }
        public System.DateTime dataIsCreated { get; set; }
        public System.DateTime dataIsUpdated { get; set; }
        public long createdBy { get; set; }
        public long modifiedBy { get; set; }
        public bool isActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<@event> events { get; set; }
        public virtual loginVolunteer loginVolunteer { get; set; }
        public virtual loginVolunteer loginVolunteer1 { get; set; }
    }
}
