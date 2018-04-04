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

namespace electo.WebServicesController
{
    public class EnquiriesController : ApiController
    {
        private electoEntities db = new electoEntities();

        // GET: api/Enquiries
        public IQueryable<enquiry> Getenquiries()
        {
            return db.enquiries;
        }

        // GET: api/Enquiries/5
        [ResponseType(typeof(enquiry))]
        public IHttpActionResult Getenquiry(long id)
        {
            enquiry enquiry = db.enquiries.Find(id);
            if (enquiry == null)
            {
                return NotFound();
            }

            return Ok(enquiry);
        }

        // PUT: api/Enquiries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putenquiry(long id, enquiry enquiry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != enquiry.enquiryID)
            {
                return BadRequest();
            }

            db.Entry(enquiry).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!enquiryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Enquiries
        [ResponseType(typeof(enquiry))]
        public IHttpActionResult Postenquiry(enquiry enquiry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.enquiries.Add(enquiry);
            try
            {
                db.SaveChanges();
            }

            catch (Exception e)
            {

            }

            return CreatedAtRoute("DefaultApi", new { id = enquiry.enquiryID }, enquiry);
        }

        // DELETE: api/Enquiries/5
        [ResponseType(typeof(enquiry))]
        public IHttpActionResult Deleteenquiry(long id)
        {
            enquiry enquiry = db.enquiries.Find(id);
            if (enquiry == null)
            {
                return NotFound();
            }

            db.enquiries.Remove(enquiry);
            db.SaveChanges();

            return Ok(enquiry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool enquiryExists(long id)
        {
            return db.enquiries.Count(e => e.enquiryID == id) > 0;
        }
    }
}