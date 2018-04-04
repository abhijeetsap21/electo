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
    
    public partial class loginVolunteer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public loginVolunteer()
        {
            this.areaNames = new HashSet<areaName>();
            this.areaNames1 = new HashSet<areaName>();
            this.Biography_s = new HashSet<Biography_s>();
            this.Biography_s1 = new HashSet<Biography_s>();
            this.campaignPrices = new HashSet<campaignPrice>();
            this.campaignPrices1 = new HashSet<campaignPrice>();
            this.campaigns = new HashSet<campaign>();
            this.campaigns1 = new HashSet<campaign>();
            this.compaignVolunteerRelationships = new HashSet<compaignVolunteerRelationship>();
            this.compaignVolunteerRelationships1 = new HashSet<compaignVolunteerRelationship>();
            this.districts = new HashSet<district>();
            this.districts1 = new HashSet<district>();
            this.electionNames = new HashSet<electionName>();
            this.electionNames1 = new HashSet<electionName>();
            this.electionTypes = new HashSet<electionType>();
            this.electionTypes1 = new HashSet<electionType>();
            this.enquiries = new HashSet<enquiry>();
            this.enquiryTypes = new HashSet<enquiryType>();
            this.enquiryTypes1 = new HashSet<enquiryType>();
            this.eventMedias = new HashSet<eventMedia>();
            this.events = new HashSet<@event>();
            this.events1 = new HashSet<@event>();
            this.eventTypes = new HashSet<eventType>();
            this.eventTypes1 = new HashSet<eventType>();
            this.loginVolunteer1 = new HashSet<loginVolunteer>();
            this.loginVolunteer11 = new HashSet<loginVolunteer>();
            this.lokSabhaConstituencies = new HashSet<lokSabhaConstituency>();
            this.lokSabhaConstituencies1 = new HashSet<lokSabhaConstituency>();
            this.municipalCorporationNames = new HashSet<municipalCorporationName>();
            this.municipalCorporationNames1 = new HashSet<municipalCorporationName>();
            this.news = new HashSet<news>();
            this.news1 = new HashSet<news>();
            this.pageInchargeAssignedAreas = new HashSet<pageInchargeAssignedArea>();
            this.pageInchargeAssignedAreas1 = new HashSet<pageInchargeAssignedArea>();
            this.pageInchargeComments = new HashSet<pageInchargeComment>();
            this.pageInchargeComments1 = new HashSet<pageInchargeComment>();
            this.politicalParties = new HashSet<politicalParty>();
            this.politicalParties1 = new HashSet<politicalParty>();
            this.politicalPartyAddresses = new HashSet<politicalPartyAddress>();
            this.politicalPartyAddresses1 = new HashSet<politicalPartyAddress>();
            this.pollingBooths = new HashSet<pollingBooth>();
            this.pollingBooths1 = new HashSet<pollingBooth>();
            this.pollingBooth_andInchargRelationship = new HashSet<pollingBooth_andInchargRelationship>();
            this.pollingBooth_andInchargRelationship1 = new HashSet<pollingBooth_andInchargRelationship>();
            this.questionTypes = new HashSet<questionType>();
            this.questionTypes1 = new HashSet<questionType>();
            this.states = new HashSet<state>();
            this.states1 = new HashSet<state>();
            this.surveys = new HashSet<survey>();
            this.surveys1 = new HashSet<survey>();
            this.surveyQuestions = new HashSet<surveyQuestion>();
            this.surveyQuestions1 = new HashSet<surveyQuestion>();
            this.surveyResponses = new HashSet<surveyRespons>();
            this.userTypes = new HashSet<userType>();
            this.userTypes1 = new HashSet<userType>();
            this.vidhanSabhaConstituencies = new HashSet<vidhanSabhaConstituency>();
            this.vidhanSabhaConstituencies1 = new HashSet<vidhanSabhaConstituency>();
            this.volunteerLists = new HashSet<volunteerList>();
            this.volunteerLists1 = new HashSet<volunteerList>();
            this.voterLists = new HashSet<voterList>();
            this.voterLists1 = new HashSet<voterList>();
            this.wardConstituencies = new HashSet<wardConstituency>();
            this.wardConstituencies1 = new HashSet<wardConstituency>();
            this.zoneMunicipalities = new HashSet<zoneMunicipality>();
            this.zoneMunicipalities1 = new HashSet<zoneMunicipality>();
        }
    
        public long loginID { get; set; }
        public long voterID { get; set; }
        public string userID { get; set; }
        public int userTypeID { get; set; }
        public string password { get; set; }
        public System.DateTime dataIsCreated { get; set; }
        public System.DateTime dataIsUpdated { get; set; }
        public long createdBy { get; set; }
        public long modifiedBy { get; set; }
        public bool isActive { get; set; }
        public bool isBlocked { get; set; }
        public System.DateTime lastLogin { get; set; }
        public System.DateTime LastbadAttempt { get; set; }
        public int fakeAttemptCount { get; set; }
        public long volunteerID { get; set; }
        public string mobile { get; set; }
        public string fullName { get; set; }
        public string userPhoto { get; set; }
        public string voterAadharNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<areaName> areaNames { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<areaName> areaNames1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biography_s> Biography_s { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biography_s> Biography_s1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<campaignPrice> campaignPrices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<campaignPrice> campaignPrices1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<campaign> campaigns { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<campaign> campaigns1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<compaignVolunteerRelationship> compaignVolunteerRelationships { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<compaignVolunteerRelationship> compaignVolunteerRelationships1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<district> districts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<district> districts1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<electionName> electionNames { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<electionName> electionNames1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<electionType> electionTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<electionType> electionTypes1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<enquiry> enquiries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<enquiryType> enquiryTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<enquiryType> enquiryTypes1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eventMedia> eventMedias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<@event> events { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<@event> events1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eventType> eventTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eventType> eventTypes1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<loginVolunteer> loginVolunteer1 { get; set; }
        public virtual loginVolunteer loginVolunteer2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<loginVolunteer> loginVolunteer11 { get; set; }
        public virtual loginVolunteer loginVolunteer3 { get; set; }
        public virtual userType userType { get; set; }
        public virtual volunteerList volunteerList { get; set; }
        public virtual voterList voterList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lokSabhaConstituency> lokSabhaConstituencies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lokSabhaConstituency> lokSabhaConstituencies1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<municipalCorporationName> municipalCorporationNames { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<municipalCorporationName> municipalCorporationNames1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<news> news { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<news> news1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pageInchargeAssignedArea> pageInchargeAssignedAreas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pageInchargeAssignedArea> pageInchargeAssignedAreas1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pageInchargeComment> pageInchargeComments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pageInchargeComment> pageInchargeComments1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<politicalParty> politicalParties { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<politicalParty> politicalParties1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<politicalPartyAddress> politicalPartyAddresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<politicalPartyAddress> politicalPartyAddresses1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pollingBooth> pollingBooths { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pollingBooth> pollingBooths1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pollingBooth_andInchargRelationship> pollingBooth_andInchargRelationship { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pollingBooth_andInchargRelationship> pollingBooth_andInchargRelationship1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<questionType> questionTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<questionType> questionTypes1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<state> states { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<state> states1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<survey> surveys { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<survey> surveys1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<surveyQuestion> surveyQuestions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<surveyQuestion> surveyQuestions1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<surveyRespons> surveyResponses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userType> userTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userType> userTypes1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vidhanSabhaConstituency> vidhanSabhaConstituencies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vidhanSabhaConstituency> vidhanSabhaConstituencies1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<volunteerList> volunteerLists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<volunteerList> volunteerLists1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<voterList> voterLists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<voterList> voterLists1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wardConstituency> wardConstituencies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wardConstituency> wardConstituencies1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<zoneMunicipality> zoneMunicipalities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<zoneMunicipality> zoneMunicipalities1 { get; set; }
    }
}