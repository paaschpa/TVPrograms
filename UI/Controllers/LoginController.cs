using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.Mvc.Ajax;
using TVPrograms.UI.Models.Forms;
using TVPrograms.Core.Domain.Repository;
using TVPrograms.Core.Domain.Model;
using TVPrograms.Core.Services;

namespace TV.Programs.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserSession _userSession;

        public LoginController(IUserRepository repository, IAuthenticationService auth, IUserSession userSess)
        {
            _userRepository = repository;
            _authenticationService = auth;
            _userSession = userSess;
        }

        public ActionResult Index()
        {
            return View(new LoginForm());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings",
            Justification = "Needs to take same parameter type as Controller.Redirect()")]
        public ActionResult Index(LoginForm loginForm, bool rememberMe, string returnUrl)
        {

            if (!ModelState.IsValid)
            {
                return View("index", loginForm);
            }

            User user = _userRepository.GetByUserName(loginForm.Username);

            if (user != null)
            {
                bool passwordMatches = _authenticationService.PasswordMatches(user, loginForm.Password);

                if (passwordMatches)
                {
                    _userSession.LogIn(user);
                    return View("index", loginForm);
                }
            }

            ModelState.AddModelError("Login", "Login incorrect");
            return View("index", loginForm);
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Register(string userName, string email, string password, string confirmPassword)
        {

            //ViewData["PasswordLength"] = MembershipService.MinPasswordLength;

            //if (ValidateRegistration(userName, email, password, confirmPassword))
            //{
            //    // Attempt to register the user
            //    MembershipCreateStatus createStatus = MembershipService.CreateUser(userName, password, email);

            //    if (createStatus == MembershipCreateStatus.Success)
            //    {
            //        FormsAuth.SignIn(userName, false /* createPersistentCookie */);
            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("_FORM", ErrorCodeToString(createStatus));
            //    }
            //}

            // If we got this far, something failed, redisplay form
            return View();
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "Exceptions result in password not being changed.")]
        public ActionResult ChangePassword(string currentPassword, string newPassword, string confirmPassword)
        {

            //ViewData["PasswordLength"] = MembershipService.MinPasswordLength;

            //if (!ValidateChangePassword(currentPassword, newPassword, confirmPassword))
            //{
            //    return View();
            //}

            //try
            //{
            //    if (MembershipService.ChangePassword(User.Identity.Name, currentPassword, newPassword))
            //    {
            //        return RedirectToAction("ChangePasswordSuccess");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("_FORM", "The current password is incorrect or the new password is invalid.");
            //        return View();
            //    }
            //}
            //catch
            //{
            //    ModelState.AddModelError("_FORM", "The current password is incorrect or the new password is invalid.");
            //    return View();
            //}
            return View();
        }

    }
}
