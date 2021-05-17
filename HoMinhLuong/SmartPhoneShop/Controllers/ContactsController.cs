using MyLibrary.DAO;
using MyLibrary.Model;
using SmartPhoneShop.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneShop.Controllers
{
    public class ContactsController : Controller
    {
        ContactDAO _contactDAO = new ContactDAO();

        // GET: Contact
        public ActionResult Index()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            contact.CreatedDate = DateTime.Now;
            contact.UpdatedDate = DateTime.Now;
            _contactDAO.getInsert(contact);
            var successMsg = "Nội dung của bạn đã gửi tới admin";
            TempData["XMessage"] = new MyMessage(successMsg, "success");


            return RedirectToAction("Index");
        }
    }
}