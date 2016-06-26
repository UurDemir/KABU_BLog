﻿using System;
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
    public class SettingController : KabuController
    {
        private ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        // GET: Setting
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNew(Setting model)
        {
            if (!ModelState.IsValid)
                return Json(new { IsCompleted = false }, JsonRequestBehavior.AllowGet);

           model.Status = Status.Active;

            _settingService.Create(model);

            return View();
        }

        [HttpGet]
        public ActionResult Settings()
        {
            var model = GenerateTableModel(new TableViewModel<Setting>());

            return PartialView(model);
        }

        private TableViewModel<Setting> GenerateTableModel(TableViewModel<Setting> model)
        {
            var data = _settingService.Get().Result;

            model.Hits = data.OrderBy(x => x.Id).Skip((model.CurrentPage - 1)*model.Perpage).Take(model.Perpage).ToList();
            model.TotalCount = data.ToList().Count;
            return model;
        }

        public JsonResult RefreshTableData(TableViewModel<Setting> tableModel)
        {
            var viewResult = RenderRazorViewToString("Settings", GenerateTableModel(tableModel));
            return Json(new { view = viewResult, IsCompleted = true });
        }

    }
}