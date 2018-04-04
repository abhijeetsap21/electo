using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace electo.Models.Repositories
{
    public class AreaService : IAreaService
    {
        private readonly UnitOfWork uow;
        public AreaService()
        {
            uow = new UnitOfWork();
        }

        public IEnumerable<sp_areaList_Result> getAll_areaList(int ElectionTypeId, int stateId, int ddl_Constituency)
        {
            var ElectionTypeId_ = new SqlParameter("@electionTypeID", ElectionTypeId);
            var stateId_ = new SqlParameter("@stateID", stateId);
            var ddl_Constituency_ = new SqlParameter("@constituencyID", ddl_Constituency);
            var _sp_areaList_Result = uow.sp_areaList_Result_.SQLQuery< sp_areaList_Result>("sp_areaList @stateID, @electionTypeID, @constituencyID", stateId_, ElectionTypeId_, ddl_Constituency_).ToList();
            return _sp_areaList_Result;
        }

        public int createArea(areaName areaName_)
        {
            int result;
            try
            {
                uow.createArea_.Add(areaName_);
                result = 1;
            }

            catch (Exception e)
            {
                result = 0;
            }
            return result;
        }

        #region HR Service Function
        //20180222
        public IEnumerable<sp_Area_GetAll_Result> GetAll()
        {
            var objAreaList = uow.sp_Area_GetAll_Result_.SQLQuery<sp_Area_GetAll_Result>("sp_Area_GetAll");
            if (objAreaList != null)
            {
                return objAreaList;
            }
            return null;
        }
        //IEnumerable<sp_Area_GetByPageInchargeId_Result> GetByPageInchargeId();
        public IEnumerable<sp_Area_GetByPageInchargeId_Result> GetByPageInchargeId(long Id)
        {
            var PageInchargeId = new SqlParameter("@PageInchargeId", Id);
            var objAreaList = uow.sp_Area_GetByPageInchargeId_Result_.SQLQuery<sp_Area_GetByPageInchargeId_Result>("sp_Area_GetByPageInchargeId @PageInchargeId", PageInchargeId);
            if (objAreaList != null)
            {
                return objAreaList;
            }
            return null;
        }
        #endregion
        //public IEnumerable<sp_Area_GetByVolunteerId_Result> GetByVolunteerId(long Id)
        //{
        //    var VolunteerId = new SqlParameter("@VolunteerId", Id);
        //    var objAreaList = uow.sp_Area_GetByVolunteerId_Result_.SQLQuery<sp_Area_GetByVolunteerId_Result>("sp_Area_GetByVolunteerId @VolunteerId", VolunteerId).ToList();
        //    if (objAreaList != null)
        //    {
        //        return objAreaList;
        //    }
        //    return null;
        //}
    }
}