using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Mvc;
using Blog.Services;

namespace Blog.AI.Controllers
{
    public class SettingController : KabuController
    {
        private ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        // GET: Setting
        public ActionResult Index()
        {
            return View();
        }
    }
}