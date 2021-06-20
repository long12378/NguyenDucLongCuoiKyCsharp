using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
using ModelEF.Model;

namespace CuoiKyCSharp.Areas.AdminPage.Controllers
{
    public class ProductController : Controller
    {
        // GET: AdminPage/Product
        public ActionResult Index(string searchstring, int page = 1, int pageSize = 5)
        {
            var dao = new ProductDao();
            var model = dao.listpro();
            return View(model);
        }
        public void setviewbag(int? selectedid = null)
        {
            var dao = new ProductDao();
            ViewBag.CategoryID = new SelectList(dao.getcategory(), "ID", "Name", selectedid);
        }

        public ActionResult create(Product pro, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string picname = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Assets/Admin/image"), picname);
                file.SaveAs(path);
                pro.Image = picname;
                var dao  = new ProductDao();
                long id = dao.insert(pro);
                if (id > 0)
                {
                    return RedirectToAction("create", "User");
                }
                else
                {
                    ModelState.AddModelError("", "them san pham thanh cong");
                }
            }
            setviewbag(pro.CategoryID);
            return View("create");
        }
        public ActionResult detail(int id)
        {
            var model = new ProductDao().listwhere(id);
            return View(model);
        }
    }
}