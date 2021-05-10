using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLibrary.DAO;
using MyLibrary.Model;
using SmartPhoneShop.Library;


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
            User user_row = _userDAO.getRow(user);
            if (user_row != null)
            {
                if (user_row.PassWord == pass)
                {
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
        public ActionResult Regist()
        {
            return View();
        }
    }
}