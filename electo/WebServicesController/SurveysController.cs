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
    public class SurveysController : ApiController
    {
        //private electoEntities db = new electoEntities();
        private readonly ISurveyServices _surveyServices;

        public SurveysController()
        {
            _surveyServices = new SurveyServices();
        }
        public IHttpActionResult GetSurveys()
        {
            var objSurveyList = _surveyServices.GetAll();

            if (objSurveyList != null)
            {
                var surveyEntities = objSurveyList as List<sp_Survey_GetAll_Result> ?? objSurveyList.ToList();

                if (surveyEntities.Any())
                {
                    //return Request.CreateResponse(HttpStatusCode.OK, surveyEntities);
                    return Json(new { status = "Success", msg = "Record found", data = surveyEntities });
                }
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Survey data not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }
        public IHttpActionResult GetByCampaign(long Id)
        {
            var objSurveyList = _surveyServices.GetByCampaignId(Id);

            if (objSurveyList != null)
            {
                var surveyEntities = objSurveyList as List<sp_Survey_GetByCampaignId_Result> ?? objSurveyList.ToList();

                if (surveyEntities.Any())
                {
                   // return Request.CreateResponse(HttpStatusCode.OK, surveyEntities);
                    return Json(new { status = "Success", msg = "Record found", data = surveyEntities });
                }
            }
            // return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Survey data not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }
        //// GET: api/Surveys
        //public IQueryable<survey> Getsurveys()
        //{
        //    return db.surveys;
        //}

        //// GET: api/Surveys/5
        //[ResponseType(typeof(survey))]
        //public IHttpActionResult Getsurvey(long id)
        //{
        //    survey survey = db.surveys.Find(id);
        //    if (survey == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(survey);
        //}

        //// PUT: api/Surveys/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult Putsurvey(long id, survey survey)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != survey.surveyID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(survey).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!surveyExists(id))
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

        //// POST: api/Surveys
        //[ResponseType(typeof(survey))]
        //public IHttpActionResult Postsurvey(survey survey)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.surveys.Add(survey);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = survey.surveyID }, survey);
        //}

        //// DELETE: api/Surveys/5
        //[ResponseType(typeof(survey))]
        //public IHttpActionResult Deletesurvey(long id)
        //{
        //    survey survey = db.surveys.Find(id);
        //    if (survey == null)
        //    {
        //        return NotFound();
        //    }

        //    db.surveys.Remove(survey);
        //    db.SaveChanges();

        //    return Ok(survey);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool surveyExists(long id)
        //{
        //    return db.surveys.Count(e => e.surveyID == id) > 0;
        //}
    }
}