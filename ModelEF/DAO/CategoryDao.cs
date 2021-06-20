using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagedList;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDao
    {
        private NguyenDucLong_Context db;
        public CategoryDao()
        {
            db = new NguyenDucLong_Context();
        }
        public bool delete(int id)
        {
            try
            {
                var user = db.Categories.Find(id);
                db.Categories.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public long insert(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public Category getbyid(string catname)
        {
            return db.Categories.SingleOrDefault(s => s.Name == catname);
        }
        public IEnumerable<Category> ListAllPaging(string searchstring, int page, int pageSize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(searchstring))
            {
                model = model.Where(x => x.Name.Contains(searchstring));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public Category viewdetail(int id)
        {
            return db.Categories.Find(id);
        }
        public Boolean update(Category entity)
        {
            try
            {
                var cat = db.Categories.Find(entity.ID);
                cat.Name = entity.Name;
                cat.Decription = entity.Decription;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
