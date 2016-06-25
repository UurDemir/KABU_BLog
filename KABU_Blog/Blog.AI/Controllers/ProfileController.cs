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

            return PartialView(userInformation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveInformations(UserInformationViewModel userInformation)
        {
            var viewResult = RenderRazorViewToString("Informations", userInformation);
            if (!ModelState.IsValid)
                return Json(new { view = viewResult, IsCompleted = false }, JsonRequestBehavior.AllowGet);

            var currentUser = UserManager.FindByIdAsync(User.Identity.GetUserId()).Result;
            currentUser.Name = userInformation.Name;
            currentUser.Surname = userInformation.Surname;
            currentUser.Birthdate = userInformation.Birthdate;

            var result = UserManager.Update(currentUser);

            return Json(result.Succeeded ? new { view = viewResult, title = "Başarılı !", message = "Kullanıcı bilgileri başarıyla kayıt edildi.", IsCompleted = true } : new { view = viewResult, title = "Hata !", message = GetErrorMessage(result.Errors), IsCompleted = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> SaveChangePassword(ChangePasswordViewModel changePassword)
        {
            var viewResult = RenderRazorViewToString("ChangePassword", changePassword);
            if (!ModelState.IsValid)
                return Json(new { view = viewResult, IsCompleted = false }, JsonRequestBehavior.AllowGet);

            var currentUser = UserManager.FindByIdAsync(User.Identity.GetUserId()).Result;
            var result = await UserManager.ChangePasswordAsync(currentUser.Id, changePassword.OldPassword, changePassword.NewPassword);

            return Json(result.Succeeded ? new { view = viewResult, title = "Başarılı !", message = "Şifre başarıyla değiştirildi.", IsCompleted = true } : new { view = viewResult, title = "Hata !", message = GetErrorMessage(result.Errors), IsCompleted = false }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult _LoginPartial()
        {
            var currentUser = UserManager.FindByNameAsync(User.Identity.Name).Result;
            return PartialView("_LoginPartial", currentUser.Name + " " + currentUser.Surname);
        }

    }
}