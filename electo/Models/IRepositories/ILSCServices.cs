using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface ILSCServices
    {
        IEnumerable<lokSabhaConstituency> getAllvidhanSabhaConstituency();
        IEnumerable<lokSabhaConstituency> getAlllokSabhaConstituencyConstituency(int stateID);
        int create(lokSabhaConstituency olkSabha);
    }
}
