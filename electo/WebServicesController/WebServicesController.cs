using electo.Models;
using electo.Models.IRepositories;
using electo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace electo.WebServices
{
    public class WebServicesController<TEntity>: ApiController  where TEntity: class
    {
        public electoEntities Context= new electoEntities();
      protected  Models.Repositories.Repositories<TEntity> repo = new Models.Repositories.Repositories<TEntity>();

        public electoEntities electoEntities
        {
            get { return Context as electoEntities; }
        }

        //[ResponseType(typeof(TEntity))]
        public IEnumerable<TEntity> Get()
        {
            var c = repo.GetAll();

            return c;
        }

        // GET api/values/5

        // [ResponseType(typeof(loginVolunteer))]
        public IHttpActionResult Get(long id)
        {
            return Ok("o");
        }

        //// POST api/values
        //[ResponseType(typeof(App_status))]
        //public IHttpActionResult Post([FromBody]App_status ochild1)
        //{          

        //    return CreatedAtRoute("DefaultApi", new { id = ochild1.App_status_id }, ochild1);
        //}

        //// PUT api/values/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult Put(int id, App_status value)
        //{
        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// DELETE api/values/5
        //[ResponseType(typeof(App_status))]
        //public IHttpActionResult Delete(int id)
        //{
        //    App_status ochild1 = new App_status();
        //    return Ok(ochild1);
        //}

    }




}
