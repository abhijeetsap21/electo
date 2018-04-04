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
    
    public partial class municipalCorporationName
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public municipalCorporationName()
        {
            this.wardConstituencies = new HashSet<wardConstituency>();
            this.zoneMunicipalities = new HashSet<zoneMunicipality>();
        }
    
        public int municipalCorporationID { get; set; }
        public string municipalCorporationName1 { get; set; }
        public int districtID { get; set; }
        public System.DateTime dataIsCreated { get; set; }
        public System.DateTime datatIsUpdated { get; set; }
        public long createdBy { get; set; }
        public long modifiedBy { get; set; }
        public int stateID { get; set; }
        public bool isActive { get; set; }
    
        public virtual district district { get; set; }
        public virtual loginVolunteer loginVolunteer { get; set; }
        public virtual loginVolunteer loginVolunteer1 { get; set; }
        public virtual state state { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wardConstituency> wardConstituencies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<zoneMunicipality> zoneMunicipalities { get; set; }
    }
}