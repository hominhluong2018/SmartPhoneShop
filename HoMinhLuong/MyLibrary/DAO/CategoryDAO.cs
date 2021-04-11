using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model;

namespace MyLibrary.DAO
{
    public class CategoryDAO
    {
        private SmartPhoneDBContext db = new SmartPhoneDBContext();
        //List Object
        public List<Category> getList()
        {
            var list = db.Categorys.ToList();
            return list;

        }
        // Trả về số lượng
        public long getCount()
        {
            var count = db.Categorys.Count();
            return count;
        }
        //Trả về mẫu tin Object
        public Category getRow(int? id)
        {
            var row = db.Categorys.Find(id);
            return row;

        }
        public Category getRow(String slug)
        {
            var row = db.Categorys.Where(m => m.Slug == slug).FirstOrDefault();
            return row;

        }
        //Thêm
        public void getInsert(Category row)
        {
            db.Categorys.Add(row);
            db.SaveChanges();

        }
        //Sửa
        public void getUpdate(Category row)
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();
        }
        //Xóa
        public void getDelete(Category row)
        {
            db.Categorys.Remove(row);
            db.SaveChanges();
        }
    }
}
