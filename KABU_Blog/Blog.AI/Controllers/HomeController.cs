using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Blog.Models;
using Blog.Models.Types;
using Blog.Services;

namespace Blog.AI.Controllers
{
    public class HomeController : Controller
    {
        private ISettingService settingService;
        private ISocialMediaService socialMediaService;
        public HomeController(ISettingService settingService, ISocialMediaService socialMediaService)
        {
            this.settingService = settingService;
            this.socialMediaService = socialMediaService;
        }

        public ActionResult Index()
        {
            socialMediaService.Create(new SocialMedia
            {
                Id = "twitter",
                Name = "Twitter",
                Status = Status.Active,
                Icon = "",
                Link = "http://www.twitter.com/kagan_kaptan"
            });
            return View();
        }

        public async Task<ActionResult> About()
        {
            var socialMedias = await socialMediaService.Get();
            return View(socialMedias.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}