using Reminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reminder.WebMVC.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            return View();
        }

        // GET: Read Message
        public ActionResult Details(MessageDetails model)
        {
            return View();
        }

        // GET: Create Message
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create Message
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MessageCreate model)
        {
            return View();
        }

        // GET: Delete Message
        public ActionResult Delete()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MessageDelete model)
        {
            return View();
        }
    }
}