using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Product
    {
       
        [Key]
        [Required]
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Product name must not be null")]
        [StringLength(maximumLength:40)]
        public string ProductName { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        public int ProductPrice { get; set; }

        [StringLength(150)]
        public string Image { get; set; }


        public ProductDetail Detail { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public List<BillDetail> BillDetails { get; set; }

    }
}
