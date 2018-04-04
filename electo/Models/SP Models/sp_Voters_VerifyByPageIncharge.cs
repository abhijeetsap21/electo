using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace electo.Models.SP_Models
{
    public class sp_Voters_VerifyByPageIncharge
    {
        public long CampaignId { get; set; }
        public long PageInchargeId { get; set; }
        public long VoterId { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
    }
}