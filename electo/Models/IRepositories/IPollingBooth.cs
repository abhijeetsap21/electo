using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface IPollingBooth
    {
        IEnumerable<sp_pollingBoothList_Result> get_PollingBoothList(int stateId, int LSCID, int VSCID, int wardID);
        int createPollingBooth(pollingBooth pollingBooth_);
        IEnumerable<sp_getPoolingBoothByCampignID_Result> get_PollingBoothListByCampaignID(Int64 CampaignID);
        int AssignPollingBoothToAssignPollingBoothIncharge(AssignPollingBoothToPollingBoothIncharge oAssignPollingBoothToPollingBoothIncharge);
    }
}
