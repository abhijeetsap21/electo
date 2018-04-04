using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface IAreaService
    {
        IEnumerable<sp_areaList_Result> getAll_areaList(int ElectionTypeId, int stateId, int ddl_Constituency);
       int createArea(areaName areaName_);

        #region HR IService Function
        //20180222
        IEnumerable<sp_Area_GetAll_Result> GetAll();
        IEnumerable<sp_Area_GetByPageInchargeId_Result> GetByPageInchargeId(long Id);
        //IEnumerable<sp_Area_GetByVolunteerId_Result> GetByVolunteerId(long VolunteerId);
        #endregion
    }
}
