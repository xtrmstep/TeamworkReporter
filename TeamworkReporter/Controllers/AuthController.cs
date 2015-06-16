using System.Web.Mvc;
using System.Web.Security;
using TeamworkReporter.Controllers.Abstractions;
using TeamworkReporter.Models.Auth;
using TeamworkReporter.Services.Permissions;

namespace TeamworkReporter.Controllers
{
    public class AuthController : SensitiveController
    {
        ISecurityService _securityService;
        IAccountService _accountService;

        public AuthController()
        {

        }

        public AuthController(ISecurityService securityService, IAccountService accountService)
        {
            _securityService = securityService;
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                //todo register a user
                return RedirectToAction("SignIn", "Auth");
            }
            return View();
        }

        [HttpGet]
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgetPassword(ForgetPasswordViewModel model)
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // todo save the password
                RedirectToAction("ResetPassword", "Auth");
            }
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
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid && Membership.ValidateUser(model.Email, model.Password))
            {
                //todo FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                if (Url.IsLocalUrl(model.ReturnUrl))
                    return Redirect(model.ReturnUrl);
                return RedirectToAction("Index", "Home");
            }

            tempStorage.Set(model);
            return View(model);
        }
    }
}