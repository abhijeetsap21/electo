using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using electo.Models;
using electo.Models.BaseClass;
using electo.Models.IRepositories;
using electo.Models.Repositories;
using System.IO;

namespace electo.Controllers
{
    [CustomErrorHandling]
    public class Biography_sController : BaseClass
    {
        private readonly IbiographyServices biographyServices_;
        public Biography_sController()
        {
            biographyServices_ = new biographyServices();
        }

        // GET: Biography_s
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult _partialBiography(string Variable_)
        {
            var biographyList = biographyServices_.getListStartWith(Variable_);
            return PartialView("_partialBiography", biographyList);
        }
        // GET: Biography_s/Create
        public ActionResult Create()
        {
             return View();
        }

        // POST: Biography_s/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
 
        public ActionResult Create(Biography_s biography_s, HttpPostedFileBase files)
        {
            String fileName = "";
            if (files != null)
            {
                fileName = Guid.NewGuid() + "_" + Path.GetFileName(files.FileName);
                var path = Path.Combine(Server.MapPath("~/Logo/"), fileName);
                files.SaveAs(path);
                biography_s.image = "http://electo.qendidate.com/Logo/" + fileName;
            }

            else
            {
                biography_s.image = "http://electo.qendidate.com/Logo/" + "Emptyuser.jpg";
            }
           
            int result = biographyServices_.createbiography(biography_s);
            if (result == 1)
            {
                TempData["Result"] = "Success";
            }
            else {
                TempData["Result"] = "Failure";
            }
            return View();
        }

        // GET: Biography_s/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var biography_s = biographyServices_.Find((int)id);
            if (biography_s == null)
            {
                return HttpNotFound();
            }           
            return View(biography_s);
        }

        // POST: Biography_s/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Biography_s biography_s, HttpPostedFileBase files)
        {
            String fileName = "";
            if (files != null)
            {
                fileName = Guid.NewGuid() + "_" + Path.GetFileName(files.FileName);
                var path = Path.Combine(Server.MapPath("~/Logo/"), fileName);
                files.SaveAs(path);
                biography_s.image = "http://electo.qendidate.com/Logo/" + fileName;
            }

            int result = biographyServices_.updatebiography(biography_s);
            if (result == 1)
            {
                TempData["Result"] = "Success";
            }
            else
            {
                TempData["Result"] = "Failure";
            }
            return View(biography_s);
        }
                

    }
}
