using MyLibrary.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyLibrary.DAO
{
    public class OrderDAO
    {
        private SmartPhoneDBContext db = new SmartPhoneDBContext();
        //List Object
        //public List<Order> getList()
        //{
        //    var list = db.Orders.ToList();
        //    return list;
        //}
        // Trả về số lượng

        public List<Order> getList(string page = "Index")
        {
            if (page == "Index")
            {
                var list = db.Orders
                .Where(m => m.Status != 0)
                .OrderBy(m => m.CreatedDate)
                .ToList();
                return list;
            }
            else
            {
                var list = db.Orders
                .Where(m => m.Status == 0)
                .OrderBy(m => m.CreatedDate)
                .ToList();
                return list;
            }
        }
        public long getCount()
        {
            var count = db.Orders.Count();
            return count;
        }
        //Trả về 1 mẫu tin 
        public Order getRow(string Ordername)
        {
            var row = db.Orders
                .Where(m => m.Status == 1)
                .FirstOrDefault();
            return row;
        }
        public Order getRow(int? id)
        {
            var row = db.Orders.Find(id);
            return row;

        }
        //Thêm
        public void getInsert(Order row)
        {
            db.Orders.Add(row);
            db.SaveChanges();

        }
        //Sửa
        public void getUpdate(Order row)
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();
        }
        //Xóa
        public void getDelete(Order row)
        {
            db.Orders.Remove(row);
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
