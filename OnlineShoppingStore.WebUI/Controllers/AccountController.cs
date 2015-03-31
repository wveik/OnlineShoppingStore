using Ninject;
using OnlineShoppingStore.Domain.Abstract;
using OnlineShoppingStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineShoppingStore.WebUI.Controllers {
    [Authorize]
    public class AccountController : Controller {

        [Inject]
        public IAuthentication _repository { get; set; }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login() {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl) {
            if (ModelState.IsValid) {
                if (_repository.Authecticate(model.UserName, model.Password)) {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                ModelState.AddModelError("", "Неккоректен логин или пароль");
            }
            return View();
        }

        public ActionResult Logout() {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Admin");
        }
             
    }
}