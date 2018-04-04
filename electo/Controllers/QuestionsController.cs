using electo.Models;
using electo.Models.BaseClass;
using electo.Models.IRepositories;
using electo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace electo.Controllers
{
    public class QuestionsController : BaseClass
    {
        private readonly ISurveyQuestionServices _QuestionService;
        private readonly IQuestionService _QuestionTypeService;
       public QuestionsController()
        {
            _QuestionTypeService = new QuestionService();
            _QuestionService = new SurveyQuestionServices();
        }

        // GET: Questions
        public ActionResult Index(int surveyID)
        {
            ViewBag.surveyID = surveyID;
            var QuestionList = _QuestionService.GetBySurveyId(surveyID);
            return View(QuestionList);
        }
        [HttpGet]
        public ActionResult Create(int surveyID)
        {
            ViewBag.surveyID = surveyID;
            ViewBag.questionTypeID = _QuestionTypeService.GetQuestionTypeList().Select(e => new { e.questionTypeID, e.questionType1 }); 
            return View();
        }


        [HttpPost]
        public ActionResult Create(surveyQuestionViewModel osurveyQuestion)
        {
        
                int result=0;
                
                    result = _QuestionService.CreateSurveyQuestion(osurveyQuestion);
                if (result == 1)
                {
                    TempData["Creation"] = "Success";
                    return RedirectToAction("Index", new { surveyID = osurveyQuestion.surveyID});
                }
                else {
                ViewBag.surveyID = osurveyQuestion.surveyID;
                ViewBag.questionTypeID = _QuestionTypeService.GetQuestionTypeList().Select(e => new { e.questionTypeID, e.questionType1 });
                TempData["Creation"] = "unsuccess";
                    return View(osurveyQuestion);
                }
           
        }


    }
}