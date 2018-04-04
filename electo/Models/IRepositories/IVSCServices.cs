using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface IVSCServices
    {
        IEnumerable<vidhanSabhaConstituency> getAllvidhanSabhaConstituency();
        IEnumerable<vidhanSabhaConstituency> getvidhanSabhaConstituencyByStateID(int stateID);
        IEnumerable<sp_getVidhanSabhaLsit_Result> getvidhanSabhaConstituencyByStateIDANDLKSCID(int stateId, int LSCID, string VSC_NAME);
        bool CreateVidhanSabha(vidhanSabhaConstituency ovidhanSabhaConstituency);
    }
}
