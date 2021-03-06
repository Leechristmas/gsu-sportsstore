﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Infrastructure.Concrete;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAuthProvider authProvider;

        public AccountController()
        {
            authProvider = new FormsAuthProvider();
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            return View();
        }

        public RedirectToRouteResult Logout()
        {
            authProvider.SignOut();

            return RedirectToAction("Login", "Account");
        }
    }
}