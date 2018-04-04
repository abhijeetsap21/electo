using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface IDistrictServices
    {
        IEnumerable<district> getDistrictByStateID(int stateID);
        int create(district odistrict);
    }
}
