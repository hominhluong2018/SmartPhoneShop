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
    public class MenuController : BaseController
    {
        MenuDAO _menuDAO = new MenuDAO();

        // GET: Admin/Category
        public ActionResult Index()
        {
            var list = _menuDAO.getList("Index");

            return View(list);
        }
        public ActionResult Trash()
        {
            return View(_menuDAO.getList("Trash"));
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = _menuDAO.getRow(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(_menuDAO.getList("Index"), "Id", "Name", 0);
            ViewBag.ListCatOder = new SelectList(_menuDAO.getList("Index"), "Order", "Name", 0);
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Menu menu)
        {
            if (ModelState.IsValid)
            {
                menu.CreatedDate = DateTime.Now;
                menu.CreatedBy = int.Parse(Session["UserId"].ToString());
                menu.UpdatedDate = DateTime.Now;
                menu.UpdatedBy = int.Parse(Session["UserId"].ToString());
                _menuDAO.getInsert(menu);
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(_menuDAO.getList("Index"), "Id", "Name", 0);
            ViewBag.ListCatOder = new SelectList(_menuDAO.getList("Index"), "Order", "Name", 0);

            return View(menu);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = _menuDAO.getRow(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Menu menu)
        {
            if (ModelState.IsValid)
            {
                _menuDAO.getUpdate(menu);
                return RedirectToAction("Index");
            }
            return View(menu);
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
                return RedirectToAction("Index");
            }
            Menu menu = _menuDAO.getRow(id);
            if (menu == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            _menuDAO.Delete(id);
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
            Menu menu = _menuDAO.getRow(id);
            if (menu == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            menu.Status = (menu.Status == 1) ? 2 : 1;
            menu.UpdatedDate = DateTime.Now;
            menu.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _menuDAO.getUpdate(menu);
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
            Menu menu = _menuDAO.getRow(id);
            if (menu == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            menu.Status = 0;
            menu.UpdatedDate = DateTime.Now;
            menu.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _menuDAO.getUpdate(menu);
            TempData["XMessage"] = new MyMessage("Xóa vào thùng rác thành công", "success");
            return RedirectToAction("Index");
        }
        public ActionResult Retrash(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
            }
            Menu menu = _menuDAO.getRow(id);
            if (menu == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            menu.Status = 2;
            menu.UpdatedDate = DateTime.Now;
            menu.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _menuDAO.getUpdate(menu);
            TempData["XMessage"] = new MyMessage("Khôi phục mẫu tin thành công thành công", "success");
            return RedirectToAction("Index");
        }
    }
}
