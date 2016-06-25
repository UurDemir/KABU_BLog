using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Mvc;
using Microsoft.AspNet.Identity;

namespace Blog.AI.Controllers
{
    public class CommonController : KabuController
    {

        public ActionResult _Header()
        {
            return PartialView("_Header");
        }

        public ActionResult _Navigation()
        {
            dynamic navigation = new ExpandoObject();
            navigation.controller = GetRoute("controller",true);
            navigation.action = GetRoute("action",true);


            return PartialView("_Navigation", navigation);
        }
        
        public ActionResult _Notifications()
        {
            return PartialView("_Notifications");
        }
    }
}