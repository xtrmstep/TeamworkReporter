using System.Web.Mvc;
using System.Web.Security;
using TeamworkReporter.Controllers.Abstractions;
using TeamworkReporter.Models.Auth;

namespace TeamworkReporter.Controllers
{
    public class AuthController : SensitiveController
    {
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            var model = new SignInViewModel
            {
                ReturnUrl = Request.QueryString["ReturnUrl"]
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid && Membership.ValidateUser(model.Email, model.Password))
            {
                //FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                if (Url.IsLocalUrl(model.ReturnUrl))
                    return Redirect(model.ReturnUrl);
                return RedirectToAction("Index", "Home");
            }

            tempStorage.Set(model);
            return View(model);
        }
    }
}