using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace electo.Models.Repositories
{
    public class DistrictServices: IDistrictServices
    {
        private readonly UnitOfWork uow;
        public DistrictServices()
        {
            uow = new UnitOfWork();
        }

        public IEnumerable<district> getDistrictByStateID(int stateID)
        {            
            var _districtList = uow.district_.Find(e => e.stateID == stateID).ToList();         
            return _districtList;
        }
        public int create(district odistrict)
        {
            int result = 0;
            odistrict.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            odistrict.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            odistrict.dataIsCreated = BaseUtil.GetCurrentDateTime();
            odistrict.dataIsUpdated = BaseUtil.GetCurrentDateTime();
            odistrict.isActive = true;
         
            try
            {
                uow.district_.Add(odistrict);
                result = 1;
            }
            catch { }
            return result;
        }
    }
}