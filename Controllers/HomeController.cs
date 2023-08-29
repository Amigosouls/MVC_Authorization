using MVC_Authorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Authorization.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly MVCEntities db = new MVCEntities();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserRole user)
        {
            if(ModelState.IsValid)
            {
                bool isValid = false;
                if(db.UserRoles.Any(use=>use.user_email.ToLower()==user.user_email.ToLower()&&user.user_pass==use.user_pass))
                {
                    isValid = true;
                }
                else
                {
                    ViewBag.Msg = "User email or password Is Incorrect";
                }
                if(isValid)
                {
                    
                    FormsAuthentication.SetAuthCookie(user.user_name, false);
                    return RedirectToAction("Index", "Employee");
                }
            }
            ModelState.AddModelError("", "Invalid Username or Password");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRole Userreg)
        {
            if (ModelState.IsValid)
            {
                db.UserRoles.Add(Userreg);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }
        
        public ActionResult Index()
        {
            return View();
        }
     
        public ActionResult Register()
        {
            return View();
        }

    }
}