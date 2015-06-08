﻿using System.Web.Mvc;
using System.Web.Security;
using TeamworkReporter.Controllers.Abstractions;
using TeamworkReporter.Models.Auth;

namespace TeamworkReporter.Controllers
{
    public class AuthController : SensitiveController
    {
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                //todo register a user
                return RedirectToAction("SignIn", "Auth");
            }
            return View();
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        public ActionResult ResetPassword()
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