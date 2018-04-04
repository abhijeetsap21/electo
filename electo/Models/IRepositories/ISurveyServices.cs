using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static electo.Models.SP_Models.StoredProcedureModels;

namespace electo.Models.IRepositories
{
    interface ISurveyServices
    {
        #region HR IService Function
        IEnumerable<sp_Survey_GetAll_Result> GetAll();
        IEnumerable<sp_Survey_GetByCampaignId_Result> GetByCampaignId(long Id);
        #endregion

        int create(survey osurvey);
    }
}
