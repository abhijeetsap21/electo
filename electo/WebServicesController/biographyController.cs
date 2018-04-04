using electo.Models;
using electo.Models.IRepositories;
using electo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace electo.WebServicesController
{
    public class biographyController : ApiController
    {
        private readonly IbiographyServices biographyServices_;
        public biographyController()
        {
            biographyServices_ = new biographyServices();
        }

        public IHttpActionResult getBiographyListStartWithcharacter(string name)
        {
            var biographyList_ = biographyServices_.getListStartWith(name);

            if (biographyList_ != null)
            {
                var biographyList = biographyList_ as List<sp_getAllBiographiesStartwithLetter_Result> ?? biographyList_.ToList();

                if (biographyList != null)
                {
                    //return Request.CreateResponse(HttpStatusCode.OK, biographyList);
                    return Json(new { status = "Success", msg = "Record found", data = biographyList });
                }
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Record not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }
    }
}
