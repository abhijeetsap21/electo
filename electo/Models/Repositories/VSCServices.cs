using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace electo.Models.Repositories
{
    public class VSCServices : IVSCServices
    {
        private readonly UnitOfWork uow;
        public VSCServices()
        {
            uow = new UnitOfWork();
        }

        public IEnumerable<vidhanSabhaConstituency> getAllvidhanSabhaConstituency()
        {
            var _vidhanSabhaConstituencyList = uow.VidhanSabhaConsistuency_.GetAll().ToList();
            return _vidhanSabhaConstituencyList;
        }

        public IEnumerable<vidhanSabhaConstituency> getvidhanSabhaConstituencyByStateID(int stateID)
        {
            var _vidhanSabhaConstituencyList = uow.VidhanSabhaConsistuency_.Find(e=>e.stateID== stateID).ToList();
            return _vidhanSabhaConstituencyList;
        }

        public IEnumerable<sp_getVidhanSabhaLsit_Result> getvidhanSabhaConstituencyByStateIDANDLKSCID(int stateId, int LSCID, string VSC_NAME)
        {
            var LSCID_ = new SqlParameter("@lokSabhaId", LSCID);
            var stateId_ = new SqlParameter("@stateId", stateId);
            var VSC_NAME_ = new SqlParameter("@vidhanSabhaName", VSC_NAME);


            var _vidhanSabhaConstituencyList = uow.sp_getVidhanSabhaLsit_Result_.SQLQuery<sp_getVidhanSabhaLsit_Result>("sp_getVidhanSabhaLsit @stateId,@lokSabhaId, @vidhanSabhaName", stateId_, LSCID_, VSC_NAME_).ToList();
            return _vidhanSabhaConstituencyList;
        }

        public bool CreateVidhanSabha(vidhanSabhaConstituency ovidhanSabhaConstituency)
        {
            bool result= false;
            try
            {
                uow.VidhanSabhaConsistuency_.Add(ovidhanSabhaConstituency);
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