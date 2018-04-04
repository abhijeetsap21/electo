using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using electo.Models;
using electo.Models.IRepositories;
using electo.Models.Repositories;

namespace electo.WebServicesController
{
    public class EventTypesController : ApiController
    {
        //private electoEntities db = new electoEntities();
        private readonly IEventServices _eventServices;
        private readonly IEventTypeService _eventTypeService;

        public EventTypesController()
        {
            _eventServices = new EventServices();
            _eventTypeService = new EventTypeService();
        }
        // public IEnumerable<sp_Event_GetByCampaignId_Result> GetByCampaignId(long Id)
        public IHttpActionResult GetEventsByCampaignId(long Id)
        {
            var objEventList = _eventServices.GetByCampaignId(Id);

            if (objEventList != null)
            {
                var eventEntities = objEventList as List<sp_Event_GetByCampaignId_Result> ?? objEventList.ToList();

                if (eventEntities.Any())
                {
                   // return Request.CreateResponse(HttpStatusCode.OK, eventEntities);
                    return Json(new { status = "Success", msg = "Record found", data = eventEntities });
                }
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Event data not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }

        // Get all Event Types
        public IHttpActionResult Getallevents()
        {
            var objEventList = _eventTypeService.getEventTypes();

            if (objEventList != null)
            {
                var eventEntities = objEventList as List<sp_GetAllEventTypes_Result> ?? objEventList.ToList();

                if (eventEntities.Any())
                {
                    // return Request.CreateResponse(HttpStatusCode.OK, eventEntities);
                    return Json(new { status = "Success", msg = "Record found", data = eventEntities });
                }
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Event data not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }



        //public IEnumerable<sp_Event_GetByEventTypeId_Result> GetByEventTypeId(long Id)
        public IHttpActionResult GetEventsByEventTypeId(long Id)
        {
            var objEventList = _eventServices.GetByEventTypeId(Id);

            if (objEventList != null)
            {
                var eventEntities = objEventList as List<sp_Event_GetByEventTypeId_Result> ?? objEventList.ToList();

                if (eventEntities.Any())
                {
                    //return Request.CreateResponse(HttpStatusCode.OK, eventEntities);
                    return Json(new { status = "Success", msg = "Record found", data = eventEntities });
                }
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Event data not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool eventTypeExists(int id)
        //{
        //    return db.eventTypes.Count(e => e.eventTypeID == id) > 0;
        //}
    }
}