using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace electo.Models.Repositories
{
    public class wardServices: IwardServices
    {
        private readonly UnitOfWork uow;
        public wardServices()
        {
            uow = new UnitOfWork();
        }

        public IEnumerable<sp_getWardByStateIDAndMUncipalCorporationID_Result> getZoneByStateIDAndMUncipalCorporationID(int stateId, int MPCorporation, int districtID, int vidhanSabhaConstituencyID)
        {
            var MPCorporation_ = new SqlParameter("@MPCorporation", MPCorporation);
            var stateId_ = new SqlParameter("@stateId", stateId); 
            var districtID_ = new SqlParameter("@distictID", districtID);
            var vidhanSabhaConstituencyID_ = new SqlParameter("@vidhanSabhaConstituencyID", vidhanSabhaConstituencyID); 

            var _wardList = uow.wardConstituency_.SQLQuery<sp_getWardByStateIDAndMUncipalCorporationID_Result>("sp_getWardByStateIDAndMUncipalCorporationID @stateId,@MPCorporation,@distictID, @vidhanSabhaConstituencyID", stateId_, MPCorporation_, districtID_, vidhanSabhaConstituencyID_).ToList();
            return _wardList;
        }

        public bool CreateWardConstituency(wardConstituency owardConstituency)
        {
            bool result = false;
            try
            {
                uow.wardConstituency_.Add(owardConstituency);
                result = true; ;
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }
    }
}