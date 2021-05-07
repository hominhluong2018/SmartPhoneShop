using MyLibrary.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyLibrary.DAO
{
    public class ContactDAO
    {
        private SmartPhoneDBContext db = new SmartPhoneDBContext();
        //List Object
        //public List<Contact> getList()
        //{
        //    var list = db.Contacts.ToList();
        //    return list;
        //}
        // Trả về số lượng

        public List<Contact> getList(string page = "Index")
        {
            if (page == "Index")
            {
                var list = db.Contacts
                .Where(m => m.Status != 0)
                .OrderBy(m => m.CreatedDate)
                .ToList();
                return list;
            }
            else
            {
                var list = db.Contacts
                .Where(m => m.Status == 0)
                .OrderBy(m => m.CreatedDate)
                .ToList();
                return list;
            }
        }
        public long getCount()
        {
            var count = db.Contacts.Count();
            return count;
        }
        //Trả về 1 mẫu tin 
        public Contact getRow(string Contactname)
        {
            var row = db.Contacts
                .Where(m => m.Status == 1)
                .FirstOrDefault();
            return row;
        }
        public Contact getRow(int? id)
        {
            var row = db.Contacts.Find(id);
            return row;

        }
        //Thêm
        public void getInsert(Contact row)
        {
            db.Contacts.Add(row);
            db.SaveChanges();

        }
        //Sửa
        public void getUpdate(Contact row)
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();
        }
        //Xóa
        public void getDelete(Contact row)
        {
            db.Contacts.Remove(row);
            db.SaveChanges();
        }

        public void Delete(int? id)
        {
            var contact = db.Contacts.Where(m => m.Id == id).FirstOrDefault();
            db.Contacts.Remove(contact);
            db.SaveChanges();
        }
    }
}
