using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wiki.Web.Identity;
using Wiki.Web.ViewModels.User;

namespace Wiki.Web.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>(new WikiIdentityDbContext());
                var userManager = new UserManager<IdentityUser>(userStore);
                var identityUser = new IdentityUser
                {
                    UserName = viewModel.Email,
                    Email = viewModel.Email
                };
                IdentityResult result = userManager.Create(identityUser, viewModel.Password);
                if (result.Succeeded)
                {
                    return View("Login");
                }
                else
                {
                    ModelState.AddModelError("error_identity", result.Errors.First());
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>(new WikiIdentityDbContext());
                var userManager = new UserManager<IdentityUser>(userStore);
                var user = userManager.Find(viewModel.Email, viewModel.Password);
                if (user == null)
                {
                    ModelState.AddModelError("error_identity", "Email or Password invalid.");
                    return View(viewModel);
                }
                var authManager = HttpContext.GetOwinContext().Authentication;
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties
                {
                    IsPersistent = false
                }, identity);
                return RedirectToAction("Index", "Characters");
            }
            return View(viewModel);
        }

        public ActionResult Logoff()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return View("Login");
        }
    }
}