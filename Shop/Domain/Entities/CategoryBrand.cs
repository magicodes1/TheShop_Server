using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class CategoryBrand
    {
        [Required]
        public int CategoryId { get; set; }
        
        public Category Category { get; set; }

        [Required]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
