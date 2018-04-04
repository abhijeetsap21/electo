using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface ISurveyResponseService
    {
        //20180313
        #region HR IService Function
        //private Repositories<sp_SurveyAnalysis_BySurveyId_Result> _sp_SurveyAnalysis_BySurveyId { get; set; }
        IEnumerable<sp_SurveyAnalysis_BySurveyId_Result> GetBySurveyId(long Id);
        #endregion
        int submitResponse(IEnumerable<surveyRespons> _surveyResponse);
    }
}
