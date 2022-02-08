using Reminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reminder.WebMVC.Controllers
{
    public class RelationshipController : Controller
    {
        // GET: Relationship - read - list my relationships
        public ActionResult Index()
        {
            return View();
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
            return View();
        }

        // GET: Relationship - update
        public ActionResult Update()
        {
            return View();
        }

        // POST: Relationship - update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(RelationshipUpdate model)
        {
            return View();
        }

        // GET: Relationship - delete
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RelationshipDelete model)
        {
            return View();
        }
    }

}