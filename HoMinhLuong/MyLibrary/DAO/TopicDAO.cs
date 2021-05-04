using MyLibrary.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyLibrary.DAO
{
    public class TopicDAO
    {
        private SmartPhoneDBContext db = new SmartPhoneDBContext();
        //List Object
        public List<Topic> getList(string position)
        {
            var list = db.Topics
                .Where(m => m.Status == 1)
                .ToList();
            return list;

        }
        // Trả về số lượng
        public long getCount()
        {
            var count = db.Topics.Count();
            return count;
        }
        //Trả về 1 mẫu tin 
        public Topic getRow(string slug)
        {
            var row = db.Topics
                .Find();
            return row;
        }
        //Thêm
        public void getInsert(Topic row)
        {
            db.Topics.Add(row);
            db.SaveChanges();

        }
        //Sửa
        public void getUpdate(Topic row)
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();
        }
        //Xóa
        public void getDelete(Topic row)
        {
            db.Topics.Remove(row);
            db.SaveChanges();
        }
    }
}
