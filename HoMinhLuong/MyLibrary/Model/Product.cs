using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyLibrary.Model
{
    [Table("Products")]
    public class Product
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public int CatId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Img { get; set; }
        [Required]
        public string Detail { get; set; }
        public int Number { get; set; }
        public float Price { get; set; }
        public float PriceSale { get; set; }
        [Required]
        public string MetaKey { get; set; }
        public string MetaDesc { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
    }
}
