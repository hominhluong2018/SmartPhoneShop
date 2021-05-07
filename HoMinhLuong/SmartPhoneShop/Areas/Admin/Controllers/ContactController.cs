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
    public class ContactController : BaseController
    {
        ContactDAO _contactDAO = new ContactDAO();

        // GET: Admin/Contact
        public ActionResult Index()
        {
            var list = _contactDAO.getList("Index");

            return View(list);
        }
        public ActionResult Trash()
        {
            return View(_contactDAO.getList("Trash"));
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = _contactDAO.getRow(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(_contactDAO.getList("Index"), "Id", "Name", 0);
            ViewBag.ListCatOder = new SelectList(_contactDAO.getList("Index"), "Order", "Name", 0);
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.CreatedDate = DateTime.Now;
                contact.CreatedBy = int.Parse(Session["UserId"].ToString());
                contact.UpdatedDate = DateTime.Now;
                contact.UpdatedBy = int.Parse(Session["UserId"].ToString());
                _contactDAO.getInsert(contact);
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(_contactDAO.getList("Index"), "Id", "Name", 0);
            ViewBag.ListCatOder = new SelectList(_contactDAO.getList("Index"), "Order", "Name", 0);

            return View(contact);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = _contactDAO.getRow(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactDAO.getUpdate(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
                return RedirectToAction("Index");
            }
            Contact contact = _contactDAO.getRow(id);
            if (contact == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            _contactDAO.Delete(id);
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
            Contact contact = _contactDAO.getRow(id);
            if (contact == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            contact.Status = (contact.Status == 1) ? 2 : 1;
            contact.UpdatedDate = DateTime.Now;
            contact.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _contactDAO.getUpdate(contact);
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
            Contact contact = _contactDAO.getRow(id);
            if (contact == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            contact.Status = 0;
            contact.UpdatedDate = DateTime.Now;
            contact.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _contactDAO.getUpdate(contact);
            TempData["XMessage"] = new MyMessage("Xóa vào thùng rác thành công", "success");
            return RedirectToAction("Index");
        }
        public ActionResult Retrash(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
            }
            Contact contact = _contactDAO.getRow(id);
            if (contact == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            contact.Status = 2;
            contact.UpdatedDate = DateTime.Now;
            contact.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _contactDAO.getUpdate(contact);
            TempData["XMessage"] = new MyMessage("Khôi phục mẫu tin thành công thành công", "success");
            return RedirectToAction("Index");
        }
    }
}
