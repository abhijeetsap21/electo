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
    public class AreasController : ApiController
    {
        //private electoEntities db = new electoEntities();
        private readonly IAreaService _areaService;

        public AreasController()
        {
            _areaService = new AreaService();
        }

        public IHttpActionResult GetAreas()
        {
            var objAreaList = _areaService.GetAll();

            if (objAreaList != null)
            {
                var areaEntity = objAreaList as List<sp_Area_GetAll_Result> ?? objAreaList.ToList();

                if (areaEntity != null)
                {
                    //return Request.CreateResponse(HttpStatusCode.OK, areaEntity);
                    return Json(new { status = "Success", msg = "Record found", data = areaEntity });
                }
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Area data not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }
        //public IEnumerable<sp_Area_GetByPageInchargeId_Result> GetByPageInchargeId(long Id)
        public IHttpActionResult GetByPageInchargeId(long Id)
        {
            var objAreaList = _areaService.GetByPageInchargeId(Id);

            if (objAreaList != null)
            {
                var areaEntities = objAreaList as List<sp_Area_GetByPageInchargeId_Result> ?? objAreaList.ToList();

                if (areaEntities.Any())
                {
                    //return Request.CreateResponse(HttpStatusCode.OK, areaEntities);
                    return Json(new { status = "Success", msg = "Record found", data = areaEntities });
                }
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Area data not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }

        //// GET: api/Areas
        //public IQueryable<areaName> GetareaNames()
        //{
        //    return db.areaNames;
        //}

        //// GET: api/Areas/5
        //[ResponseType(typeof(areaName))]
        //public IHttpActionResult GetareaName(long id)
        //{
        //    areaName areaName = db.areaNames.Find(id);
        //    if (areaName == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(areaName);
        //}

        //// PUT: api/Areas/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutareaName(long id, areaName areaName)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != areaName.areaID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(areaName).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!areaNameExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Areas
        //[ResponseType(typeof(areaName))]
        //public IHttpActionResult PostareaName(areaName areaName)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.areaNames.Add(areaName);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = areaName.areaID }, areaName);
        //}

        //// DELETE: api/Areas/5
        //[ResponseType(typeof(areaName))]
        //public IHttpActionResult DeleteareaName(long id)
        //{
        //    areaName areaName = db.areaNames.Find(id);
        //    if (areaName == null)
        //    {
        //        return NotFound();
        //    }

        //    db.areaNames.Remove(areaName);
        //    db.SaveChanges();

        //    return Ok(areaName);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool areaNameExists(long id)
        //{
        //    return db.areaNames.Count(e => e.areaID == id) > 0;
        //}
    }
}