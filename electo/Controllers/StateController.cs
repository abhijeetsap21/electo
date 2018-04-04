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
    public class StateController : BaseClass
    {
        private readonly IstateService _stateService;
        public StateController()
        {
            
            _stateService = new stateService();
        }

        // GET: State
        public ActionResult Index()
        {
            var stateList = _stateService.getAllStates();
            return View(stateList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            int result = 0;
            result= _stateService.create(frm["stateName"].ToString());
            ViewBag.result = result;
            return View();
        }

    }
}