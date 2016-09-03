using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Blog.AI.Models;
using Blog.Models;
using Blog.Models.Contexts;
using Blog.Models.Types;
using Blog.Mvc;
using Blog.Services;

namespace Blog.AI.Controllers
{
    public class ArticleController : KabuController
    {
        private readonly IArticleService _articleService;
        private ICategoryService _categoryService;

        public ArticleController(IArticleService articleService, ICategoryService categoryService)
        {
            this._articleService = articleService;
            _categoryService = categoryService;
        }

        // GET: Article
        public ActionResult Index()
        {
            return View(GenerateTableModel(new TableViewModel<Article>()));
        }

        [HttpGet]
        public ActionResult New()
        {
            ViewBag.Categories = _categoryService.Get().Result.OrderBy(x => x.Name).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewItem(ArticleViewModel model)
        {
            ViewBag.Categories = _categoryService.Get().Result.OrderBy(x => x.Name).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            var viewResult = RenderRazorViewToString("New", model);

            // Remove id in model state for validation! :)
            ModelState.Remove("Article.Id");

            if (!ModelState.IsValid)
            {
                return Json(new { message = "Lütfen değerleri doğru giriniz!", IsCompleted = false }, JsonRequestBehavior.AllowGet);
            }

            var categories = _categoryService.Get(c => model.CategoryIds.Contains(c.Id)).Result;

            if (model.Article.Id == 0)
            {
                var article = new Article
                {
                    Title = model.Article.Title,
                    Content = model.Article.Content,
                    ContentSummary = model.Article.ContentSummary,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,
                    Status = model.Article.Status,
                    ViewCount = 0,
                    Categories = categories.ToList()
                };
                _articleService.Create(article);
            }
            else
            {
                //using (var ctx = new BlogContext())
                //{
                    //var art = ctx.Articles.Include(a => a.Categories).FirstOrDefault(a => a.Id == model.Article.Id);
                    //if (art == null)
                    //{
                    //    return Json(new { message = "Bu isimde bir gönderi bulunmamaktadır. Lütfen tekrar deneyiniz!", IsCompleted = false }, JsonRequestBehavior.AllowGet);
                    //}

                    //var existingCategories = art.Categories.ToArray();
                    //foreach (var existingCategory in existingCategories)
                    //{
                    //    art.Categories.Remove(existingCategory);
                    //}

                //}

                var findArticle = _articleService.FindBy(a => a.Id == model.Article.Id, a => a.Categories).Result;

                if (findArticle == null)
                {
                    return Json(new { message = "Bu isimde bir gönderi bulunmamaktadır. Lütfen tekrar deneyiniz!", IsCompleted = false }, JsonRequestBehavior.AllowGet);
                }
                var existingCategories = findArticle.Categories.ToArray();
                foreach (var existingCategory in existingCategories)
                {
                    findArticle.Categories.Remove(existingCategory);
                }

                findArticle.Title = model.Article.Title;
                findArticle.Content = model.Article.Content;
                findArticle.ContentSummary = model.Article.ContentSummary;
                findArticle.Updated = DateTime.Now;
                findArticle.Status = model.Article.Status;
                findArticle.Categories = categories.ToList();
                _articleService.Update(findArticle);
            }

            return Json(new { view = viewResult, Name = model.Article.Title, message = "Yeni yazı başarı ile güncellenmiştir!", IsCompleted = true },
                JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Categories = _categoryService.Get().Result.OrderBy(x => x.Name).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            var article = _articleService.FindById(id, a => a.Categories).Result;
            if (article == null)
                return Index();

            int[] categoryIds = article.Categories.Select(c => c.Id).ToArray();

            var articleViewModel = new ArticleViewModel
            {
                Article = article,
                CategoryIds = categoryIds
            };

            return View(articleViewModel);
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

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/l"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("Index", "Article");
        }
    }
}