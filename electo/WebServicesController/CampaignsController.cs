using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using electo.Models;
using electo.Models.IRepositories;
using electo.Models.Repositories;

namespace electo.WebServicesController
{
    public class CampaignsController : ApiController
    {
        // private electoEntities db = new electoEntities();
        private readonly ICampaignService _campaignService;
        public CampaignsController()
        {
            _campaignService = new CampaignService();
        }
        /// <summary>
        /// Get All Campaigns
        /// </summary>
        /// <returns></returns>
        /// //IEnumerable<sp_Campaigns_GetAll_Result> GetAll();
        //public HttpResponseMessage GetCampaigns()
        //{
        //    var objCampaignList = _campaignService.GetAll();

        //    if (objCampaignList != null)
        //    {
        //        var campaignEntities = objCampaignList as List<sp_Campaigns_GetAll_Result> ?? objCampaignList.ToList();

        //        if (campaignEntities.Any())
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK, campaignEntities);
        //        }
        //    }
        //    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Campaign data not found");
        //}
        public IHttpActionResult GetCampaigns()
        {
            var objCampaignList = _campaignService.GetAll();

            if (objCampaignList != null)
            {
                var campaignEntities = objCampaignList as List<sp_Campaigns_GetAll_Result> ?? objCampaignList.ToList();

                if (campaignEntities.Any())
                {
                    return Json(new { status = "Success", msg = "Record found", data = campaignEntities });
                    //return Request.CreateResponse(HttpStatusCode.OK, campaignEntities);
                }
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Campaign data not found");
            return Json(new { status = "Error", msg = "Record not found"});
        }

        /// <summary>
        /// Get Campaigns By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// //sp_Campaigns_GetById_Result GetById(long Id);
        public IHttpActionResult GetCampaigns(long Id)
        {
            var objCampaign = _campaignService.GetById(Id);

            if (objCampaign != null)
            {
                var campaignEntity = objCampaign as sp_Campaigns_GetById_Result ?? objCampaign;

                if (campaignEntity != null)
                {
                    return Json (new { status = "Success", msg = "Record found", data = campaignEntity });
                }
            }
            return Json(new { status = "Error", msg = "Record not found" });
        }

        /// <summary>
        /// Get Campaigns By ElectionTypeId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// //IEnumerable<sp_Campaigns_GetByElectionTypeId_Result> GetByElectionTypeId(long Id);
        public IHttpActionResult GetByElectionType(long Id)
        {
            var objCampaignList = _campaignService.GetByElectionTypeId(Id);

            if (objCampaignList != null)
            {
                var campaignEntities = objCampaignList as List<sp_Campaigns_GetByElectionTypeId_Result> ?? objCampaignList.ToList();

                if (campaignEntities.Any())                {
                    
                    return Json(new { status = "Success", msg = "Record found", data = campaignEntities });
                }
            }
            return Json(new { status = "Error", msg = "Record not found" });
        }

        //IEnumerable<sp_Campaigns_GetByElectionId_Result> GetByElectionId(long Id);
        public IHttpActionResult GetByElection(long Id)
        {
            var objCampaignList = _campaignService.GetByElectionId(Id);

            if (objCampaignList != null)
            {
                var campaignEntities = objCampaignList as List<sp_Campaigns_GetByElectionId_Result> ?? objCampaignList.ToList();

                if (campaignEntities.Any())
                {
                    return Json(new { status = "Success", msg = "Record found", data = campaignEntities });
                   
                }
            }
            return Json(new { status = "Error", msg = "Record not found" });
        }

        //IEnumerable<sp_Campaigns_GetByLokSabhaConstituencyId_Result> GetByLokSabhaConstituencyId(long Id);
        public IHttpActionResult GetByLokSabhaConstituency(long Id)
        {
            var objCampaignList = _campaignService.GetByLokSabhaConstituencyId(Id);

            if (objCampaignList != null)
            {
                var campaignEntities = objCampaignList as List<sp_Campaigns_GetByLokSabhaConstituencyId_Result> ?? objCampaignList.ToList();

                if (campaignEntities.Any())
                {                    
                    return Json(new { status = "Success", msg = "Record found", data = campaignEntities });
                }
            }
            return Json(new { status = "Error", msg = "Record not found" });
        }

        //IEnumerable<sp_Campaigns_GetByPoliticalPartyId_Result> GetByPoliticalPartyId(long Id);
        public IHttpActionResult GetByPoliticalParty(long Id)
        {
            var objCampaignList = _campaignService.GetByPoliticalPartyId(Id);

            if (objCampaignList != null)
            {
                var campaignEntities = objCampaignList as List<sp_Campaigns_GetByPoliticalPartyId_Result> ?? objCampaignList.ToList();

                if (campaignEntities.Any())
                {
                    
                    return Json(new { status = "Success", msg = "Record found", data = campaignEntities });
                }
            }
            return Json(new { status = "Error", msg = "Record not found" });
        }

        //IEnumerable<sp_Campaigns_GetByVidhanSabhaConstituencyId_Result> GetByVidhanSabhaConstituencyId(long Id);
        public IHttpActionResult GetByVidhanSabhaConstituency(long Id)
        {
            var objCampaignList = _campaignService.GetByVidhanSabhaConstituencyId(Id);

            if (objCampaignList != null)
            {
                var campaignEntities = objCampaignList as List<sp_Campaigns_GetByVidhanSabhaConstituencyId_Result> ?? objCampaignList.ToList();

                if (campaignEntities.Any())
                {
                    return Json(new { status = "Success", msg = "Record found", data = campaignEntities });
                }
            }
            return Json(new { status = "Error", msg = "Record not found" });
        }

        //IEnumerable<sp_Campaigns_GetByVolunteerId_Result> GetByVolunteerId(long Id);
        public IHttpActionResult GetByVolunteer(long Id)
        {
            var objCampaignList = _campaignService.GetByVolunteerId(Id);

            if (objCampaignList != null)
            {
                var campaignEntities = objCampaignList as List<sp_Campaigns_GetByVolunteerId_Result> ?? objCampaignList.ToList();

                if (campaignEntities.Any())
                {                    
                    return Json(new { status = "Success", msg = "Record found", data = campaignEntities });
                }
            }
            return Json(new { status = "Error", msg = "Record not found" });
        }

        //IEnumerable<sp_Campaigns_GetByWardId_Result> GetByWardId(long Id);
        public IHttpActionResult GetByWard(long Id)
        {
            var objCampaignList = _campaignService.GetByWardId(Id);

            if (objCampaignList != null)
            {
                var campaignEntities = objCampaignList as List<sp_Campaigns_GetByWardId_Result> ?? objCampaignList.ToList();

                if (campaignEntities.Any())
                {                   
                    return Json(new { status = "Success", msg = "Record found", data = campaignEntities });
                }
            }
            return Json(new { status = "Error", msg = "Record not found" });
        }

        public IHttpActionResult GetSectionIncharge(long cmpID)
        {
            var sectionInchargeList = _campaignService.getAllSectionInchargeByCampaign(cmpID);

            if (sectionInchargeList != null)
            {
                var sectionInchargeEntities = sectionInchargeList as List<sp_GetAllSectionInchargeByCampaign_Result> ?? sectionInchargeList.ToList();

                if (sectionInchargeEntities.Any())
                {                   
                    return Json(new { status = "Success", msg = "Record found", data = sectionInchargeEntities });
                }
            }
            return Json(new { status = "Error", msg = "Record not found" });
        }
        //// GET: api/Campaigns
        //public IQueryable<campaign> Getcampaigns()
        //{
        //    return db.campaigns;
        //}

        //// GET: api/Campaigns/5
        //[ResponseType(typeof(campaign))]
        //public IHttpActionResult Getcampaign(long id)
        //{
        //    campaign campaign = db.campaigns.Find(id);
        //    if (campaign == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(campaign);
        //}

        //// PUT: api/Campaigns/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult Putcampaign(long id, campaign campaign)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != campaign.campaignID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(campaign).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!campaignExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Campaigns
        //[ResponseType(typeof(campaign))]
        //public IHttpActionResult Postcampaign(campaign campaign)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.campaigns.Add(campaign);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = campaign.campaignID }, campaign);
        //}

        //// DELETE: api/Campaigns/5
        //[ResponseType(typeof(campaign))]
        //public IHttpActionResult Deletecampaign(long id)
        //{
        //    campaign campaign = db.campaigns.Find(id);
        //    if (campaign == null)
        //    {
        //        return NotFound();
        //    }

        //    db.campaigns.Remove(campaign);
        //    db.SaveChanges();

        //    return Ok(campaign);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool campaignExists(long id)
        //{
        //    return db.campaigns.Count(e => e.campaignID == id) > 0;
        //}
    }
}