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
    public class DistrictController : BaseClass
    {
        private readonly IDistrictServices _DistrictServices;
        private readonly IstateService _stateService;
        public DistrictController()
        {
            _DistrictServices = new DistrictServices();
            _stateService = new stateService();
        }

        // GET: District
        public ActionResult Index()
        {
            ViewBag.States = new SelectList((_stateService.getAllStates().Select(e => new { e.stateID, e.stateName })), "stateID", "stateName");
            return View();
        }

        public ActionResult _partialDistrictList(int stateId) {

            var _DistrictList = _DistrictServices.getDistrictByStateID(stateId);
            return PartialView("_partialDistrictList", _DistrictList);
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.stateID = _stateService.getAllStates();
            return View();
        }
        [HttpPost]
        public ActionResult Create(district odistrict)
        {
            int result = 0;
            result = _DistrictServices.create(odistrict);
            if (result == 1)
            {
                TempData["Result"] = "Success";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Result"] = "unsuccess";
                ViewBag.stateID = _stateService.getAllStates();
                return View();
            }

           
        }
    }
}