using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
using ModelEF.Model;

namespace CuoiKyCSharp.Areas.AdminPage.Controllers
{
    public class CategoryController : Controller
    {
        // GET: AdminPage/Category
        public ActionResult Index(string searchstring, int page = 1, int pageSize = 5)
        {
            var dao = new CategoryDao();
            var model = dao.ListAllPaging(searchstring, page, pageSize);
            ViewBag.searchstring = searchstring;
            return View(model);
        }
        public ActionResult create(Category cat)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                long id = dao.insert(cat);
                if (id > 0)
                {
                    return RedirectToAction("create", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "them category thanh cong");
                }
            }
            return View("create");
        }
        public ActionResult edit(int id)
        {
            var cat = new CategoryDao().viewdetail(id);
            return View(cat);
        }
        [HttpPost]
        public ActionResult edit(Category cat)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                var result = dao.update(cat);
                if (result)
                {
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "cap nhat category thanh cong");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult delete(int id)
        {
            new CategoryDao().delete(id);
            return RedirectToAction("Index");
        }
    }
}