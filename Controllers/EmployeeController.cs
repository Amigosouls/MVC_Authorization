using MVC_Authorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Authorization.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: Employee
        MVCEntities db = new MVCEntities();
        public ActionResult Index()
        {
            List<Trainee> trainees = db.Trainees.ToList();
            return View(trainees);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Home");
        }
    }
}