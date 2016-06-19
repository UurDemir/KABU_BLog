using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Blog.AI.Controllers
{
    public class CommonController : Controller
    {
        public ActionResult _LoginPartial()
        {
            return PartialView("_LoginPartial",User.Identity.GetUserName());
        }

        public ActionResult _Header()
        {
            return PartialView("_Header");
        }


        public ActionResult _Notifications()
        {
            return PartialView("_Notifications");
        }
    }
}