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
using electo.Models.SP_Models;

namespace electo.WebServicesController
{
    public class SurveyResponsesController : ApiController
    {
        //private electoEntities db = new electoEntities();

        private readonly ISurveyResponseService _surveyResponseService;

        public SurveyResponsesController()
        {
            _surveyResponseService = new SurveyResponseService();
        }

        //20180313
        // public IEnumerable<sp_SurveyAnalysis_BySurveyId_Result> GetBySurveyId(long Id)
        public IHttpActionResult GetBySurvey(long Id)
        {
            var objSurveyReponseList = _surveyResponseService.GetBySurveyId(Id);

            if (objSurveyReponseList != null)
            {
                var surveyResponseEntities = objSurveyReponseList as List<sp_SurveyAnalysis_BySurveyId_Result> ?? objSurveyReponseList.ToList();

                if (surveyResponseEntities.Any())
                {
                    /*new code start*/
                    List<SurveyResponse> objSurveyResponseList = new List<Models.SP_Models.SurveyResponse>();
                    List<QuestionOption> objQuestionOptionList = new List<Models.SP_Models.QuestionOption>();

                    for (int i = 0; i < surveyResponseEntities.Count; i++)
                    {
                        SurveyResponse objSurveyResponse = new Models.SP_Models.SurveyResponse();
                        QuestionOption objQuestionOption = new Models.SP_Models.QuestionOption();
                        if (i == 0)
                        {
                            objSurveyResponse.SurveyId = surveyResponseEntities[i].surveyID;
                            objSurveyResponse.SurveyQuestionId = surveyResponseEntities[i].surveyQuesID;
                            objSurveyResponse.QuestionText = surveyResponseEntities[i].question;

                            objQuestionOption.SurveyQuestionOptionId = surveyResponseEntities[i].SurveyQuestionOptionId;
                            objQuestionOption.OptionText = surveyResponseEntities[i].OptionText;
                            objQuestionOption.Total = surveyResponseEntities[i].Total;
                            objQuestionOption.TotalResponse = surveyResponseEntities[i].TotalResponse;

                            objSurveyResponse.QuestionOptions = new List<QuestionOption>();
                            objSurveyResponse.QuestionOptions.Add(objQuestionOption);
                            objSurveyResponseList.Add(objSurveyResponse);
                        }

                        if (i > 0)
                        {
                            objQuestionOption.SurveyQuestionOptionId = surveyResponseEntities[i].SurveyQuestionOptionId;
                            objQuestionOption.OptionText = surveyResponseEntities[i].OptionText;
                            objQuestionOption.Total = surveyResponseEntities[i].Total;
                            objQuestionOption.TotalResponse = surveyResponseEntities[i].TotalResponse;

                            if (surveyResponseEntities[i].question == surveyResponseEntities[i - 1].question)
                            {
                                //objSurveyResponse.QuestionOptions.Add(objQuestionOption);
                                objSurveyResponseList.Last().QuestionOptions.Add(objQuestionOption);
                            }
                            else
                            {
                                objSurveyResponse.SurveyId = surveyResponseEntities[i].surveyID;
                                objSurveyResponse.SurveyQuestionId = surveyResponseEntities[i].surveyQuesID;
                                objSurveyResponse.QuestionText = surveyResponseEntities[i].question;
                                objSurveyResponse.QuestionOptions = new List<QuestionOption>();
                                objSurveyResponse.QuestionOptions.Add(objQuestionOption);
                                objSurveyResponseList.Add(objSurveyResponse);
                            }
                        }
                    }


                    /*new code end*/

                    // return Request.CreateResponse(HttpStatusCode.OK, surveyResponseEntities);
                    return Json(new { status = "Success", msg = "Record found", data = objSurveyResponseList });
                }
            }
           // return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Survey response data not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }
        //20180327
        //public IHttpActionResult SurveyResponseGetBySurvey(long Id)
        //{
        //    var objSurveyReponseList = _surveyResponseService.GetBySurveyId(Id);

        //    if (objSurveyReponseList != null)
        //    {
        //        var surveyResponseEntities = objSurveyReponseList as List<sp_SurveyAnalysis_BySurveyId_Result> ?? objSurveyReponseList.ToList();

        //        if (surveyResponseEntities.Any())
        //        {
        //            List<SurveyResponse> objSurveyResponseList = new List<Models.SP_Models.SurveyResponse>();
        //            List<QuestionOption> objQuestionOptionList = new List<Models.SP_Models.QuestionOption>();
                    
        //            for (int  i= 0;  i< surveyResponseEntities.Count; i++)
        //            {
        //                SurveyResponse objSurveyResponse = new Models.SP_Models.SurveyResponse();
        //                QuestionOption objQuestionOption = new Models.SP_Models.QuestionOption();
        //                if (i==0)
        //                {
        //                    objSurveyResponse.SurveyId = surveyResponseEntities[i].surveyID;
        //                    objSurveyResponse.SurveyQuestionId = surveyResponseEntities[i].surveyQuesID;
        //                    objSurveyResponse.QuestionText = surveyResponseEntities[i].question;

        //                    objQuestionOption.SurveyQuestionOptionId = surveyResponseEntities[i].SurveyQuestionOptionId;
        //                    objQuestionOption.OptionText = surveyResponseEntities[i].OptionText;
        //                    objQuestionOption.Total = surveyResponseEntities[i].Total;
        //                    objQuestionOption.TotalResponse = surveyResponseEntities[i].TotalResponse;

        //                    objSurveyResponse.QuestionOptions.Add(objQuestionOption);
        //                    objSurveyResponseList.Add(objSurveyResponse);
        //                }

        //                if (i>0)
        //                {
        //                    objQuestionOption.SurveyQuestionOptionId = surveyResponseEntities[i].SurveyQuestionOptionId;
        //                    objQuestionOption.OptionText = surveyResponseEntities[i].OptionText;
        //                    objQuestionOption.Total = surveyResponseEntities[i].Total;
        //                    objQuestionOption.TotalResponse = surveyResponseEntities[i].TotalResponse;

        //                    if (surveyResponseEntities[i].question == surveyResponseEntities[i - 1].question)
        //                    {
        //                        objSurveyResponse.QuestionOptions.Add(objQuestionOption);
        //                        objSurveyResponseList.Last().QuestionOptions.Add(objQuestionOption);
        //                    }
        //                    else
        //                    {
        //                        objSurveyResponse.SurveyId = surveyResponseEntities[i].surveyID;
        //                        objSurveyResponse.SurveyQuestionId = surveyResponseEntities[i].surveyQuesID;
        //                        objSurveyResponse.QuestionText = surveyResponseEntities[i].question;
        //                        objSurveyResponse.QuestionOptions.Add(objQuestionOption);
        //                        objSurveyResponseList.Add(objSurveyResponse);
        //                    }
        //                }
        //            }
                    
        //            //return Json(new { status = "Success", msg = "Record found", data = objSurveyResponseList.ToList() });
        //            return Json(new { status = "Success", msg = "Record found", data = surveyResponseEntities });
        //        }
        //    }
        //    return Json(new { status = "Error", msg = "Record not found" });
        //}
        //Post Survey Response
        public IHttpActionResult submitResponse([FromBody] IEnumerable< surveyRespons> _surveyResponse )
        {
           
            var submitResponse = _surveyResponseService.submitResponse(_surveyResponse);

            if (submitResponse == 1)
            {
                return Json(new { status = "Success", msg = "Success" });               
            }
            // return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Survey response data not found");
            return Json(new { status = "Error", msg = "Not Submitted" });
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
            }
            base.Dispose(disposing);
        }

        
    }
}