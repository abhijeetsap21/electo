using electo.Models;
using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace electo.Models.Repositories
{
    public class SurveyResponseService : ISurveyResponseService
    {
        private readonly UnitOfWork uow;
        public SurveyResponseService()
        {
            uow = new UnitOfWork();
        }

        #region HR Service Function
        //20180313
        //IEnumerable<sp_SurveyAnalysis_BySurveyId_Result> GetBySurveyId(long Id);
        public IEnumerable<sp_SurveyAnalysis_BySurveyId_Result> GetBySurveyId(long Id)
        {
            var SurveyId = new SqlParameter("@SurveyId", Id);
            var objAreaList = uow.sp_SurveyAnalysis_BySurveyId_Result_.SQLQuery<sp_SurveyAnalysis_BySurveyId_Result>("sp_SurveyAnalysis_BySurveyId @SurveyId", SurveyId);
            if (objAreaList != null)
            {
                return objAreaList;
            }
            return null;
        }
        #endregion
        public int submitResponse(IEnumerable<surveyRespons> _surveyResponse)
        {
            int result = 0;
            //var surveyQuestionID = new SqlParameter("@surveyQuesID", _surveyResponse.surveyQuesID);
            //var surveyQuestionResponseID = new SqlParameter("@SurveyQuestionOptionId", _surveyResponse.SurveyQuestionOptionId);
            //var dataIsCreated_ = new SqlParameter("@dataIsCreated", _surveyResponse.dataIsCreated);
            //var createdBy_ = new SqlParameter("@createdBy", _surveyResponse.createdBy);
            try
            {
                foreach (var s in _surveyResponse)
                {
                    s.dataIsCreated = BaseUtil.GetCurrentDateTime();
                }
                uow.submitResponse_.AddRange(_surveyResponse);
                result = 1;
               // result = uow.submitResponse_.SQLQuery<int>("submitSurveyResponse @surveyQuesID,@SurveyQuestionOptionId,@dataIsCreated,@createdBy", surveyQuestionID, surveyQuestionResponseID, dataIsCreated_, createdBy_).FirstOrDefault();

            }
            catch (Exception e){}
            return result;

        }
    }
}