using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Resources
{

    public class BrandResource
    {
        [Required]
        public int BrandId { get; set; }
        [Required]
        public string BrandName { get; set; }
    }

    public class CategoryResource
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public List<BrandResource> brands { get; set; }
    }
}
