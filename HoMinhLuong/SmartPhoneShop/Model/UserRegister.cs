using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartPhoneShop.Model
{
    public class UserRegister
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập")]
        //[RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Vui lòng nhập tên hợp lệ")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập")]
        [RegularExpression(@"^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$", ErrorMessage = "Vui lòng nhập tài khoản hợp lệ")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Vui lòng nhập mật khẩu hợp lệ")]
        public string PassWord { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập")]
        [EmailAddress(ErrorMessage = "Vui lòng nhập email hợp lệ")]
        public string Email { get; set; }
        public int Role { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập")]
        [Phone(ErrorMessage = "Vui lòng nhập số điện thoại hợp lệ")]
        public string Phone { get; set; }
    }
}