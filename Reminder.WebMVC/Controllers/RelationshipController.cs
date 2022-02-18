using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Reminder.Data;
using Reminder.Models;
using Reminder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reminder.WebMVC.Controllers
{
    public class RelationshipController : Controller
    {
        private RelationshipService CreateRelationshipService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RelationshipService(userId);
            return service;
        }

        // GET: Relationship - read - list my relationships
        public ActionResult Index()
        {
            var service = CreateRelationshipService();
            var model = service.GetRelationships();
            return View(model);
        }

        // GET: Relationship - details
        public ActionResult Details(int id)
        {
            var service = CreateRelationshipService();
            var model = service.GetRelationshipById(id);
            return View(model);
        }

        // GET: Relationship - list users

        public ActionResult ListUsers()
        {
            var service = CreateRelationshipService();
            var model = service.ListUsers();
            return View(model);
        }

        // GET: Relationship - create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Relationship - create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RelationshipCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateRelationshipService();

            if (service.CreateRelationship(model))
            {
                ViewBag.SaveResult = "Relationship created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Failed to create relationship.");
            return View(model);
        }

        // GET: Relationship - update
        [ActionName("Update")]
        public ActionResult Update(int id)
        {
            var service = CreateRelationshipService();
            var detail = service.GetRelationshipById(id);
            var model = new RelationshipUpdate
            {
                // property = detail.property
                Id = detail.Id,
                RelatedUserName = detail.RelatedUserName,
                HowRelated = detail.HowRelated,
                Connected = detail.Connected
            };
            return View(model);
        }

        // POST: Relationship - update
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Update")]
        public ActionResult Update(int id, RelationshipUpdate model)
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

            var service = CreateRelationshipService();
            if (service.UpdateRelationship(model))
            {
                TempData["SaveResult"] = "Relationship updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Relationship could not be updated.");
            return View(model);
        }

        // GET: Relationship - delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRelationshipService();
            var model = svc.GetRelationshipById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRelationshipService();
            service.DeleteRelationship(id);
            TempData["SaveResult"] = "Relationship deleted.";
            return RedirectToAction("Index");
        }
    }
}