using electo.Models;
using electo.Models.BaseClass;
using electo.Models.IRepositories;
using electo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace electo.Controllers
{
    [CustomErrorHandling]
    public class ElectionController : BaseClass
    {
        private readonly IElectionService _ElectionService;

        public ElectionController()
        {
            _ElectionService = new ElectionService();
        }
        // GET: Election
        public ActionResult Elections()
        {
            ViewBag.electionYear = new SelectList((_ElectionService.getAllYears().Select(e => new { e.yearID, e.Year })), "yearID", "Year");
            ViewBag.ElectionType = new SelectList((_ElectionService.getElectionTypes().Select(e=> new { e.electionTypeID,e.electionTypeNAME})), "electionTypeID", "electionTypeNAME" );
            return View();
        }

        public ActionResult _PartialElections(int ElectionType, int ddl_year, int ddl_month) {
            var electionsList = _ElectionService.getElectionNameList(ElectionType, ddl_year, ddl_month);
         return PartialView("_PartialElections", electionsList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.monthId = _ElectionService.getAllMonthName().Select(e => new { e.monthId, e.monthName1 });
            ViewBag.electionTypeID = _ElectionService.getElectionTypes().Select(e => new { e.electionTypeID, e.electionTypeNAME });
            ViewBag.electionYear = _ElectionService.getAllYears().Select(e => new { e.yearID, e.Year });

            return View();
        }
        [HttpPost]
        public ActionResult Create(electionName oelectionName, FormCollection frm)
        {
            int result = 0;
            oelectionName.electionYear =Convert.ToInt32( frm["yearName"].ToString());
            result = _ElectionService.create(oelectionName);
            if (result == 1)
            {
                TempData["Result"] = "Success";
                return RedirectToAction("Elections");
            }
            else
            {
                ViewBag.monthId = _ElectionService.getAllMonthName().Select(e => new { e.monthId, e.monthName1 });
                ViewBag.electionTypeID = _ElectionService.getElectionTypes().Select(e => new { e.electionTypeID, e.electionTypeNAME });
                ViewBag.electionYear = _ElectionService.getAllYears().Select(e => new { e.yearID, e.Year });
                TempData["Result"] = "unsuccess";
                return View();
            }
            
        }
    

}
}