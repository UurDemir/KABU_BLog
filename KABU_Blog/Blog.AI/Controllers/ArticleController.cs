using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.AI.Models;
using Blog.Models;
using Blog.Models.Types;
using Blog.Mvc;
using Blog.Services;

namespace Blog.AI.Controllers
{
    public class ArticleController : KabuController
    {
        private IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            this._articleService = articleService;
        }

        // GET: Article
        public ActionResult Index()
        {
            return View(GenerateTableModel(new TableViewModel<Article>()));
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RefreshTableData(TableViewModel<Article> tableModel)
        {
            var viewResult = RenderRazorViewToString("Table", GenerateTableModel(tableModel));

            return Json(new { view = viewResult, IsCompleted = true });
        }

        private TableViewModel<Article> GenerateTableModel(TableViewModel<Article> table)
        {
            var search = table.Search ?? "";

            var tableList =
                _articleService.Get(
                    x => x.Status != Status.Deleted && (
                        x.Title.Contains(search) || x.ContentSummary.Contains(search))).Result;

            table.Hits = tableList.OrderBy(x => x.Id).Skip((table.CurrentPage - 1) * table.Perpage).Take(table.Perpage).ToList();
            table.TotalCount = tableList.Count();
            return table;
        }
    }
}