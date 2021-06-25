using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLibrary.DAO;
using MyLibrary.Model;
using SmartPhoneShop.Library;
using SmartPhoneShop.Model;

namespace SmartPhoneShop.Controllers
{
    public class CustomerController : Controller
    {
        UserDAO _userDAO = new UserDAO();
        // GET: Admin/Auth
        public ActionResult Signin()
        {
            ViewBag.StrError = "";
            return View();
        }
        [HttpPost]
        public ActionResult Signin(FormCollection filed)
        {
            string user = filed["username"];
            string pass = MyString.ToMD5(filed["pass"]);
            string error = "";
            //xu li
            var user_row = _userDAO.GetRow(user);
            if (user_row != null)
            {
                if (user_row.PassWord == pass)
                {
                    Session["FullName"] = user_row.FullName;
                    Session["UserAdmin"] = user_row.UserName;
                    Session["UserId"] = user_row.Id.ToString();

                    return RedirectToAction("Index", "Site");
                }
                else
                {
                    error = "Mật khẩu không chính xác";
                }
            }
            else
            {
                error = "Tài khoản không tồn tại";
            }

            ViewBag.StrError = "<div class='text-danger'>" + error + "</div>";
            return View();
        }
        public ActionResult Index()
        {
            return View("Regist");
        }

        [HttpPost]
        public ActionResult Regist(UserRegister vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var user = new User
            {
                UserName= vm.UserName,
                PassWord = MyString.ToMD5(vm.PassWord),
                Phone = vm.Phone,
                Email = vm.Email,
                FullName = vm.FullName,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Role =2,
                Status = 1

            };
            _userDAO.getInsert(user);
            var successMsg = "Bạn đã dăng kí thành công";
            TempData["XMessage"] = new MyMessage(successMsg, "success");

            return RedirectToAction("Index");
        }
        public ActionResult Logout()
        {
            Session["FullName"] = "";
            Session["UserAdmin"] = "";
            Session["UserId"] = "";
            return Redirect("~/");
        }
    }
}