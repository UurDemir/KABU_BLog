using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Mvc;

namespace Blog.AI.Controllers
{
    public class DashboardController : KabuController
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}