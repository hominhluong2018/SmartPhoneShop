using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyLibrary.Model;
using MyLibrary.DAO;
using SmartPhoneShop.Library;

namespace SmartPhoneShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        ProductDAO _productDAO = new ProductDAO();

        // GET: Admin/Product
        public ActionResult Index()
        {
            var list = _productDAO.GetList("Index");

            return View(list);
        }
        public ActionResult Trash()
        {
            return View(_productDAO.GetList("Trash"));
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productDAO.getRow(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(_productDAO.GetList("Index"), "Id", "Name", 0);
            //ViewBag.ListCatOder = new SelectList(_productDAO.GetList("Index"), "Order", "Name", 0);
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.CreatedDate = DateTime.Now;
                product.CreatedBy = int.Parse(Session["UserId"].ToString());
                product.UpdatedDate = DateTime.Now;
                product.UpdatedBy = int.Parse(Session["UserId"].ToString());
                _productDAO.getInsert(product);
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(_productDAO.GetList("Index"), "Id", "Name", 0);
            ViewBag.ListCatOder = new SelectList(_productDAO.GetList("Index"), "Order", "Name", 0);

            return View(product);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productDAO.getRow(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productDAO.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
                return RedirectToAction("Index");
            }
            Product product = _productDAO.getRow(id);
            if (product == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            _productDAO.Delete(id);
            TempData["XMessage"] = new MyMessage("Thay đổi trạng thái thành công", "success");
            return RedirectToAction("Trash");
        }

        //// POST: Admin/Product/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Product Product = _catDAO.getRow(id);
        //     _catDAO.getDelete(Product);
        //    return RedirectToAction("Index");
        //}

        //Trang thai
        public ActionResult Status(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
            }
            Product Product = _productDAO.getRow(id);
            if (Product == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            Product.Status = (Product.Status == 1) ? 2 : 1;
            Product.UpdatedDate = DateTime.Now;
            Product.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _productDAO.Update(Product);
            TempData["XMessage"] = new MyMessage("Thay đổi trạng thái thành công", "success");
            return RedirectToAction("Index");
        }
        //Thùng rác
        public ActionResult Deltrash(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
            }
            Product Product = _productDAO.getRow(id);
            if (Product == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            Product.Status = 0;
            Product.UpdatedDate = DateTime.Now;
            Product.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _productDAO.Update(Product);
            TempData["XMessage"] = new MyMessage("Xóa vào thùng rác thành công", "success");
            return RedirectToAction("Index");
        }
        public ActionResult Retrash(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
            }
            Product Product = _productDAO.getRow(id);
            if (Product == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            Product.Status = 2;
            Product.UpdatedDate = DateTime.Now;
            Product.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _productDAO.Update(Product);
            TempData["XMessage"] = new MyMessage("Khôi phục mẫu tin thành công thành công", "success");
            return RedirectToAction("Index");
        }
    }
}
