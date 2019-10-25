using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MehmetApp.MVCUI.Identity;
using MehmetApp.MVCUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace MehmetApp.MVCUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var userStore =new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager =new UserManager<ApplicationUser>(userStore);

            var roleStore =new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            
            if (ModelState.IsValid)//Gelen modelin kontrolünü yapalım
            {
                var user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;

                IdentityResult result = UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    // Kayıt oluştu ve kullanıcıyı bir role atayabiliriz.

                    if (RoleManager.RoleExists("user")) // Atanacak rol var mı onun kontrolü yapılır.
                    {
                        UserManager.AddToRole(user.Id, "user");

                    }
                    else
                    {
                        ModelState.AddModelError("RegisterUserError","Kullanıcı Oluşturma Hatası");
    
                    }

                    return RedirectToAction("Login", "Account");
                }


            }

            return View(model);
        }




        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model,string ReturnUrl) // ReturnUrl [Authorize] (Controller için) login olduktan sonra otomatik istenen sayfaya yönlendirmek için kullanılır.
        {

            if (ModelState.IsValid)//Gelen modelin kontrolünü yapalım
            {
               // Login işlemleri
            var user = UserManager.Find(model.UserName, model.Password);

            if (user != null)
            {
                // varolan kullanıcıyı sisteme dahil etcez.
                //Application cookie oluşturup sisteme bırak.
                var authManager = HttpContext.GetOwinContext().Authentication;
                // Oluşturulan user cookie içine atıyoruz.
                var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                // Cookie nin kalıcı olup olmadığını belirlemek için;
                var IsPersist = new AuthenticationProperties();
                IsPersist.IsPersistent = model.RememberMe;

                authManager.SignIn(IsPersist,identityclaims);
                // Kullanıcı sisteme dahil edildi.

                if (!String.IsNullOrEmpty(ReturnUrl))
                {
                   return Redirect(ReturnUrl); // Redirect ile "ReturnUrl" kullanılır
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı bulunamadı.");
                }
                

            }

            return View(model);
        }


        // GET: Account 
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index","Home");
        }

    }
}