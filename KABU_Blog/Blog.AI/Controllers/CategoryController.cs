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
            var categories = _categoryService.Get().Result.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            categories.Add(new SelectListItem
            {
                Text = "",
                Value = "",
                Selected = true
            });
            ViewBag.Categories = categories;
            ViewBag.Languages = _languageService.Get().Result.ToList();
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
            var viewResult = RenderRazorViewToString("New", model);

            if (!ModelState.IsValid)
            {
                return Json(new { isCompleted = false }, JsonRequestBehavior.AllowGet);
            }

            if (model.Id == 0)
            {
                _categoryService.Create(model);
            }
            else
            {

                _categoryService.Update(model);
            }

            return Json(new { view = viewResult, message = "Yeni kategori başarı ile eklenmiştir!", isCompleted = true },
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