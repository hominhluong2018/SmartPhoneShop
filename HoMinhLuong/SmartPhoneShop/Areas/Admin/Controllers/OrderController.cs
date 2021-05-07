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
    public class OrderController : BaseController
    {
        OrderDAO _orderDAO = new OrderDAO();

        // GET: Admin/Category
        public ActionResult Index()
        {
            var list = _orderDAO.getList("Index");

            return View(list);
        }
        public ActionResult Trash()
        {
            return View(_orderDAO.getList("Trash"));
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = _orderDAO.getRow(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(_orderDAO.getList("Index"), "Id", "Name", 0);
            ViewBag.ListCatOder = new SelectList(_orderDAO.getList("Index"), "Order", "Name", 0);
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                order.CreatedDate = DateTime.Now;
                order.CreatedBy = int.Parse(Session["UserId"].ToString());
                order.UpdatedDate = DateTime.Now;
                order.UpdatedBy = int.Parse(Session["UserId"].ToString());
                _orderDAO.getInsert(order);
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(_orderDAO.getList("Index"), "Id", "Name", 0);
            ViewBag.ListCatOder = new SelectList(_orderDAO.getList("Index"), "Order", "Name", 0);

            return View(order);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = _orderDAO.getRow(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                _orderDAO.getUpdate(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
                return RedirectToAction("Index");
            }
            Order order = _orderDAO.getRow(id);
            if (order == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            _orderDAO.Delete(id);
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
            Order order = _orderDAO.getRow(id);
            if (order == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            order.Status = (order.Status == 1) ? 2 : 1;
            order.UpdatedDate = DateTime.Now;
            order.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _orderDAO.getUpdate(order);
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
            Order order = _orderDAO.getRow(id);
            if (order == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            order.Status = 0;
            order.UpdatedDate = DateTime.Now;
            order.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _orderDAO.getUpdate(order);
            TempData["XMessage"] = new MyMessage("Xóa vào thùng rác thành công", "success");
            return RedirectToAction("Index");
        }
        public ActionResult Retrash(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
            }
            Order order = _orderDAO.getRow(id);
            if (order == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            order.Status = 2;
            order.UpdatedDate = DateTime.Now;
            order.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _orderDAO.getUpdate(order);
            TempData["XMessage"] = new MyMessage("Khôi phục mẫu tin thành công thành công", "success");
            return RedirectToAction("Index");
        }
    }
}
