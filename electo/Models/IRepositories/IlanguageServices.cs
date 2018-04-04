using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface IlanguageServices
    {
        IEnumerable<language> getAll_LangaugeList();
        int create(language Olanguage);
    }
}
