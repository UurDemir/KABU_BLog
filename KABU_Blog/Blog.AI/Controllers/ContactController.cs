using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Blog.AI.Models;
using Blog.Models;
using Blog.Models.Types;
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

        public async Task<ActionResult> ReadMessage(int id)
        {
            var contact = await _contactService.FindById(id);

            if (contact == null)
                return Index();

            return View(contact);
        }

        public async Task<JsonResult> Remove(int id)
        {
            var model = await _contactService.FindById(id);

            if (model == null)
                return Json(new { IsCompleted = false, title = "Hata !", message = "Model Bulunamadı !" }, JsonRequestBehavior.AllowGet);

            _contactService.Delete(model);

            return Json(new { IsCompleted = true, title = "Başarılı !", message = "Başarı ile silindi !" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Update(int id, ContactStatus ContactStatus)
        {
            var updatingModel = await _contactService.FindById(id);

            if (updatingModel == null)
                throw new Exception("Model bulunamadı.");

            updatingModel.ContactStatus = ContactStatus;

            var viewResult = RenderRazorViewToString("Show", updatingModel);

            if (!ModelState.IsValid)
                return Json(new { view = viewResult, IsCompleted = false }, JsonRequestBehavior.AllowGet);

            _contactService.Update(updatingModel);

            return Json(new { view = viewResult, title = "Başarılı !", message = "Başarı ile güncellendi.", IsCompleted = true }, JsonRequestBehavior.AllowGet);
        }

        public TableViewModel<Contact> GenerateTableModel(TableViewModel<Contact> table)
        {
            var search = table.Search ?? "";

            var tableList =
                _contactService.Get(
                    x => x.Status != Status.Deleted && (
                        x.Email.Contains(search) || x.Fullname.Contains(search) || x.Message.Contains(search) ||
                        x.Title.Contains(search) || x.UserIp.Contains(search) || x.PhoneNumber.Contains(search))).Result;

            table.Hits = tableList.OrderBy(x => x.Id).Skip((table.CurrentPage - 1) * table.Perpage).Take(table.Perpage).ToList();
            table.TotalCount = tableList.Count();
            return table;
        }
    }
}
