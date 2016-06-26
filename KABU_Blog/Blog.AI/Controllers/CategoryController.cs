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
            ViewBag.Category = _categoryService.Get().Result;
            ViewBag.Language = _languageService.Get().Result;
            return View();
        }

        public ActionResult SaveCategory(Category model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new {isCompleted = false}, JsonRequestBehavior.AllowGet);
            }

            if (model.Id == 0)
            {
                _categoryService.Create(model);
            }
            else
            {
                _categoryService.Update(model);
            }

            return Json(1, JsonRequestBehavior.AllowGet);
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