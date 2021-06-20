using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace ModelEF.DAO
{
    public class ProductDao
    {
        private NguyenDucLong_Context db;
        public ProductDao()
        {
            db = new NguyenDucLong_Context();
        }
        public List<Category> getcategory()
        {
            return db.Categories.ToList();
        }
        public long insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public IEnumerable<Product> ListAllPaging(string searchstring, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchstring))
            {
                model = model.Where(x => x.Name.Contains(searchstring));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public List<Product> listwhere(int id)
        {
            return db.Products.Where(x => x.ID == id).ToList();
        }
        public List<Product> listpro()
        {
            return db.Products.Where(x => x.Status == false).OrderBy(x => x.Quantity).ThenByDescending(x => x.UnitCost).ToList();
        }
    }
}
