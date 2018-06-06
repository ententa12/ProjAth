using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ASPProject.Models;
using System.Web.Security;
using ASPProject.BL;
using ASPProject.Entities;

namespace ASPProject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        DatabaseLogic _db;
        public AccountController()
        {
            _db = new DatabaseLogic();
            
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = new User() { Email = model.Email, Password = model.Password };

            user = _db.GetUserDetails(user);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(model.Email, false);

                var authTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.Roles);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                if(user.Roles == "Secretary") return RedirectToAction("Index", "Secretary");
                else if(user.Roles == "Director") return RedirectToAction("Index", "Director");
                else if (user.Roles == "User") return RedirectToAction("Index", "User");
                return RedirectToAction("Index", "Home");
            }

            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }
        //
        // POST: /Account/LogOff
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult ChangePassword(ChangePasswordViewModel viewModel)
        {
            if (viewModel.Password == viewModel.ConfirmPassword)
            {
                _db.ChangePassword(viewModel.Password, User.Identity.Name);
            }
            return RedirectToAction("UserDetails", "Account");
        }

        public ActionResult UserDetails()
        {
            var currentUser = _db.GetUserByEmail(User.Identity.Name);
            ViewBag.Role = currentUser.Roles;
            var model = new UserDetailsViewModel()
            {
                Email = currentUser.Email,
                FirstName = currentUser.UserDetails.FirstName,
                LastName = currentUser.UserDetails.LastName,
                Roles = currentUser.Roles
            };
            return View(model);
        }

        public ActionResult EditUser()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult EditUser(UserDetailsViewModel model)
        {
            Tuple<int, string> tuple = new Tuple<int, string>(_db.GetUserByEmail(User.Identity.Name).UserDetailsId, _db.GetUserByEmail(User.Identity.Name).Roles);
            var user = new User()
            {
                Email = model.Email,
                Roles = tuple.Item2,
                UserDetails = new UserDetails()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                }
            };
            _db.ModyfiUser(tuple.Item1, user);
            return RedirectToAction("UserDetails", "Account");
        }

    }
}