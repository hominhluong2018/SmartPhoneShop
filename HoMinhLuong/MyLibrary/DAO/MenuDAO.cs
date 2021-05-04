using MyLibrary.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyLibrary.DAO
{
    public class MenuDAO
    {
        private SmartPhoneDBContext db = new SmartPhoneDBContext();
        //List Object
        public List<Menu> GetList(int parentId)
        {
            var list = db.Menus.Where(m => m.ParentId == parentId && m.Status == 1)
                               .OrderBy(m => m.Orders).ToList();
            return list;

        }

        public List<Menu> getList(string page = "Index")
        {
            if (page == "Index")
            {
                var list = db.Menus
                .Where(m => m.Status != 0)
                .OrderBy(m => m.CreatedDate)
                .ToList();
                return list;
            }
            else
            {
                var list = db.Menus
                .Where(m => m.Status == 0)
                .OrderBy(m => m.CreatedDate)
                .ToList();
                return list;
            }


        }
        // Trả về số lượng
        public long getCount()
        {
            var count = db.Menus.Count();
            return count;
        }
        //Trả về mẫu tin Object
        public Menu getRow(int? id)
        {
            var row = db.Menus.Find(id);
            return row;

        }
        //Thêm
        public void getInsert(Menu row)
        {
            db.Menus.Add(row);
            db.SaveChanges();

        }
        //Sửa
        public void getUpdate(Menu row)
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();
        }
        //Xóa
        public void getDelete(Menu row)
        {
            db.Menus.Remove(row);
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
