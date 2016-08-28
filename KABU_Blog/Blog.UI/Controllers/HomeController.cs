using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Blog.Models;
using Blog.Models.Contexts;
using Blog.Models.Types;
using Blog.UI.Models;
using Microsoft.AspNet.Identity;

namespace Blog.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Blog");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Blog()
        {
            using (var ctx = new BlogContext())
            {
                var articles = ctx.Articles
                    .Include(a => a.Comments)
                    .OrderByDescending(a => a.Created).ToList();
                return View(articles);
            }
        }

        public ActionResult Post(int id)
        {
            using (var ctx = new BlogContext())
            {
                var article = ctx.Articles.Where(a => a.Id == id)
                    .Include(a => a.Comments)
                    .FirstOrDefault();

                if (article == null)
                {
                    return HttpNotFound();
                }

                article.ViewCount += 1;
                ctx.SaveChanges();

                return View(article);
            }
        }

        public ActionResult Sidebar()
        {
            using (var ctx = new BlogContext())
            {
                var articles = ctx.Articles.OrderByDescending(a => a.ViewCount).Take(3).ToList();
                var categories = ctx.Categories.ToList();

                var sidebarModel = new SidebarViewModel
                {
                    Categories = categories,
                    Articles = articles
                };

                return PartialView(sidebarModel);
            }
        }

        [HttpPost]
        public JsonResult Comment(Comment model)
        {
            // Remove id in model state for validation! :)
            ModelState.Remove("UserIp");

            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var errors = ModelState.Values.Select(x => x.Errors.Select(er => er.ErrorMessage));
                var result = "";
                foreach (var error in errors)
                {
                    foreach (var str in error)
                    {
                        result += "\n" + str;
                    }
                }
                return Json(new { Message = result }, JsonRequestBehavior.AllowGet);
            }

            using (var ctx = new BlogContext())
            {
                var comment = new Comment
                {
                    ArticleId = model.ArticleId,
                    CommentStatus = CommentStatus.New,
                    Email = model.Email,
                    Fullname = model.Fullname,
                    Message = model.Message,
                    Created = DateTime.Now,
                    Status = Status.Active,
                    UserIp = Request.ServerVariables["REMOTE_ADDR"].ToString(),
                    ParentId = null
                };
                ctx.Comments.Add(comment);
                ctx.SaveChanges();
            }

             return Json(new { Message = "MESAJINIZ TARAFIMIZA ULAŞMIŞTIR." }, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult Contact(Contact model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var errors = ModelState.Values.Select(x => x.Errors.Select(er => er.ErrorMessage));
                var result = "";
                foreach (var error in errors)
                {
                    foreach (var str in error)
                    {
                        result += "\n" + str;
                    }
                }
                return Json(new { Message = result }, JsonRequestBehavior.AllowGet);
            }

            using (var ctx = new BlogContext())
            {
                var contactForm = new Contact
                {
                    Fullname = model.Fullname,
                    ContactStatus = ContactStatus.UnRead,
                    Created = DateTime.Now,
                    Email = model.Email,
                    Message = model.Message,
                    Title = "İletişim",
                    Status = Status.Active,
                    UserIp = Request.ServerVariables["REMOTE_ADDR"].ToString()
                };

                ctx.Contacts.Add(contactForm);
                ctx.SaveChanges();
            }

            return Json(new { Message = "MESAJINIZ TARAFIMIZA ULAŞMIŞTIR." }, JsonRequestBehavior.AllowGet);
        }
    }
}