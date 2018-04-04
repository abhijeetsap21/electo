using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface ISurveyQuestionServices
    {
        #region HR IService Function
        IEnumerable<sp_SurveyQuestion_GetBySurveyId_Result> GetBySurveyId(long Id);
        #endregion

        int CreateSurveyQuestion(surveyQuestionViewModel osurveyQuestionViewModel);
    }
}
