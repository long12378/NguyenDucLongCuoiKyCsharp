using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
using ModelEF.Model;

namespace CuoiKyCSharp.Areas.AdminPage.Controllers
{
    public class UserController : Controller
    {
        // GET: AdminPage/User
        public ActionResult Index(string searchstring, int page = 1, int pageSize = 5)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchstring, page, pageSize);
            ViewBag.searchstring = searchstring;
            return View(model);
        }
        public ActionResult edit(int id)
        {
            var user = new UserDao().viewdetail(id);
            return View(user);
        }
        public ActionResult create(UserAccount user)
        {
            if (ModelState.IsValid) {
                var dao = new UserDao();
                long id = dao.insert(user);
                if(id > 0)
                {
                    return RedirectToAction("create", "User");
                }
                else
                {
                    ModelState.AddModelError("", "them user thanh cong");
                }
            }
            return View("create");
        }
        [HttpPost]
        public ActionResult edit(UserAccount user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result= dao.update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "cap nhat user thanh cong");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult delete(int id) {
            new UserDao().delete(id);
            return RedirectToAction("Index");
        }
    }
}