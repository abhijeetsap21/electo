using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace electo.Models.SP_Models
{
    public class SurveyResponse
    {
       public long SurveyId { get; set; }
       public long SurveyQuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<QuestionOption> QuestionOptions { get; set; }
    }

    public class QuestionOption
    {
        public long SurveyQuestionOptionId { get; set; }
        public string OptionText { get; set; }
        public int? Total { get; set; }
        public int? TotalResponse { get; set; }
    }

}