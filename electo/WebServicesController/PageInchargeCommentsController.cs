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
    public class PageInchargeCommentsController : ApiController
    {
        //private electoEntities db = new electoEntities();
        private readonly IPageInchargeComment _pageInchargeComment;
        
        public PageInchargeCommentsController()
        {
            _pageInchargeComment = new PageInchargeComment();
        }

        //20180312
        //IEnumerable<sp_PageInchargeComments_ByCampaignId_Result> GetByCampaignId(long Id);
        public IHttpActionResult GetByCampaign(long BoothInchargeId, long CampaignId)
        {
            var objPageInchargeCommentList = _pageInchargeComment.GetByCampaignId(BoothInchargeId, CampaignId);

            if (objPageInchargeCommentList != null)
            {
                var pageInchargeCommentEntities = objPageInchargeCommentList as List<sp_PageInchargeComments_ByCampaignId_Result> ?? objPageInchargeCommentList.ToList();

                if (pageInchargeCommentEntities.Any())
                {
                   // return Request.CreateResponse(HttpStatusCode.OK, pageInchargeCommentEntities);
                    return Json(new { status = "Success", msg = "Record found", data = pageInchargeCommentEntities });
                }
            }
            //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Page Incharge Comment data not found");
            return Json(new { status = "Error", msg = "Record not found" });
        }


        //// GET: api/PageInchargeComments
        //public IQueryable<pageInchargeComment> GetpageInchargeComments()
        //{
        //    return db.pageInchargeComments;
        //}

        //// GET: api/PageInchargeComments/5
        //[ResponseType(typeof(pageInchargeComment))]
        //public IHttpActionResult GetpageInchargeComment(long id)
        //{
        //    pageInchargeComment pageInchargeComment = db.pageInchargeComments.Find(id);
        //    if (pageInchargeComment == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(pageInchargeComment);
        //}

        //// PUT: api/PageInchargeComments/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutpageInchargeComment(long id, pageInchargeComment pageInchargeComment)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != pageInchargeComment.commentID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(pageInchargeComment).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!pageInchargeCommentExists(id))
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

        //// POST: api/PageInchargeComments
        //[ResponseType(typeof(pageInchargeComment))]
        //public IHttpActionResult PostpageInchargeComment(pageInchargeComment pageInchargeComment)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.pageInchargeComments.Add(pageInchargeComment);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (pageInchargeCommentExists(pageInchargeComment.commentID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = pageInchargeComment.commentID }, pageInchargeComment);
        //}

        //// DELETE: api/PageInchargeComments/5
        //[ResponseType(typeof(pageInchargeComment))]
        //public IHttpActionResult DeletepageInchargeComment(long id)
        //{
        //    pageInchargeComment pageInchargeComment = db.pageInchargeComments.Find(id);
        //    if (pageInchargeComment == null)
        //    {
        //        return NotFound();
        //    }

        //    db.pageInchargeComments.Remove(pageInchargeComment);
        //    db.SaveChanges();

        //    return Ok(pageInchargeComment);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool pageInchargeCommentExists(long id)
        //{
        //    return db.pageInchargeComments.Count(e => e.commentID == id) > 0;
        //}
    }
}