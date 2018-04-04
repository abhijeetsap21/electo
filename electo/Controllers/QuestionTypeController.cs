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
    [CustomErrorHandling]
    public class QuestionTypeController : BaseClass
    {

        private readonly IQuestionService _QuestionService;
        public QuestionTypeController()
        {
            _QuestionService = new QuestionService();
        }
        // GET: QuestionType
        public ActionResult Index()
        {
            var questionTypeList_ = _QuestionService.GetQuestionTypeList();
            return View(questionTypeList_);
        }
        [HttpGet]
        public ActionResult create()
        {
            questionType oquestionType = new questionType();
            return View(oquestionType);
        }
        [HttpPost]
        public ActionResult create(questionType oquestionType)
        {
            bool result = false;

            oquestionType.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            oquestionType.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            oquestionType.isActve = true;
            oquestionType.dataIsCreated = BaseUtil.GetCurrentDateTime();
            oquestionType.dataIsUpdated = BaseUtil.GetCurrentDateTime();
            result = _QuestionService.addNewQuestionType(oquestionType);

            if (result)
            {
                TempData["Result"] = "Success";
                return RedirectToAction("Index");
            }
            TempData["Result"] = "unsuccess";


            return View(oquestionType);
        }
    }
}