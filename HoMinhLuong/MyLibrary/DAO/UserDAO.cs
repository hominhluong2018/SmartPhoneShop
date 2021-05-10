using MyLibrary.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyLibrary.DAO
{
    public class UserDAO
    {
        private SmartPhoneDBContext db = new SmartPhoneDBContext();
        //List Object
        //public List<User> getList()
        //{
        //    var list = db.Users.ToList();
        //    return list;
        //}
        // Trả về số lượng

        public List<User> getList(string page = "Index")
        {
            if (page == "Index")
            {
                var list = db.Users
                .Where(m => m.Status != 0)
                .OrderBy(m => m.CreatedDate)
                .ToList();
                return list;
            }
            else
            {
                var list = db.Users
                .Where(m => m.Status == 0)
                .OrderBy(m => m.CreatedDate)
                .ToList();
                return list;
            }
        }
        public long getCount()
        {
            var count = db.Users.Count();
            return count;
        }
        //Trả về 1 mẫu tin 
        public User getRow(string username)
        {
            var row = db.Users
                .Where(m => m.Status == 1 && m.Role==1 && (m.UserName == username||m.Email== username))
                .FirstOrDefault();
            return row;
        }
        public User getRow(int? id)
        {
            var row = db.Users.Find(id);
            return row;

        }
        //Thêm
        public void getInsert(User row)
        {
            db.Users.Add(row);
            db.SaveChanges();

        }
        //Sửa
        public void getUpdate(User row)
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();
        }
        //Xóa
        public void getDelete(User row)
        {
            db.Users.Remove(row);
            db.SaveChanges();
        }

        public void Delete(int? id)
        {
            var menu = db.Menus.Where(m => m.Id == id).FirstOrDefault();
            db.Menus.Remove(menu);
            db.SaveChanges();
        }
    }
}
