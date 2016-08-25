using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Blog.AI.Models;
using Blog.Models;
using Blog.Mvc;
using Blog.Services;

namespace Blog.AI.Controllers
{
    public class CategoryController : KabuController
    {
        private ICategoryService _categoryService;
        private ILanguageService _languageService;

        public CategoryController(ICategoryService categoryService, ILanguageService languageService)
        {
            _categoryService = categoryService;
            _languageService = languageService;
        }

        // GET: Category
        public ActionResult Index()
        {
            return View(GenerateTableModel(new TableViewModel<Category>()));
        }

        public ActionResult New()
        {
            List<SelectListItem> categories = new List<SelectListItem>();
            categories.Add(new SelectListItem
            {
                Text = "Üst Kategorisi yok",
                Value = "-1",
                Selected = true
            });
            categories.AddRange(_categoryService.Get().Result.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList());
            
            ViewBag.Categories = categories;
            ViewBag.Languages = _languageService.Get().Result.OrderByDescending(l => l.NativeName).Select(x=> new SelectListItem
            {
                Text = x.NativeName,
                Value = x.Id
            }).ToList();
            return View();
        }

        public ActionResult Edit(int id)
        {
            var category = _categoryService.FindById(id).Result;
            if (category == null)
            {
                return Index();
            }
            return View(category);
        }

        public ActionResult SaveCategory(Category model)
        {
            List<SelectListItem> categories = new List<SelectListItem>();
            categories.Add(new SelectListItem
            {
                Text = "Üst Kategorisi yok",
                Value = "-1",
                Selected = true
            });
            categories.AddRange(_categoryService.Get().Result.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList());

            ViewBag.Categories = categories;
            ViewBag.Languages = _languageService.Get().Result.Select(x => new SelectListItem
            {
                Text = x.NativeName,
                Value = x.Id
            }).ToList();
            var viewResult = RenderRazorViewToString("Show", model);

            if (!ModelState.IsValid)
            {
                return Json(new { message = "Lütfen değerleri doğru giriniz!", IsCompleted = false }, JsonRequestBehavior.AllowGet);
            }

            if (model.Id == 0)
            {
                var findCategory = _categoryService.FindBy(c => c.Slug == model.Slug).Result;
                if (findCategory != null)
                {
                    return Json(new { message = "Bu isimde bir kategori bulunmaktadır. Lütfen tekrar deneyiniz!", IsCompleted = false }, JsonRequestBehavior.AllowGet);
                }
                model.ParentId = model.ParentId != -1 ? model.ParentId : null;
                _categoryService.Create(model);
            }
            else
            {
                var findCategory = _categoryService.FindBy(c => c.Slug == model.Slug).Result;
                if (findCategory != null)
                {
                    return Json(new { message = "Bu isimde bir kategori bulunmaktadır. Lütfen tekrar deneyiniz!", IsCompleted = false }, JsonRequestBehavior.AllowGet);
                }
                var category = _categoryService.FindById(model.Id).Result;
                category.Name = model.Name;
                category.ParentId = model.ParentId != -1 ? model.ParentId : null;
                category.LanguageId = model.LanguageId;
                category.Status = model.Status;
                _categoryService.Update(category);
            }

            return Json(new { view = viewResult, Name = model.Name, message = "Yeni kategori başarı ile eklenmiştir!", IsCompleted = true },
                JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RefreshTableData(TableViewModel<Category> tableModel)
        {
            var viewResult = RenderRazorViewToString("Index", GenerateTableModel(tableModel));

            return Json(new { view = viewResult, IsCompleted = true });
        }

        public TableViewModel<Category> GenerateTableModel(TableViewModel<Category> table)
        {
            var search = table.Search ?? "";

            var tableList =
                _categoryService.Get(
                    x =>
                        x.Name.Contains(search) || x.Description.Contains(search) || x.Slug.Contains(search)).Result;

            table.Hits = tableList.OrderBy(x => x.Id).Skip((table.CurrentPage - 1) * table.Perpage).Take(table.Perpage).ToList();
            table.TotalCount = tableList.Count();
            return table;
        }

    }
}