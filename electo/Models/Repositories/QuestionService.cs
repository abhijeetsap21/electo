using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace electo.Models.Repositories
{
    public class QuestionService: IQuestionService
    {
        private readonly UnitOfWork uow;
        public QuestionService()
        {
            uow = new UnitOfWork();
        }
        public IEnumerable<questionType> GetQuestionTypeList() {
            var QuestionTypeList_ = uow.questionType_.Find(e => e.isActve).ToList();
            return QuestionTypeList_;
        }

        public bool addNewQuestionType(questionType OquestionType)
        {
            bool result = false;
            try
            {
                uow.questionType_.Add(OquestionType);
                result = true;
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }
    }
}