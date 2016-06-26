using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.AI.Models;
using Blog.Models;
using Blog.Mvc;
using Blog.Services;

namespace Blog.AI.Controllers
{
    public class ContactController : KabuController
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET: Contact
        public ActionResult Index()
        {
            return View(GenerateTableModel(new TableViewModel<Contact>()));
        }

        [HttpPost]
        public JsonResult RefreshTableData(TableViewModel<Contact> tableModel)
        {
            var viewResult = RenderRazorViewToString("Index", GenerateTableModel(tableModel));

            return Json(new { view = viewResult, IsCompleted = true });
        }

        public ActionResult ReadMessage(int id)
        {

            return View();
        }


        public TableViewModel<Contact> GenerateTableModel(TableViewModel<Contact> table)
        {
            var search = table.Search ?? "";

            var tableList =
                _contactService.Get(
                    x =>
                        x.Email.Contains(search) || x.Fullname.Contains(search) || x.Message.Contains(search) ||
                        x.Title.Contains(search) || x.UserIp.Contains(search) || x.PhoneNumber.Contains(search)).Result;

            table.Hits = tableList.OrderBy(x => x.Id).Skip((table.CurrentPage - 1) * table.Perpage).Take(table.Perpage).ToList();
            table.TotalCount = tableList.Count();
            return table;
        }
    }
}
