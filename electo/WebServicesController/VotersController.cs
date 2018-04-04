using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using electo.Models;
using electo.Models.IRepositories;
using electo.Models.Repositories;
using electo.Models.SP_Models;
using System.Web.Mvc;

namespace electo.WebServicesController
{
    public class VotersController : ApiController
    {
        //private electoEntities db = new electoEntities();
        private readonly IVotersServices _voterServices;

        public VotersController()
        {
            _voterServices = new VotersServices();
        }

        public IHttpActionResult GetVoters()
        {
            var objVoterList = _voterServices.GetAll();

            if (objVoterList != null)
            {
                var voterEntities = objVoterList as List<sp_Voters_GetAll_Result> ?? objVoterList.ToList();

                if (voterEntities.Any())
                {
                    //return Request.CreateResponse(HttpStatusCode.OK, voterEntities);
                    return Json(new { status = "Success", msg = "Record found", data = voterEntities });
                }
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Voters data not found");
            return Json(new { status = "Error", msg = "Record not found" });

        }
        public IHttpActionResult GetVoters(long Id)
        {
            var objVoter = _voterServices.GetById(Id);

            if (objVoter != null)
            {
                var voterEntity = objVoter as sp_Voters_GetById_Result ?? objVoter;

                if (voterEntity != null)
                {
                    //return Request.CreateResponse(HttpStatusCode.OK, voterEntity);
                    return Json(new { status = "Success", msg = "Record found", data = voterEntity });
                }
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Voter data not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }
        public IHttpActionResult GetByPageIncharge(long Id)
        {
            var objVoterList = _voterServices.GetByPageInchargeId(Id);

            if (objVoterList != null)
            {
                var voterEntities = objVoterList as List<sp_Voters_GetByPageInchargeId_Result> ?? objVoterList.ToList();

                if (voterEntities.Any())
                {
                    //return Request.CreateResponse(HttpStatusCode.OK, voterEntities);
                    return Json(new { status = "Success", msg = "Record found", data = voterEntities });
                }
            }
            // return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Voter data not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }
        //20180228
        //IEnumerable<sp_Voters_GetByStateId_Result> GetByStateId(long Id);
        public IHttpActionResult GetByState(long Id)
        {
            var objVoterList = _voterServices.GetByStateId(Id);

            if (objVoterList != null)
            {
                var voterEntities = objVoterList as List<sp_Voters_GetByStateId_Result> ?? objVoterList.ToList();

                if (voterEntities.Any())
                {
                    //return Request.CreateResponse(HttpStatusCode.OK, voterEntities);
                    return Json(new { status = "Success", msg = "Record found", data = voterEntities });
                }
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Voter data not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }
        //IEnumerable<sp_Voters_GetByAreaId_Result> GetByAreaId(long Id);
        public IHttpActionResult GetByArea(long Id)
        {
            var objVoterList = _voterServices.GetByAreaId(Id);

            if (objVoterList != null)
            {
                var voterEntities = objVoterList as List<sp_Voters_GetByAreaId_Result> ?? objVoterList.ToList();

                if (voterEntities.Any())
                {
                    //return Request.CreateResponse(HttpStatusCode.OK, voterEntities);
                    return Json(new { status = "Success", msg = "Record found", data = voterEntities });
                }
            }
            // return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Voter data not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }
        //IEnumerable<sp_Voters_GetByVidhanSabhaConstituencyId_Result> GetByVidhanSabhaConstituencyId(long Id);
        public IHttpActionResult GetByVidhanSabhaConstituency(long Id)
        {
            var objVoterList = _voterServices.GetByVidhanSabhaConstituencyId(Id);

            if (objVoterList != null)
            {
                var voterEntities = objVoterList as List<sp_Voters_GetByVidhanSabhaConstituencyId_Result> ?? objVoterList.ToList();

                if (voterEntities.Any())
                {
                    //return Request.CreateResponse(HttpStatusCode.OK, voterEntities);
                    return Json(new { status = "Success", msg = "Record found", data = voterEntities });
                }
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Voter data not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }
        //IEnumerable<sp_Voters_GetByLokSabhaConstituencyId_Result> GetByLokSabhaConstituencyId(long Id);
        public IHttpActionResult GetByLokSabhaConstituency(long Id)
        {
            var objVoterList = _voterServices.GetByLokSabhaConstituencyId(Id);

            if (objVoterList != null)
            {
                var voterEntities = objVoterList as List<sp_Voters_GetByLokSabhaConstituencyId_Result> ?? objVoterList.ToList();

                if (voterEntities.Any())
                {
                    //return Request.CreateResponse(HttpStatusCode.OK, voterEntities);
                    return Json(new { status = "Success", msg = "Record found", data = voterEntities });
                }
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Voter data not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }
        //IEnumerable<sp_Voters_GetByWardId_Result> GetByWardId(long Id);
        public IHttpActionResult GetByWard(long Id)
        {
            var objVoterList = _voterServices.GetByWardId(Id);

            if (objVoterList != null)
            {
                var voterEntities = objVoterList as List<sp_Voters_GetByWardId_Result> ?? objVoterList.ToList();

                if (voterEntities.Any())
                {
                    //return Request.CreateResponse(HttpStatusCode.OK, voterEntities);
                    return Json(new { status = "Success", msg = "Record found", data = voterEntities });
                }
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Voter data not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }
        //public string DeleteVoter(long Id)
        [System.Web.Http.HttpPost]
        public IHttpActionResult DeleteVoter(long Id)
        {
            string result = string.Empty;
            result = _voterServices.DeleteVoter(Id);
            //return Request.CreateResponse(HttpStatusCode.OK, result);
            return Json(new { status = "Success", msg = "Record found" });
        }
        //20180314
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult Update([FromBody]sp_Voters_UpdateDetail objVoter)
        {
            //sp_Voters_UpdateDetail objVoter = new sp_Voters_UpdateDetail();
            //objVoter.VoterName = 

            int result = _voterServices.UpdateDetail(objVoter);
            if (result == 1)
            {
                return Json(new { status = "Success", msg = "Record updated", data = result });
                //return Request.CreateResponse(HttpStatusCode.OK, "Voter detail updated successfully.");
                //return Ok("Voter detail updated successfully.");

            }
            else
            {
                return Json(new { status = "Error", msg = "Record not updated", data = result });
                //return Request.CreateResponse(HttpStatusCode.OK, "Error in update. Try again.");
            }
        }
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult VerifyVoterByPageIncharge([FromBody]sp_Voters_VerifyByPageIncharge objVoter)
        {
            int result = _voterServices.VerifyVoterByPageIncharge(objVoter);
            if (result == 1)
            {
                return Json(new { status = "Success", msg = "Verified", data = result });
            }
            else
            {
                return Json(new { status = "Error", msg = "Try again", data = result });
            }
        }

        //20180322
        //public IEnumerable<sp_SectionIncharge_GetAllByBoothIncharge_Result> GetAllByBoothIncharge(long CampaignId, long BoothInchargeId)
        public IHttpActionResult GetAllByBoothIncharge(long CampaignId, long BoothInchargeId)
        {
            var objVoterList = _voterServices.GetAllByBoothIncharge(CampaignId, BoothInchargeId);

            if (objVoterList != null)
            {
                var voterEntities = objVoterList as List<sp_SectionIncharge_GetAllByBoothIncharge_Result> ?? objVoterList.ToList();

                if (voterEntities.Any())
                {
                    //return Request.CreateResponse(HttpStatusCode.OK, voterEntities);
                    return Json(new { status = "Success", msg = "Record found", data = voterEntities });
                }
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Voter data not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }


        public IHttpActionResult getPageInchargeLocation(long CampaignId, long PageInchargeId, DateTime VisitedDate)
        {
            var PageInchargeLocationList = _voterServices.getPageInchargeLocation(CampaignId, PageInchargeId, VisitedDate);

            if (PageInchargeLocationList != null)
            {
                return Json(new { status = "Success", msg = "Record found", data = PageInchargeLocationList });
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Voter data not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }
    }
}