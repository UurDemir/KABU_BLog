using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Blog.AI.Models;
using Blog.Models;
using Blog.Mvc;
using Blog.Services;

namespace Blog.AI.Controllers
{
    public class PageController : KabuController
    {
        private IPageService _pageService;


        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        // GET: Page
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PageInformation()
        {
            return PartialView(GenerateTableModel(new TableViewModel<Page>()));
        }

        public async Task<ActionResult> EditPage(int id)
        {
            var page = await _pageService.FindById(id);

            if (page == null)
                return Index();
            return View(page);
        }

        [HttpGet]
        public ActionResult NewPage()
        {
            return PartialView();
        }

        public TableViewModel<Page> GenerateTableModel(TableViewModel<Page> table)
        {
            var tableList = _pageService.Get().Result;
            table.Hits = tableList.OrderBy(x => x.Id).Skip((table.CurrentPage - 1) * table.Perpage).Take(table.Perpage).ToList();
            table.TotalCount = tableList.Count();
            return table;
        }
    }
}