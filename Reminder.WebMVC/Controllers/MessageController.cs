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
    public class MessageController : Controller
    {

        private MessageService CreateMessageService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MessageService(userId);
            return service;
        }

        // GET: List users

        // GET: Message List
        public ActionResult Index()
        {
            var service = CreateMessageService();
            var model = service.GetMessagesInbox();
            return View(model);
        }

        public ActionResult Outbox()
        {
            var service = CreateMessageService();
            var model = service.GetMessagesOutbox();
            return View(model);
        }

        // GET: Message Details
        public ActionResult Details(int id)
        {
            var service = CreateMessageService();
            var model = service.GetMessageById(id);
            return View(model);
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateMessageService();

            if (service.CreateMessage(model))
            {
                ViewBag.SaveResult = "Message sent successfully.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Message was not sent.");
            return View(model);
        }

        // GET: Delete Message
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMessageService();
            var model = svc.GetMessageById(id);
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMessageService();
            service.DeleteMessage(id);
            TempData["SaveResult"] = "Message deleted.";
            return RedirectToAction("Index");
        }
    }
}