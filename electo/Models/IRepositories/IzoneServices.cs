using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface IzoneServices
    {
        IEnumerable<sp_getZoneByStateIDAndMUncipalCorporationID_Result> getZoneByStateIDAndMUncipalCorporationID(int stateId, int MPCorporation);
        bool CreateVidhanSabha(zoneMunicipality ozoneMunicipality);
    }
}
