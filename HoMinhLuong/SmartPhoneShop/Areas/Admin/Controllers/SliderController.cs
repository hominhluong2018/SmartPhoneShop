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
    public class SliderController : BaseController
    {
        SliderDAO _sliderDAO = new SliderDAO();

        // GET: Admin/Category
        public ActionResult Index()
        {
            var list = _sliderDAO.GetList("Index");

            return View(list);
        }
        public ActionResult Trash()
        {
            return View(_sliderDAO.GetList("Trash"));
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = _sliderDAO.getRow(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            ViewBag.ListCat = new SelectList(_sliderDAO.getList("Index"), "Id", "Name", 0);
            ViewBag.ListCatOder = new SelectList(_sliderDAO.getList("Index"), "Order", "Name", 0);
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slider slider)
        {
            if (ModelState.IsValid)
            {
                slider.CreatedDate = DateTime.Now;
                slider.CreatedBy = int.Parse(Session["UserId"].ToString());
                slider.UpdatedDate = DateTime.Now;
                slider.UpdatedBy = int.Parse(Session["UserId"].ToString());
                _sliderDAO.getInsert(slider);
                return RedirectToAction("Index");
            }
            ViewBag.ListCat = new SelectList(_sliderDAO.getList("Index"), "Id", "Name", 0);
            ViewBag.ListCatOder = new SelectList(_sliderDAO.getList("Index"), "Order", "Name", 0);

            return View(slider);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = _sliderDAO.getRow(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slider slider)
        {
            if (ModelState.IsValid)
            {
                _sliderDAO.getUpdate(slider);
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
                return RedirectToAction("Index");
            }
            Slider slider = _sliderDAO.getRow(id);
            if (slider == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            _sliderDAO.Delete(id);
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
            Slider slider = _sliderDAO.getRow(id);
            if (slider == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            slider.Status = (slider.Status == 1) ? 2 : 1;
            slider.UpdatedDate = DateTime.Now;
            slider.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _sliderDAO.getUpdate(slider);
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
            Slider slider = _sliderDAO.getRow(id);
            if (slider == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            slider.Status = 0;
            slider.UpdatedDate = DateTime.Now;
            slider.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _sliderDAO.getUpdate(slider);
            TempData["XMessage"] = new MyMessage("Xóa vào thùng rác thành công", "success");
            return RedirectToAction("Index");
        }
        public ActionResult Retrash(int? id)
        {
            if (id == null)
            {
                TempData["XMessage"] = new MyMessage("Không có Id", "danger");
            }
            Slider slider = _sliderDAO.getRow(id);
            if (slider == null)
            {
                TempData["XMessage"] = new MyMessage("Mẫu tin không tồn tại", "danger");
            }
            slider.Status = 2;
            slider.UpdatedDate = DateTime.Now;
            slider.UpdatedBy = int.Parse(Session["UserId"].ToString());
            _sliderDAO.getUpdate(slider);
            TempData["XMessage"] = new MyMessage("Khôi phục mẫu tin thành công thành công", "success");
            return RedirectToAction("Index");
        }
    }
}
