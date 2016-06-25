using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Services;

namespace Blog.AI.Controllers
{
    public class ContactController : Controller
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReadMessage(int id)
        {
            return View();
        }
    }
}