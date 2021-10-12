using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class BillDetail
    {
        [Required]
        public int BillId { get; set; }
        public Bill Bill { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }


        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }

        
        
    }
}
