using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace electo.Models.Repositories
{
    public class ElectionService: IElectionService
    {
        private readonly UnitOfWork uow;
        public ElectionService()
        {
            uow = new UnitOfWork();
        }


     
        public IEnumerable<electionType>getElectionTypes()
        {
            var _objelectionType = uow.electionType.GetAll().ToList();               
            return _objelectionType;
        }
        public IEnumerable<sp_electionList_Result> getElectionNameList(int ElectionType, int ddl_year, int ddl_month)
        {
            var ElectionType_ = new SqlParameter("@ElectionType", ElectionType);
            var ddl_year_ = new SqlParameter("@ddl_year", ddl_year);
            var ddl_month_ = new SqlParameter("@ddl_month", ddl_month);
            var _sp_electionList_Result = uow.sp_electionList_Result.SQLQuery<sp_electionList_Result>("sp_electionList @ElectionType,@ddl_year,@ddl_month", ElectionType_, ddl_year_, ddl_month_).ToList();
            return _sp_electionList_Result;
        }

        public IEnumerable<monthName> getAllMonthName()
        {
            var monthNameList_ = uow.monthName_.GetAll().ToList();
            return monthNameList_;
        }
        public IEnumerable<tblyear> getAllYears()
        {
            var yearList_ = uow.tblyear_.GetAll().ToList();
            return yearList_;
        }

        public int create(electionName oelectionName)
        {
            int result = 0;
            oelectionName.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            oelectionName.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            oelectionName.dataIsCreated = BaseUtil.GetCurrentDateTime();
            oelectionName.dataIsUpdated = BaseUtil.GetCurrentDateTime();
            oelectionName.isActive = true;

            try
            {
                uow.electionName_.Add(oelectionName);
                result = 1;
            }
            catch { }
            return result;
        }

        public IEnumerable<electionName> getAllElections()
        {
            var result = uow.getAllElections_.GetAll().ToList();
            return result;
        }
    }
    //election
    
}