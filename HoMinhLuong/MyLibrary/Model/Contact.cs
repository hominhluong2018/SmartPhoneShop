using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyLibrary.Model
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập")]
        [RegularExpression(@"^[\p{L}\p{N}]*$", ErrorMessage = "Vui lòng nhập tên hợp lệ")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập")]
        [EmailAddress(ErrorMessage = "Vui lòng nhập email hợp lệ")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập")]
        [Phone(ErrorMessage ="Vui lòng nhập số điện thoại hợp lệ")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập")]
        public string Detail { get; set; }
        public string ReplayDetail { get; set; }
        public int? ReplayID { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Status { get; set; }
    }
}
