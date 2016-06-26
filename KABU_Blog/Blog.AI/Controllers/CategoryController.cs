using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Mvc;

namespace Blog.AI.Controllers
{
    public class CategoryController : KabuController
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }
    }
}