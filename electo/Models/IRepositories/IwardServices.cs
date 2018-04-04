using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface IwardServices
    {
        IEnumerable<sp_getWardByStateIDAndMUncipalCorporationID_Result> getZoneByStateIDAndMUncipalCorporationID(int stateId, int MPCorporation, int districtID, int vidhanSabhaConstituencyID);
        bool CreateWardConstituency(wardConstituency owardConstituency);
    }
}
