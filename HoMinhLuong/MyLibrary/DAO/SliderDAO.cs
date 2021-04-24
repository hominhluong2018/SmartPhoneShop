using MyLibrary.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyLibrary.DAO
{
    public class SliderDAO
    {
        private SmartPhoneDBContext db = new SmartPhoneDBContext();
        //List Object
        public List<Slider> getList(string position)
        {
            var list = db.Sliders
                .Where(m=> m.Position == position && m.Status == 1) 
                .ToList();
            return list;

        }
        // Trả về số lượng
        public long getCount()
        {
            var count = db.Sliders.Count();
            return count;
        }
        //Trả về 1 mẫu tin 
        public Slider getRow(int? id)
        {
            var row = db.Sliders
                .Find(id);
            return row;
        }
        //Thêm
        public void getInsert(Slider row)
        {
            db.Sliders.Add(row);
            db.SaveChanges();

        }
        //Sửa
        public void getUpdate(Slider row)
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();
        }
        //Xóa
        public void getDelete(Slider row)
        {
            db.Sliders.Remove(row);
            db.SaveChanges();
        }
    }
}
