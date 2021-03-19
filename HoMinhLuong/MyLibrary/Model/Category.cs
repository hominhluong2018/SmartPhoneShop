using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Model
{
    class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Slug { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        //public string Matekey { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        //public int? Static { get; set; }
    }
}
