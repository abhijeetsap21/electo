using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface IElectionService
    {
        IEnumerable<electionType> getElectionTypes();
        IEnumerable<sp_electionList_Result> getElectionNameList(int ElectionType, int ddl_year, int month);
        IEnumerable<monthName> getAllMonthName();
        IEnumerable<tblyear> getAllYears();
        int create(electionName oelectionName);
        IEnumerable<electionName> getAllElections();
    }
}
