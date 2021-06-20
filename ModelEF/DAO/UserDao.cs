using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace ModelEF.DAO
{
    
    public class UserDao
    {
        private NguyenDucLong_Context db;
        public UserDao() {
            db = new NguyenDucLong_Context();
        }
        public int login(string user, string pass) {
            var result = db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(user) && x.Password.Contains(pass));
            if (result == null)
            {
                return 0;
            }
            else {
                return 1;
            }
        }
        public Boolean update(UserAccount entity) {
            try {
                var user = db.UserAccounts.Find(entity.ID);
                user.UserName = entity.UserName;
                user.Password = entity.Password;
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public long insert(UserAccount entity) {
            db.UserAccounts.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public UserAccount getbyid(string username)
        {
            return db.UserAccounts.SingleOrDefault(s => s.UserName == username);
        }
        public UserAccount viewdetail(int id) {
            return db.UserAccounts.Find(id);
        }
        public IEnumerable<UserAccount> ListAllPaging(string searchstring,int page, int pageSize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(searchstring))
            {
                model = model.Where(x => x.UserName.Contains(searchstring));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public bool delete(int id) {
            try
            {
                var user = db.UserAccounts.Find(id);
                db.UserAccounts.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }
    }
}