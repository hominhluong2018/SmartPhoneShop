using MyLibrary.DAO;
using MyLibrary.Model;
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
            return View();
        }

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.CreatedDate = DateTime.Now;
                contact.UpdatedDate = DateTime.Now;
                _contactDAO.getInsert(contact);
                var successMsg = "Nội dung của bạn đã gửi tới admin";
                ViewBag.StrError = "<div class='text-danger'>" + successMsg + "</div>";
            }

            return RedirectToAction("Index");
        }
    }
}