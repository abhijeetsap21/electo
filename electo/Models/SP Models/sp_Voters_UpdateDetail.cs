using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace electo.Models.SP_Models
{
    public class sp_Voters_UpdateDetail
    {
        public long CampaignId { get; set; }
        public long PageInchargeId { get; set; }
        public long VoterId { get; set; }
        public string VoterName { get; set; }       
        public string VoterLastName { get; set; }
        public string Father_HusbandName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ChangeType { get; set; }
        public string CommentDetail { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public long volunteerID { get; set; }
        public string plotNo { get; set; }
    }
}