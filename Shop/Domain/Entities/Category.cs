using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Category name must not be null")]
        [StringLength(10)]
        public string CategoryName { get; set; }


        public List<Product> Products { get; set; }
        public List<CategoryBrand> CategoryBrands { get; set; }
    }
}
