using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface IbiographyServices
    {
        int createbiography(Biography_s Biography_s_);
        Biography_s Find(int id);
        int updatebiography(Biography_s Biography_s_);
        IEnumerable<sp_getAllBiographiesStartwithLetter_Result> getListStartWith(string Variable_);
    }
}
