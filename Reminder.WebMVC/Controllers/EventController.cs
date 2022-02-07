using Reminder.Models;
using Reminder.Models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reminder.WebMVC.Controllers
{
    public class EventController : Controller
    {
        // GET: My Events
        public ActionResult Index()
        {
            return View();
        }

        // GET: Event Details
        public ActionResult Details(EventDetails model)
        {
            return View();
        }

        // GET: Create Event
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create Event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreate model)
        {
            return View();
        }

        // GET: Update Event
        public ActionResult Update()
        {
            return View();
        }

        // POST: Update Event
        public ActionResult Update(EventUpdate model)
        {
            return View();
        }

        // GET: Delete Event
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Delete Event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EventDelete model)
        {
            return View();
        }
    }
}