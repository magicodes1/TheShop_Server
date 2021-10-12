using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Resources
{
    public class BillResource
    {
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DayOfBillExport { get; set; }
        [Required]
        public int TotalPrice { get; set; }
        [Required]
        public string UserId { get; set; }

        public List<BillDetailResource> billDetailResources { get; set; }
    }

    public class BillDetailResource
    {
        
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }
    }

    public class AddToCartResource
    {
        [Required]
        public BillResource Bill { get; set; }
        [Required]
        public List<BillDetailResource> BillDetail { get; set; }
    }
}
