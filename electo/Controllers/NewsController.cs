using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using electo.Models;
using electo.Models.IRepositories;
using electo.Models.Repositories;
using System.IO;
using electo.Models.BaseClass;

namespace electo.Controllers
{
    public class NewsController : BaseClass
    {
        private electoEntities db = new electoEntities();
        private readonly IElectionService _ElectionService;
        private readonly INewsServices _NewsServices;

        public NewsController()
        {
            _ElectionService = new ElectionService();
            _NewsServices = new NewsServices();
        }
  

        // GET: News/Create
        public ActionResult Create()
        {
            ViewBag.electionTypeID = _ElectionService.getElectionTypes();
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "electionTypeID,title,description,imageURL")] news news, HttpPostedFileBase files)
        {
            String fileName = "";

            if (files != null)
            {
                fileName = Guid.NewGuid() + "_" + Path.GetFileName(files.FileName);
                var path = Path.Combine(Server.MapPath("~/newsImages/"), fileName);
                files.SaveAs(path);
                news.imageURL = "http://electo.qendidate.com/newsImages/" + fileName;
                news.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
                news.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));

                try
                {
                    _NewsServices.createNews(news);
                    TempData["Result"] = "Success";                    
                }
                catch(Exception e)
                {
                    TempData["Result"] = "Error";
                }
            }
            return RedirectToAction("Create", "News");
        }      
    }
}
