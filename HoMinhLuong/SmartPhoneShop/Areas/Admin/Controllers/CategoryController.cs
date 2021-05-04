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
    public class CategoryController : BaseController
    {
        CategoryDAO _catDAO = new CategoryDAO();

        // GET: Admin/Category
        public ActionResult Index()
        {
            var list = _catDAO.getList("Index");

            return View(list);
        }
      public ActionResult Trash()
        {
            return View(_catDAO.getList("Trash"));
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _catDAO.getRow(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(_catDAO.getList("Index"), "Id", "Name", 0);
            ViewBag.ListCatOder = new SelectList(_catDAO.getList("Index"), "Order", "Name", 0);
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.CreatedDate = DateTime.Now;
                category.CreatedBy = int.Parse(Session["UserId"].ToString());
                category.UpdatedDate = DateTime.Now;
                category.UpdatedBy = int.Parse(Session["UserId"].ToString());
                _catDAO.getInsert(category);
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(_catDAO.getList("Index"), "Id", "Name", 0);
            ViewBag.ListCatOder = new SelectList(_catDAO.getList("Index"), "Order", "Name", 0);

            return View(category);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _catDAO.getRow(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Category category)
        {
            if (ModelState.IsValid)
            {
                _catDAO.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
                return RedirectToAction("Index");
            }
            Category category = _catDAO.getRow(id);
            if (category == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            _catDAO.Delete(id);
            TempData["XMessage"] = new MyMessage("Thay đổi trạng thái thành công", "success");
            return RedirectToAction("Trash");
        }

        //// POST: Admin/Category/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Category category = _catDAO.getRow(id);
        //     _catDAO.getDelete(category);
        //    return RedirectToAction("Index");
        //}

        //Trang thai
        public ActionResult Status(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
            }
            Category category = _catDAO.getRow(id);
            if (category == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            category.Status = (category.Status == 1) ? 2 : 1;
            category.UpdatedDate = DateTime.Now;
            category.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _catDAO.Update(category);
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
            Category category = _catDAO.getRow(id);
            if (category == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            category.Status = 0;
            category.UpdatedDate = DateTime.Now;
            category.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _catDAO.Update(category);
            TempData["XMessage"] = new MyMessage("Xóa vào thùng rác thành công", "success");
            return RedirectToAction("Index");
        }
        public ActionResult Retrash(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
            }
            Category category = _catDAO.getRow(id);
            if (category == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            category.Status = 2;
            category.UpdatedDate = DateTime.Now;
            category.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _catDAO.Update(category);
            TempData["XMessage"] = new MyMessage("Khôi phục mẫu tin thành công thành công", "success");
            return RedirectToAction("Index");
        }
    }
}
