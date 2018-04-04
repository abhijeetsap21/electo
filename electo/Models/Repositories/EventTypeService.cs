using electo.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace electo.Models.Repositories
{
    public class EventTypeService : IEventTypeService
    {
        private readonly UnitOfWork uow;
        public EventTypeService()
        {
            uow = new UnitOfWork();
        }
        public IEnumerable<eventType> GetEventTypeList() {
            var eventTypeList_ = uow.eventType_.Find(e => e.isActive).ToList();
            return eventTypeList_;
        }

        public IEnumerable<sp_GetAllEventTypes_Result> getEventTypes()
        {
            var result = uow.getEventTypes_.SQLQuery<sp_GetAllEventTypes_Result>("sp_GetAllEventTypes").ToList();
            return result;
        }
        public bool addNewEventType(eventType OeventType)
        {
            bool result = false;
            try
            {
                uow.eventType_.Add(OeventType);
                result = true;
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }
    }
}