using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Model;
using PagedList;

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
        public Product getRow(int? id)
        {
            var row = db.Products.Find(id);
            return row;

        }

        public void getInsert(Product row)
        {
            db.Products.Add(row);
            db.SaveChanges();

        }

        public void Update(Product row)
        {
            db.Entry(row).State = EntityState.Modified;
            db.SaveChanges();
        }
        //Xóa
        public void getDelete(Product row)
        {
            db.Products.Remove(row);
            db.SaveChanges();
        }

        public void Delete(int? id)
        {
            var product = db.Products.Where(m => m.Id == id).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
        }


        //phan trang
        public PagedList.IPagedList<Product> GetList(int pageSize, int pageNumber)
        {
            var list = db.Products
                .Where(m => m.Status == 1)
                .OrderByDescending(m => m.CreatedDate)
                .ToPagedList(pageNumber, pageSize);

            return list;

        }
        public List<Product> GetList(List<int> listcatid, int limit)
        {
            var list = db.Products
                .Where(m => m.Status == 1 && listcatid.Contains(m.CatId))
                .OrderByDescending(m => m.CreatedDate)
                .Take(limit)
                .ToList();

            return list;

        }
        public List<Product> GetList(string page = "Index")
        {
            if (page == "Index")
            {
                var list = db.Products
                .Where(m => m.Status != 0)
                .OrderBy(m => m.CreatedDate)
                .ToList();
                return list;
            }
            else
            {
                var list = db.Products
                .Where(m => m.Status == 0)
                .OrderBy(m => m.CreatedDate)
                .ToList();
                return list;
            }
        }

        public List<Product> GetList(List<int> listcatid, int limit, int notid, bool check = true)
        {
            var list = db.Products
                .Where(m => m.Status == 1 && m.Id != notid && listcatid.Contains(m.CatId))
                .OrderByDescending(m => m.CreatedDate)
                .Take(limit)
                .ToList();

            return list;

        }

        public PagedList.IPagedList<Product> GetList(List<int> listcatid, int pageNumber, int pageSize)
        {
            var list = db.Products
                .Where(m => m.Status == 1 && listcatid.Contains(m.CatId))
                .OrderByDescending(m => m.CreatedDate)
                .ToPagedList(pageNumber, pageSize);

            return list;
        }

        public List<Product> GetAllProduct(/*int pageSize, int pageNumber,*/int limit, int skip)
        {
            var list = db.Products
                .Where(m => m.Status == 1)
                .OrderByDescending(m => m.CreatedDate)
                .Take(limit)
                .Skip(skip)
                .ToList();

            return list;
        }
    }
}
