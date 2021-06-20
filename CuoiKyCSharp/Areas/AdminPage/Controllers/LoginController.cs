using CuoiKyCSharp.Areas.AdminPage.Models;
using ModelEF.DAO;
using System;
using ModelEF;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuoiKyCSharp.Areas.AdminPage.Controllers
{
    public class LoginController : Controller
    {
        // GET: AdminPage/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel login) {
            if (ModelState.IsValid)
            {
                var user = new UserDao();
                var result = user.login(login.Username, login.password);
                if (result == 1) {
                    //ModelState.AddModelError("", "login successful");
                    Session.Add(contants.USER_SESSION, login.Username);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "login failed ");
                }
            }
            return View("index");
        }
    }
}