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
    public class SurveyQuestionsController : ApiController
    {
        //private electoEntities db = new electoEntities();
        private readonly ISurveyQuestionServices _surveyQuestionServices;

        public SurveyQuestionsController()
        {
            _surveyQuestionServices = new SurveyQuestionServices();
        }

        //public IEnumerable<sp_SurveyQuestion_GetBySurveyId_Result> GetBySurveyId(long Id)
        public IHttpActionResult GetBySurvey(long Id)
        {
            var objSurveryQuestionList = _surveyQuestionServices.GetBySurveyId(Id);

            if (objSurveryQuestionList != null)
            {
                var surveyQuestionEntities = objSurveryQuestionList as List<sp_SurveyQuestion_GetBySurveyId_Result> ?? objSurveryQuestionList.ToList();

                if (surveyQuestionEntities.Any())
                {
                   // return Request.CreateResponse(HttpStatusCode.OK, surveyQuestionEntities);
                    return Json(new { status = "Success", msg = "Record found", data = surveyQuestionEntities });
                }
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Survey Question data not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }
        //// GET: api/SurveyQuestions
        //public IQueryable<surveyQuestion> GetsurveyQuestions()
        //{
        //    return db.surveyQuestions;
        //}

        //// GET: api/SurveyQuestions/5
        //[ResponseType(typeof(surveyQuestion))]
        //public IHttpActionResult GetsurveyQuestion(long id)
        //{
        //    surveyQuestion surveyQuestion = db.surveyQuestions.Find(id);
        //    if (surveyQuestion == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(surveyQuestion);
        //}

        //// PUT: api/SurveyQuestions/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutsurveyQuestion(long id, surveyQuestion surveyQuestion)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != surveyQuestion.surveyQuesID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(surveyQuestion).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!surveyQuestionExists(id))
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

        //// POST: api/SurveyQuestions
        //[ResponseType(typeof(surveyQuestion))]
        //public IHttpActionResult PostsurveyQuestion(surveyQuestion surveyQuestion)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.surveyQuestions.Add(surveyQuestion);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = surveyQuestion.surveyQuesID }, surveyQuestion);
        //}

        //// DELETE: api/SurveyQuestions/5
        //[ResponseType(typeof(surveyQuestion))]
        //public IHttpActionResult DeletesurveyQuestion(long id)
        //{
        //    surveyQuestion surveyQuestion = db.surveyQuestions.Find(id);
        //    if (surveyQuestion == null)
        //    {
        //        return NotFound();
        //    }

        //    db.surveyQuestions.Remove(surveyQuestion);
        //    db.SaveChanges();

        //    return Ok(surveyQuestion);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool surveyQuestionExists(long id)
        //{
        //    return db.surveyQuestions.Count(e => e.surveyQuesID == id) > 0;
        //}
    }
}