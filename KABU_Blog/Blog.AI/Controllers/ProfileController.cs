using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Blog.AI.Models;
using Blog.Models;
using Blog.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Blog.AI.Controllers
{
    public class ProfileController : KabuController
    {
        private ApplicationUserManager _userManager;

        public ProfileController()
        {

        }
        public ProfileController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }


        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Informations()
        {
            var currentUser = UserManager.FindByIdAsync(User.Identity.GetUserId()).Result;
            var userInformation = new UserInformationViewModel
            {
                Name = currentUser.Name,
                Birthdate = currentUser.Birthdate,
                Surname = currentUser.Surname
            };

            return View(userInformation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Informations(UserInformationViewModel userInformation)
        {
            var viewResult = RenderRazorViewToString("Informations", userInformation);
            if (ModelState.IsValid)
            {
                var currentUser = UserManager.FindByIdAsync(User.Identity.GetUserId()).Result;
                currentUser.Name = userInformation.Name;
                currentUser.Surname = userInformation.Surname;
                currentUser.Birthdate = userInformation.Birthdate;

                var result = UserManager.Update(currentUser);

                return Json(new { view = viewResult, title = "Başarılı !", message = "Kullanıcı bilgileri başarıyla kayıt edildi.", IsCompleted = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { view = viewResult, IsCompleted = false }, JsonRequestBehavior.AllowGet);
        }
    }
}