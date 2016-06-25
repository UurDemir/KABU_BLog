using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.AI.Models;
using Blog.Models.Types;
using Blog.Mvc;
using Blog.Services;
using Microsoft.AspNet.Identity;

namespace Blog.AI.Controllers
{
    public class CommonController : KabuController
    {
        private IContactService _contactService;

        public CommonController(IContactService contactService)
        {
            this._contactService = contactService;
        }


        public ActionResult _Header()
        {
            return PartialView("_Header");
        }

        public ActionResult _Navigation()
        {
            dynamic navigation = new ExpandoObject();
            navigation.controller = GetRoute("controller", true);
            navigation.action = GetRoute("action", true);


            return PartialView("_Navigation", navigation);
        }

        public ActionResult _Notifications()
        {
            return PartialView("_Notifications");
        }

        public ActionResult _Contacts()
        {
            var orderedContacts = _contactService.Get().Result.OrderByDescending(con => con.Created);
            var contactViewModel = new ContactViewModel
            {
                Contacts = orderedContacts.Take(5).ToList(),
                TotalContact = orderedContacts.Count(),
                UnReadCount = orderedContacts.Count(con => con.ContactStatus == ContactStatus.UnRead && con.Status != Status.Deleted)
            };

            return PartialView("_Contacts", contactViewModel);
        }
    }
}