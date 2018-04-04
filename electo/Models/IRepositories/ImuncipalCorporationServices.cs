using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface ImuncipalCorporationServices
    {
        IEnumerable<municipalCorporationName> getmuncipalCorporationByStateID(int stateID);
        int create(municipalCorporationName omunicipalCorporationName);
    }
}
