using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model;

namespace MyLibrary.DAO
{
    public class ProductDAO
    {
        private SmartPhoneDBContext db = new SmartPhoneDBContext();
        //Trả về 1 mẫu tin 
        public Product getRow(String slug)
        {
            var row = db.Products.Where(m => m.Slug == slug && m.Status == 1).FirstOrDefault();
            
            return row;
        }

        public List<Product> GetList(List<int> listcatid, int limit)
        {
            var list = db.Products
                .Where(m =>m.Status == 1 && listcatid.Contains(m.CatId))
                .OrderByDescending(m => m.CreatedDate)
                .Take(limit)
                .ToList();

            return list;

        }
        public List<Product> GetList(List<int> listcatid, int limit, int skip)
        {
            var list = db.Products
                .Where(m => m.Status == 1 && listcatid.Contains(m.CatId))
                .OrderByDescending(m=>m.CreatedDate)
                .Take(limit)
                .Skip(skip)
                .ToList();
            

            return list;

        }
    }
}
