using electo.Models.IRepositories;
using electo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static electo.Models.SP_Models.StoredProcedureModels;

namespace electo.WebServicesController
{
    public class EventController : ApiController
    {
        private readonly IEventServices _EventServices;
        public EventController()
        {
            _EventServices = new EventServices();
        }

        public IHttpActionResult createEvent(sp_createEvent osp_createEvent)
        {
            int result=0;
            result = _EventServices.createEvent(osp_createEvent);

            if (result == 1)
               {
                    //return Request.CreateResponse(HttpStatusCode.OK, "success");
                return Json(new { status = "Success", msg = "Success"});
            }
            //return Request.CreateErrorResponse(HttpStatusCode.OK, "failure");
            return Json(new { status = "Error", msg = "Failure" });
        }
    }
}
