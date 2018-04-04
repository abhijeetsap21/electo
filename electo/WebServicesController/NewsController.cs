using electo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using electo.Models;
using electo.Models.IRepositories;
using Newtonsoft.Json;
namespace electo.WebServicesController
{
    public class NewsController : ApiController
    {
        private readonly INewsServices _NewsServices;

        public NewsController()
        {
            _NewsServices = new NewsServices();
        }

        [HttpGet]
        public IHttpActionResult getAllNews()
        {
            var result = (_NewsServices.getNews());
            if (result != null)
            {
                var newsList = result as List<sp_GetLatestNews_Result> ?? result.ToList();

                if (newsList != null)
                {
                   // return Request.CreateResponse(HttpStatusCode.OK, newsList);
                    return Json(new { status = "Success", msg = "Record found", data = newsList });
                }
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Records");
            return Json(new { status = "Error", msg = "Record not found" });
        }
    }
}
