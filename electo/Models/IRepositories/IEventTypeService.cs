using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electo.Models.IRepositories
{
    interface IEventTypeService
    {
        IEnumerable<eventType> GetEventTypeList();
        bool addNewEventType(eventType OeventType);
        IEnumerable<sp_GetAllEventTypes_Result> getEventTypes();
    }
}
