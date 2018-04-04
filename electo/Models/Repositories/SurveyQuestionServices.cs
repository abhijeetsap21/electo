using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace electo.Models.Repositories
{
    public class SurveyQuestionServices : ISurveyQuestionServices
    {
        private readonly UnitOfWork uow;
        public SurveyQuestionServices()
        {
            uow = new UnitOfWork();
        }
        #region HR Service Function
        public IEnumerable<sp_SurveyQuestion_GetBySurveyId_Result> GetBySurveyId(long Id)
        {
            var SurveyId = new SqlParameter("@SurveyId", Id);
            var SurveyQuestionId = uow.sp_SurveyQuestion_GetBySurveyId_Result_.SQLQuery<sp_SurveyQuestion_GetBySurveyId_Result>("sp_SurveyQuestion_GetBySurveyId @SurveyId", SurveyId).ToList();
            if (SurveyQuestionId != null)
            {
                return SurveyQuestionId;
            }
            return null;
        }
        #endregion



        public int CreateSurveyQuestion(surveyQuestionViewModel osurveyQuestionViewModel)
        {
            var surveyID = new SqlParameter("@surveyID", osurveyQuestionViewModel.surveyID);
            var questionSerial = new SqlParameter("@questionSerial", osurveyQuestionViewModel.questionSerial);
            var question = new SqlParameter("@question", osurveyQuestionViewModel.question);
            var dataIsCreated = new SqlParameter("@dataIsCreated", BaseUtil.GetCurrentDateTime());
            var createdBy = new SqlParameter("@createdBy", Convert.ToInt64(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString())));
            var questionTypeID = new SqlParameter("@questionTypeID", osurveyQuestionViewModel.questionTypeID);
            var op1 = new SqlParameter("@op1", osurveyQuestionViewModel.questionOP1);
            var op2 = new SqlParameter("@op2", osurveyQuestionViewModel.questionOP2);
            var op3 = new SqlParameter("@op3", SqlString.Null);
            var op4 = new SqlParameter("@op4", SqlString.Null);
            int result = 0;

            try
            {
                string q = string.Empty;
                if (osurveyQuestionViewModel.questionTypeID == 1)
                {
                    result = uow.sp_createParty_Result_.SQLQuery<int>("sp_createSurveyQuestion @surveyID, @questionSerial,@question, @dataIsCreated,@createdBy,@questionTypeID,@op1,@op2", surveyID, questionSerial, question, dataIsCreated, createdBy, questionTypeID, op1, op2).FirstOrDefault();
                }
                if (osurveyQuestionViewModel.questionTypeID == 2)
                {
                    op3 = new SqlParameter("@op3", osurveyQuestionViewModel.questionOP3);
                    op4 = new SqlParameter("@op4", osurveyQuestionViewModel.questionOP4);
                    result = uow.sp_createParty_Result_.SQLQuery<int>("sp_createSurveyQuestion @surveyID, @questionSerial,@question, @dataIsCreated,@createdBy,@questionTypeID,@op1,@op2,@op3,@op4", surveyID, questionSerial, question, dataIsCreated, createdBy, questionTypeID, op1, op2,op3,op4).FirstOrDefault();
                }
            }
            catch { }
            return result;
        }
    }
}