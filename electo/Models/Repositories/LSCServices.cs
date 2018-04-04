using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace electo.Models.Repositories
{
    public class LSCServices : ILSCServices
    {
        private readonly UnitOfWork uow;
        public LSCServices()
        {
            uow = new UnitOfWork();
        }

        public IEnumerable<lokSabhaConstituency> getAllvidhanSabhaConstituency()
        {
            var _lokSabhaConstituencyList = uow._lokSabhaConstituency_.GetAll().ToList();
            return _lokSabhaConstituencyList;
        }
        public IEnumerable<lokSabhaConstituency> getAlllokSabhaConstituencyConstituency(int stateID)
        {
            var _lokSabhaConstituencyList = uow._lokSabhaConstituency_.Find(e=>e.stateID== stateID).ToList();
            return _lokSabhaConstituencyList;
        }

        public int create(lokSabhaConstituency olkSabha)
        {
            int result = 0;
            olkSabha.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            olkSabha.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            olkSabha.dataIsCreated = BaseUtil.GetCurrentDateTime();
            olkSabha.dataIsUpdated = BaseUtil.GetCurrentDateTime();
            olkSabha.isActive = true;

            try
            {
                uow._lokSabhaConstituency_.Add(olkSabha);
                result = 1;
            }
            catch { }
            return result;
        }
    }
}