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
    public class UserController : BaseController
    {
        UserDAO _userDAO = new UserDAO();

        // GET: Admin/Category
        public ActionResult Index()
        {
            var list = _userDAO.getList("Index");

            return View(list);
        }
        public ActionResult Trash()
        {
            return View(_userDAO.getList("Trash"));
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userDAO.getRow(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(_userDAO.getList("Index"), "Id", "Name", 0);
            //ViewBag.ListCatOder = new SelectList(_userDAO.getList("Index"), "Order", "Name", 0);
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.CreatedDate = DateTime.Now;
                user.CreatedBy = int.Parse(Session["UserId"].ToString());
                user.UpdatedDate = DateTime.Now;
                user.UpdatedBy = int.Parse(Session["UserId"].ToString());
                _userDAO.getInsert(user);
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(_userDAO.getList("Index"), "Id", "Name", 0);
            ViewBag.ListCatOder = new SelectList(_userDAO.getList("Index"), "Order", "Name", 0);

            return View(user);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userDAO.getRow(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _userDAO.getUpdate(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
                return RedirectToAction("Index");
            }
            User user = _userDAO.getRow(id);
            if (user == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            _userDAO.Delete(id);
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
            User user = _userDAO.getRow(id);
            if (user == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            user.Status = (user.Status == 1) ? 2 : 1;
            user.CreatedDate = DateTime.Now;
            user.CreatedBy = int.Parse(Session["UserId"].ToString());
            user.UpdatedDate = DateTime.Now;
            user.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _userDAO.getUpdate(user);
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
            User user = _userDAO.getRow(id);
            if (user == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            user.Status = 0;
            user.UpdatedDate = DateTime.Now;
            user.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _userDAO.getUpdate(user);
            TempData["XMessage"] = new MyMessage("Xóa vào thùng rác thành công", "success");
            return RedirectToAction("Index");
        }
        public ActionResult Retrash(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
            }
            User user = _userDAO.getRow(id);
            if (user == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            user.Status = 2;
            user.UpdatedDate = DateTime.Now;
            user.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _userDAO.getUpdate(user);
            TempData["XMessage"] = new MyMessage("Khôi phục mẫu tin thành công thành công", "success");
            return RedirectToAction("Index");
        }
    }
}
