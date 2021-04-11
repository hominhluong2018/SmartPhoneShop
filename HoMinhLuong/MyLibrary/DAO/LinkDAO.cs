using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model;

namespace MyLibrary.DAO
{
    public class LinkDAO
    {
        private SmartPhoneDBContext db = new SmartPhoneDBContext();
        //List Object
        public List<Link> getList()
        {
            var list = db.Links
                .ToList();
            return list;

        }
        // Trả về số lượng
        public long getCount()
        {
            var count = db.Links.Count();
            return count;
        }
        //Trả về 1 mẫu tin 
        public Link getRow(String slug)
        {
            var row = db.Links.Where(m => m.Slug == slug).FirstOrDefault();
            return row;

        }
        //Thêm
        public void getInsert(Link row)
        {
            db.Links.Add(row);
            db.SaveChanges();

        }
        //Sửa
        public void getUpdate(Link row)
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();
        }
        //Xóa
        public void getDelete(Link row)
        {
            db.Links.Remove(row);
            db.SaveChanges();
        }
    }
}

