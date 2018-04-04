using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace electo.Models.Repositories
{
    public class stateService: IstateService
    {
        private readonly UnitOfWork uow;
        public stateService()
        {
            uow = new UnitOfWork();
        }

        public IEnumerable<state> getAllStates()
        {
            var _statesList = uow.state_.GetAll().ToList();
            return _statesList;
        }
        public int create(string stateName)
        {
            int result = 0;
            state ostate = new state();
            ostate.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            ostate.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            ostate.dataIsCreated = BaseUtil.GetCurrentDateTime();
            ostate.dataIsUpdated = BaseUtil.GetCurrentDateTime();
            ostate.isActive = true;
            ostate.stateName = stateName;
            try
            {
                uow.state_.Add(ostate);
                result =1;
            }
            catch { }
            return result;
        }
       
    }
}