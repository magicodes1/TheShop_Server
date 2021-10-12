using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Brand
    {
        [Key]
        [Required]
        public int BrandId { get; set; }
        [Required(ErrorMessage ="Brand name must not be null")]
        [StringLength(10)]
        public string BrandName { get; set; }

        public List<Product> Products { get; set; }
        public List<CategoryBrand> CategoryBrands { get; set; }
    }
}
