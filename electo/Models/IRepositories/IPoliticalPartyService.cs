using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface IPoliticalPartyService
    {
        IEnumerable<sp_politicalPartyList_Result> getAll_PoliticalPartyListByStateID(int stateId, string PoliticalPartyName);
        int  createParty(CreatePartyViewModel oCreatePartyViewModel);
        IEnumerable<sp_partyAddressList_Result> PoliticalPartyAddressList(int politicalPartyId);
        bool saveNewAddress(politicalPartyAddress opoliticalPartyAddress);
    }
}
