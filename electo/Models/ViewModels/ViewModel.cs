using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace electo.Models
{
    public class ViewModel
    {

    }
    public class CreatePartyViewModel
    {

        public politicalParty _politicalParty { get; set; }
        public politicalPartyAddress _politicalPartyAddress { get; set; }
    }

    public class CreateVolunteerLogin
    {
        [Display(Name = "Political Party")]
        [Required(ErrorMessage = "Political party name required ")]
        public int politicalPartyID { get; set; }


        [StringLength(13, ErrorMessage = "13 digit max")]
        [Required(ErrorMessage = "Telephone/Mobile required ")]
        [Display(Name = "Telephone/Mobile")]
        public string mobile { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name required ")]
        public string fullName { get; set; }

        [Required(ErrorMessage = "Volunteer email id required")]
        [EmailAddress]
        [Display(Name = "Email id")]
        public string userID { get; set; }
        public string voterID { get; set; }

        public bool isActive { get; set; }

        public bool isBlocked { get; set; }

        [StringLength(16, MinimumLength = 16, ErrorMessage = "16 digit max")]
        [Required(ErrorMessage = "AAdhar No required")]
        [Display(Name = "AAdhar No")]
        public string AadharCardNumber { get; set; }

        public Int64 createdBy { get; set; }

        [Required(ErrorMessage = "User type required")]
        [Display(Name = "User type")]
        public int userTypeID { get; set; }
    }

    [MetadataType(typeof(politicalPartyViewModel))]
    public partial class politicalParty
    {
    }


    public class politicalPartyViewModel
    {
        [StringLength(200, MinimumLength = 3, ErrorMessage = "120 charectar max")]
        [Required(ErrorMessage = "Party name required")]
        [Display(Name = "Party name")]
        public string politicalPartyName { get; set; }

        [Display(Name = "Party website url")]
        [Required(ErrorMessage = "Official website address required")]
        public string politicalPartyWebsiteUrl { get; set; }

        [Required(ErrorMessage = "Party official email id required")]
        [EmailAddress]
        [Display(Name = "Email id")]
        public string politicalPartyEmail { get; set; }
    }

    [MetadataType(typeof(loginVolunteerViewModel))]
    public partial class loginVolunteer
    {

    }
    public class loginVolunteerViewModel
    {
        [StringLength(13, MinimumLength = 10, ErrorMessage = "13 digit max")]
        [Required(ErrorMessage = "Telephone/Mobile required ")]
        [Display(Name = "Telephone/Mobile")]
        public string mobile { get; set; }

        [StringLength(16, MinimumLength = 16, ErrorMessage = "16 digit max")]
        [Required(ErrorMessage = "AAdhar No required")]
        [Display(Name = "AAdhar No")]
        public string voterAadharNumber { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name required ")]
        public string fullName { get; set; }
    }



    [MetadataType(typeof(politicalPartyAddressViewModel))]
    public partial class politicalPartyAddress
    {
    }

    public class politicalPartyAddressViewModel
    {
        [Required(ErrorMessage = "District is Required ")]
        [Display(Name = "District")]
        public int districtID { get; set; }

        [Required(ErrorMessage = "State is Required ")]
        [Display(Name = "State")]
        public int stateID { get; set; }


        [Display(Name = "Plot number")]
        public string plotNo { get; set; }

        [Display(Name = "Street number")]
        public string streetNo { get; set; }

        [Display(Name = "Address1")]
        public string address1 { get; set; }

        [Display(Name = "Address2")]
        public string address2 { get; set; }


        [Display(Name = "Pin code")]
        [Required(ErrorMessage = "Pin code required ")]
        public int pincode { get; set; }

        [StringLength(13, ErrorMessage = "13 digit max")]
        [Required(ErrorMessage = "Telephone/Mobile required ")]
        [Display(Name = "Telephone/Mobile")]
        public string telephone { get; set; }
    }

    [MetadataType(typeof(questionTypeViewModel))]
    public partial class questionType
    {
    }

    public class questionTypeViewModel
    {
        [Display(Name = "Question Type")]
        [Required(ErrorMessage = "Question Type required ")]
        public string questionType1 { get; set; }


        [Display(Name = "Date")]
        public System.DateTime dataIsCreated { get; set; }

        [Display(Name = "Active")]
        public bool isActve { get; set; }
    }


    [MetadataType(typeof(eventTypeViewModel))]
    public partial class eventType
    {
    }

    public class eventTypeViewModel
    {
        [Display(Name = "Event Name")]
        [Required(ErrorMessage = "Event Name required ")]
        public string eventName { get; set; }


        [Display(Name = "Date")]
        public System.DateTime dataIsCreated { get; set; }

        [Display(Name = "Active")]
        public bool isActive { get; set; }
    }

    [MetadataType(typeof(areaNameViewModel))]
    public partial class areaName
    {

    }
    public class areaNameViewModel
    {
        [Display(Name = "Area Name")]
        [Required(ErrorMessage = "Area Name required ")]
        public string areaName1 { get; set; }

        [Display(Name = "Vidhan Sabha ")]
        [Required(ErrorMessage = "Vidhan Sabha Required")]
        public int vidhanSabhaConstituencyID { get; set; }

        [Display(Name = "Lok Sabha ")]
        [Required(ErrorMessage = "Lok Sabha Required")]
        public int lokSabhaConstituencyID { get; set; }

        [Display(Name = "Ward")]
        [Required(ErrorMessage = "Ward Required")]
        public int wardID { get; set; }

        [Display(Name = "District")]
        [Required(ErrorMessage = "District Required")]
        public int districtID { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State Required")]
        public int stateID { get; set; }

        [Display(Name = "Polling Booth")]
        [Required(ErrorMessage = "Polling Booth Required")]
        public int pollingBoothID { get; set; }
    }



    [MetadataType(typeof(pollingBoothViewModel))]
    public partial class pollingBooth
    {

    }
    public class pollingBoothViewModel
    {
        [Display(Name = "Polling Booth")]
        [Required(ErrorMessage = "Polling Booth Required")]
        public string pollingBoothName { get; set; }

        [Display(Name = "Vidhan Sabha ")]
        [Required(ErrorMessage = "Vidhan Sabha Required")]
        public int vidhanSabhaConstituencyID { get; set; }

        [Display(Name = "Lok Sabha ")]
        [Required(ErrorMessage = "Lok Sabha Required")]
        public int lokSabhaConstituencyID { get; set; }

        [Display(Name = "Ward")]
        [Required(ErrorMessage = "Ward Required")]
        public int wardID { get; set; }

        [Display(Name = "District")]
        [Required(ErrorMessage = "District Required")]
        public int districtID { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State Required")]
        public int stateID { get; set; }

        [Display(Name = "Plot No")]
        [Required(ErrorMessage = "Plot Number Required")]
        public string plotNo { get; set; }

        [Display(Name = "Street Number")]
        [Required(ErrorMessage = "Street Number Required")]
        public string streetNo { get; set; }

        [Display(Name = "Address 1 ")]
        [Required(ErrorMessage = "Address Line 1 Required")]
        public string address1 { get; set; }

        [Display(Name = "Address 2 ")]
        [Required(ErrorMessage = "Address Line 2 Required")]
        public string address2 { get; set; }

        [Display(Name = "Pin code ")]
        [Required(ErrorMessage = "Pincode Required")]
        public int pincode { get; set; }
    }

    [MetadataType(typeof(campaignPriceViewModel))]
    public partial class campaignPrice
    {

    }

    public class campaignPriceViewModel
    {
        public int campaignPriceID { get; set; }

        [Display(Name = "Election Type")]
        [Required(ErrorMessage = "Election Type required ")]
        public int electionTypeID { get; set; }

        [Display(Name = "Year")]
        [Required(ErrorMessage = "Election year required ")]
        public string year { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "price required ")]
        public int price { get; set; }

        [Display(Name = "Active")]
        public bool isActive { get; set; }
    }


    public class ChangePasswordViewModel
    {

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.Web.Mvc.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginIdViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }


    [MetadataType(typeof(vidhanSabhaConstituencyViewModel))]
    public partial class vidhanSabhaConstituency { }

    public class vidhanSabhaConstituencyViewModel
    {

        [Required(ErrorMessage = "Lock Sabha required")]
        [Display(Name = "Lock Sabha")]
        public int lokSabhaConstituencyID { get; set; }

        [Required(ErrorMessage = "Vidhan Sabha required")]
        [Display(Name = "Vidhan Sabha Name")]
        public string vidhanSabhaConstituencyName { get; set; }

        [Required(ErrorMessage = "State required")]
        [Display(Name = "State")]
        public int stateID { get; set; }

        [Required(ErrorMessage = "District required")]
        [Display(Name = "District")]
        public int districtID { get; set; }
    }


    [MetadataType(typeof(stateViewModel))]
    public partial class state
    {
    }
    public class stateViewModel
    {
        [StringLength(120, MinimumLength = 3, ErrorMessage = "120 charectar max")]
        [Required(ErrorMessage = "State name required")]
        [Display(Name = "State")]
        public string stateName { get; set; }

    }

    [MetadataType(typeof(districtViewModel))]
    public partial class district
    {
    }
    public class districtViewModel
    {

        [Required(ErrorMessage = "State name required")]
        [Display(Name = "State")]
        public int stateID { get; set; }


        [StringLength(120, MinimumLength = 3, ErrorMessage = "120 charectar max")]
        [Required(ErrorMessage = "District name required")]
        [Display(Name = "District")]
        public string districtName { get; set; }
    }



    [MetadataType(typeof(lokSabhaConstituencyViewModel))]
    public partial class lokSabhaConstituency
    {
    }
    public class lokSabhaConstituencyViewModel
    {
        [Required(ErrorMessage = "state field required")]
        [Display(Name = "State")]
        public int stateID { get; set; }


        [Required(ErrorMessage = "District field required")]
        [Display(Name = "District")]
        public string districtID { get; set; }


        [StringLength(120, MinimumLength = 3, ErrorMessage = "120 charectar max")]
        [Required(ErrorMessage = "Loksabha name required")]
        [Display(Name = "Lok Sabha")]
        public string lokSabhaConstituencyName { get; set; }
    }

    [MetadataType(typeof(electionNameViewModel))]
    public partial class electionName
    {
    }
    public class electionNameViewModel
    {
        [Required(ErrorMessage = "Election Year required")]
        [Display(Name = "Election Year")]
        public int electionYear { get; set; }


        [Required(ErrorMessage = "Election Type field required")]
        [Display(Name = "Election Type")]
        public string electionTypeID { get; set; }


        [StringLength(120, MinimumLength = 3, ErrorMessage = "120 charectar max")]
        [Required(ErrorMessage = "Election name required")]
        [Display(Name = "Election Name")]
        public string electionName1 { get; set; }


        [Required(ErrorMessage = "Election Month required")]
        [Display(Name = "Month")]
        public int monthId { get; set; }
    }


    [MetadataType(typeof(municipalCorporationNameViewModel))]
    public partial class municipalCorporationName
    { }
    public class municipalCorporationNameViewModel
    {
        [StringLength(120, MinimumLength = 3, ErrorMessage = "120 charectar max")]
        [Required(ErrorMessage = "Election required")]
        [Display(Name = "Municipal Corp. Name")]
        public string municipalCorporationName1 { get; set; }

        [Required(ErrorMessage = "District required")]
        [Display(Name = "District")]
        public int districtID { get; set; }

        [Required(ErrorMessage = "State required")]
        [Display(Name = "State")]
        public int stateID { get; set; }

    }
    [MetadataType(typeof(zoneMunicipalityViewModel))]
    public partial class zoneMunicipality { }

    public class zoneMunicipalityViewModel
    {

        [StringLength(120, MinimumLength = 3, ErrorMessage = "120 charectar max")]
        [Required(ErrorMessage = "Zone name required")]
        [Display(Name = "Zone Name")]
        public string zoneName { get; set; }



        [Required(ErrorMessage = "Election name required")]
        [Display(Name = "Municipal Corporation")]
        public int municipalCorporationID { get; set; }

        [Required(ErrorMessage = "State field required")]
        [Display(Name = "State")]
        public int stateID { get; set; }

        [Required(ErrorMessage = "District field required")]
        [Display(Name = "District")]
        public int districtID { get; set; }

    }
    [MetadataType(typeof(wardConstituencyViewModel))]
    public partial class wardConstituency { }

    public class wardConstituencyViewModel
    {

        [Required(ErrorMessage = "Election name required")]
        [Display(Name = "Municipal Corporation")]
        public int municipalCorporationID { get; set; }

        [Required(ErrorMessage = "State  required")]
        [Display(Name = "State")]
        public int stateID { get; set; }

        [Required(ErrorMessage = "District  required")]
        [Display(Name = "District")]
        public int districtID { get; set; }

        [Required(ErrorMessage = "Zone  required")]
        [Display(Name = "Zone")]
        public int zoneID { get; set; }


        [Required(ErrorMessage = "Ward No required")]
        [Display(Name = "Ward No")]
        public int wardNo { get; set; }


        [StringLength(120, MinimumLength = 3, ErrorMessage = "120 charectar max")]
        [Required(ErrorMessage = "Ward name required")]
        [Display(Name = "Ward Name")]
        public string wardName { get; set; }

        [Required(ErrorMessage = "Vidhan Sabha required")]
        [Display(Name = "Vidhan Sabha")]
        public int vidhanSabhaConstituencyID { get; set; }


    }


    [MetadataType(typeof(languageViewModel))]
    public partial class language { }
    public class languageViewModel
    {
        [StringLength(50, MinimumLength = 3, ErrorMessage = "50 charectar max")]
        [Required(ErrorMessage = "Language required")]
        [Display(Name = "Language")]
        public string language1 { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "50 charectar max")]
        [Required(ErrorMessage = "Font family required")]
        [Display(Name = "Font Family")]
        public string fontUsed { get; set; }
    }


    public class CompaignAdmin
    {
        [Required(ErrorMessage = "Election Type required")]
        [Display(Name = "Election Type")]
        public int electionTypeID { get; set; }


        [Required(ErrorMessage = "Campaign name required")]
        [Display(Name = "Campaign Name")]
        public int campaignID { get; set; }


    }


    [MetadataType(typeof(surveyViewModel))]
    public partial class survey { }
    public class surveyViewModel
    {
       
        [Required(ErrorMessage = "Campaign is required")]
        [Display(Name = "Campaign")]
        public string campaignID { get; set; }

        
        [StringLength(50, MinimumLength = 3, ErrorMessage = "50 charectar max")]
        [Required(ErrorMessage = "Survey title required")]
        [Display(Name = "Title")]
        public string surveyTitle { get; set; }

        [AllowHtml]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "50 charectar max")]
        [Required(ErrorMessage = "Survey description required")]
        [Display(Name = "Description")]
        public string surveyDescription { get; set; }

        [Required(ErrorMessage = "Survey start date required")]
        [Display(Name = "Start Date")]
        public System.DateTime startDate { get; set; }

        [Required(ErrorMessage = "Survey end date required")]
        [Display(Name = "End Date")]
        public System.DateTime endDate { get; set; }
    }

    public class surveyQuestionViewModel {


        public long surveyID { get; set; }

        [Display(Name = "Serial No")]
        [Required(ErrorMessage = "Question serial no. required")]
        public int questionSerial { get; set; }

        [Display(Name = "Question")]
        [Required(ErrorMessage = "Question text required")]
        public string question { get; set; }

        [Display(Name = "Question Type")]
        [Required(ErrorMessage = "Question Type required")]
        public int questionTypeID { get; set; }

        [Display(Name = "Option 1")]
        [Required(ErrorMessage = "Option 1 required")]
        public string questionOP1 { get; set; }

        [Display(Name = "Option 2")]
        [Required(ErrorMessage = "Option 2 required")]
        public string questionOP2 { get; set; }

        [Display(Name = "Option 3")]
        [Required(ErrorMessage = "Option 3 required")]
        public string questionOP3 { get; set; }

        [Display(Name = "Option 4")]
        [Required(ErrorMessage = "Option 4 required")]
        public string questionOP4 { get; set; }
    }

    [MetadataType(typeof(campaignviewmodel))]
    public partial class campaign
    {

    }
    public class campaignviewmodel
    {
        [Display(Name = "Election Type")]
        [Required(ErrorMessage = "Election Type required ")]
        public int electionTypeID { get; set; }

        [Display(Name = "Capaign Name")]
        [Required(ErrorMessage = "Campaign name required ")]
        public int campaignName { get; set; }

        [Display(Name = "Election")]
        [Required(ErrorMessage = "Election name required ")]
        public int electionID { get; set; }

        [Display(Name = "Political Party")]
        [Required(ErrorMessage = "Political Party ")]
        public int politicalPartyID { get; set; }

        [Display(Name = "Lok Sabha")]
        public int lokSabhaConstituencyID { get; set; }

        [Display(Name = "Vidhan Sabha")]        
        public int vidhanSabhaConstituencyID { get; set; }
    }

    [MetadataType(typeof(newsviewmodel))]
    public partial class news
    {

    }
    public class newsviewmodel
    {
        [Display(Name = "Election Type")]
        [Required(ErrorMessage = "Election Type required ")]
        public int electionTypeID { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title required ")]
        public string title { get; set; }

        [Display(Name = "News Description")]
        [AllowHtml]
        [Required(ErrorMessage = "News Description required ")]
        public string description { get; set; }

        [Display(Name = "Upload Image")]
        [Required(ErrorMessage = "Image required ")]
        public string imageURL { get; set; }
    }
    [MetadataType(typeof(Biography_sviewmodel))]
    public partial class Biography_s { }
    public class Biography_sviewmodel
    {
        [Display(Name = "Person Name")]
        [Required(ErrorMessage = "Person name required ")]
        public string personName { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography required ")]
        public string description { get; set; }
    }


    public class  AssignPollingBoothToPollingBoothIncharge
    {
        public Int64 campaignid { get; set; }
        public Int64 voluntearID { get; set; }

        [Display(Name = "Polling Booth")]
        [Required(ErrorMessage = "Polling Booth required")]
        public Int64 PollingBoothID { get; set; }
        public string voterName { get; set; }
    }

   
    public class PageInchargeAssignAreaviewmodel
    {
        [Display(Name = "Area")]
        [Required(ErrorMessage = "Election Type required ")]
        public long areaID { get; set; }
        public long volunteerID { get; set; }
        public long campaignID { get; set; }
        public string voterName { get; set; }
    }
    [MetadataType(typeof(voterListViewModel))]
    public partial class voterList {
        
    }
    public  class voterListViewModel  {
        [Required(ErrorMessage = "State required")]
        [Display(Name = "State")]
        public int stateID { get; set; }

        [Required(ErrorMessage = "Lok sabha required")]
        [Display(Name = "Lok Sabha ")]
        public int lokSabhaConstituencyID { get; set; }


        [Required(ErrorMessage = "Vidhan sabha required")]
        [Display(Name = "Vidhan Sabha ")]
        public int vidhanSabhaConstituencyID { get; set; }

        [Required(ErrorMessage = "Ward required")]
        [Display(Name = "Ward")]
        public int wardID { get; set; }

        [Required(ErrorMessage = "Area name required")]
        [Display(Name = "Area Name")]
        public long areaID { get; set; }

        [Required(ErrorMessage = "Pin code required")]
        [Display(Name = "Pin Code")]
        public int pincode { get; set; } 

        [Required(ErrorMessage = "Langauge required")]
        [Display(Name = "Langauge")]
        public Nullable<int> regionalLanguage { get; set; }
       

        [Required(ErrorMessage = "Voter name required")]
        [Display(Name = "First Name")]
        public string voterName { get; set; }

        [Required(ErrorMessage = "Voter name required")]
        [Display(Name = "Last Name")]
        public string voterLastName { get; set; }

        [Required(ErrorMessage = "Father/Husband name required")]
        [Display(Name = "F/H Name")]
        public string voterFather_HusbandName { get; set; }

        [Required(ErrorMessage = "Plot number required")]
        [Display(Name = "Plot No")]
        public string plotNo { get; set; }

      
        [Display(Name = "Street No")]
        public string streetNo { get; set; }

        [Required(ErrorMessage = "Gender required")]
        [Display(Name = "Gender")]
        public int genderID { get; set; }

        [Required(ErrorMessage = "Voter id number required")]
        [Display(Name = "Voter Id Number")]
        public string voterIDNumber { get; set; }       

       
        [Display(Name = "Date Of Birth")]
        public System.DateTime dateOfBirth { get; set; }

    }

    
}