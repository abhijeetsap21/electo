using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface IstateService
    {
           IEnumerable<state> getAllStates();
           int  create(string stateName);
    }
}
