using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model;

namespace MyLibrary.DAO
{
    public class PostDAO
    {
        private SmartPhoneDBContext db = new SmartPhoneDBContext();
        //Trả về 1 mẫu tin 
        public List<Post> getList(int? topid, int limit, int notid)
        {
            var list = db.Posts
                .Where(m => m.TopId == topid && m.Status == 1 && m.Id != notid)
                .OrderByDescending(m=>m.CreatedDate)
                .Take(limit)
                .ToList();
            return list;

        }
        public Post getRow(String slug)
        {
            var row = db.Posts
                .Where(m => m.Slug == slug && m.Status == 1)
                .FirstOrDefault();
            return row;
        }
    }
}
