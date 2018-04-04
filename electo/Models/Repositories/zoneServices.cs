using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace electo.Models.Repositories
{
    public class zoneServices: IzoneServices
    {
        private readonly UnitOfWork uow;
        public zoneServices()
        {
            uow = new UnitOfWork();
        }
       
        public IEnumerable<sp_getZoneByStateIDAndMUncipalCorporationID_Result> getZoneByStateIDAndMUncipalCorporationID(int stateId, int MPCorporation)
        {
            var MPCorporation_ = new SqlParameter("@MPCorporation", MPCorporation);
            var stateId_ = new SqlParameter("@stateId", stateId);          


            var _MUncipalCorporationList = uow.zoneMunicipality_.SQLQuery<sp_getZoneByStateIDAndMUncipalCorporationID_Result>("sp_getZoneByStateIDAndMUncipalCorporationID @stateId,@MPCorporation", stateId_, MPCorporation_).ToList();
            return _MUncipalCorporationList;
        }


        public bool CreateVidhanSabha(zoneMunicipality ozoneMunicipality)
        {
            bool result = false;
            try
            {
                uow.zoneMunicipality_.Add(ozoneMunicipality);
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