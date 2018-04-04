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
    public class EventTypeController : BaseClass
    {

        private readonly IEventTypeService _EventTypeService;
        public EventTypeController()
        {
            _EventTypeService = new EventTypeService();
        }
        // GET: EventType
        public ActionResult Index()
        {
            var EventTypeList_ = _EventTypeService.GetEventTypeList();
            return View(EventTypeList_);
        }


        [HttpGet]
        public ActionResult create()
        {
            eventType oeventType = new eventType();
            return View(oeventType);
        }
        [HttpPost]
        public ActionResult create(eventType oeventType)
        {
            bool result = false;

            oeventType.createdBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString()));
            oeventType.modifiedBy = Convert.ToInt16(BaseUtil.GetSessionValue(AdminInfo.LoginID.ToString())); 
            oeventType.isActive = true;
            oeventType.dataIsCreated = BaseUtil.GetCurrentDateTime();
            oeventType.dataIsUpdated = BaseUtil.GetCurrentDateTime();
            result = _EventTypeService.addNewEventType(oeventType);

            if (result)
            {
                TempData["Result"] = "Success";
                return RedirectToAction("Index");
            }
            TempData["Result"] = "unsuccess";

            return View(oeventType);
        }
    }
}