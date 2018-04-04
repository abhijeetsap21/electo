using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static electo.Models.SP_Models.StoredProcedureModels;

namespace electo.Models.IRepositories
{
    interface IvoterListService
    {
        int createNewVoter(voterList ovoterList_Copy);
        IEnumerable<sp_GetAllDataEntryOperators_Result> getAllDataEntryOperators();
        IEnumerable<sp_GetVoters_List_Result> getVoters(string voterID, string date, string userID);
        voterList getVoterByID(long voterID);
        int UpdateVoter(voterList ovoterList_Copy);
    }
}
