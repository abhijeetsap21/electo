using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace electo.Models.Repositories
{
    public class muncipalCorporationServices: ImuncipalCorporationServices
    { 
     private readonly UnitOfWork uow;
     public muncipalCorporationServices()
    {
        uow = new UnitOfWork();
    }

    public IEnumerable<municipalCorporationName> getmuncipalCorporationByStateID(int stateID)
    {
        var _municipalCorporationName = uow.municipalCorporationName_.Find(e => e.stateID == stateID).ToList();
        return _municipalCorporationName;
    }


    public int create(municipalCorporationName omunicipalCorporationName)
    {
        int result = 0;
            omunicipalCorporationName.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            omunicipalCorporationName.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            omunicipalCorporationName.dataIsCreated = BaseUtil.GetCurrentDateTime();
            omunicipalCorporationName.datatIsUpdated = BaseUtil.GetCurrentDateTime();
            omunicipalCorporationName.isActive = true;

        try
        {
            uow.municipalCorporationName_.Add(omunicipalCorporationName);
            result = 1;
        }
        catch { }
        return result;
    }
}
}