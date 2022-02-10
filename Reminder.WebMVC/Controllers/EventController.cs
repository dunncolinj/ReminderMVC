using Microsoft.AspNet.Identity;
using Reminder.Models;
using Reminder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reminder.WebMVC.Controllers
{
    public class EventController : Controller
    {
        private EventService CreateEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userId);
            return service;
        }

        // GET: My Events
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userID);
            var model = service.GetEvents();
            return View(model);
        }

        // GET: Event Details
        public ActionResult Details(int id)
        {
            var svc = CreateEventService();
            var model = svc.GetEventById(id);
            return View(model);
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateEventService();

            if (service.CreateEvent(model))
            {
                ViewBag.SaveResult = "Your event was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Event could not be created.");
            return View(model);
        }

        // GET: Update Event
        public ActionResult Update(int id)
        {
            var service = CreateEventService();
            var detail = service.GetEventById(id);
            var model = new EventUpdate
            {
                Id = detail.Id,
                RelationshipId = detail.RelationshipId,
                Name = detail.Name,
                Date = detail.Date,
                Description = detail.Description,
                NotifyBefore = detail.NotifyBefore
            };
            return View();
        }

        // POST: Update Event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, EventUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id != id)
            {
                ModelState.AddModelError("", "ID mismatch");
                return View(model);
            }

            var service = CreateEventService();
            if (service.UpdateEvent(model))
            {
                TempData["SaveResult"] = "Your event was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your event could not be updated.");
            return View(model);
        }

        // GET: Delete Event
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateEventService();
            var model = svc.GetEventById(id);
            return View(model);
        }

        // POST: Delete Event
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateEventService();
            service.DeleteEvent(id);
            TempData["SaveResult"] = "Your event was deleted.";
            return RedirectToAction("Index");
        }
    }
}