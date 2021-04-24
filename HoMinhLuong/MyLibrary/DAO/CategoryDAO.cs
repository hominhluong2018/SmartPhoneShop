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
        public List<Category> getList(int? parentid=0)
        {
            var list = db.Categorys
                .Where(m=>m.ParentId==parentid && m.Status==1)
                .OrderBy(m=>m.Orders)
                .ToList();
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
        public List<int> getListId(int parentid)
        {
            //Xử lí
            List<int> listcatid = new List<int>();
            List<Category> listcategory1 = this.getList(parentid);
            if (listcategory1.Count > 0)
            {
                foreach (var cat1 in listcategory1)
                {
                    listcatid.Add(cat1.Id);
                    List<Category> listcategory2 = this.getList(cat1.Id);
                    if (listcategory2.Count > 0)
                    {
                        foreach (var cat2 in listcategory2)
                        {
                            listcatid.Add(cat2.Id);
                            List<Category> listcategory3 = this.getList(cat2.Id);
                            if (listcategory3.Count > 0)
                            {
                                foreach (var cat3 in listcategory2)
                                {
                                    listcatid.Add(cat3.Id);
                                }
                            }
                        }
                    }

                }
            }
            listcatid.Add(parentid);

            return listcatid;
        }
    }
}
