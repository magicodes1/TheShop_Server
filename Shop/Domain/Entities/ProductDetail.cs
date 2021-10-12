using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class ProductDetail
    {
        [Key]
        [Required]
        public int DetailId { get; set; }

        [StringLength(100)]
        public string CPU { get; set; }
        [StringLength(100)]
        public string GPU { get; set; }
        [StringLength(5)]
        public string Ram { get; set; }
        [StringLength(10)]
        public string Storage { get; set; }
        [StringLength(10)]
        public string ExternalStorage { get; set; }
        [StringLength(10)]
        public string SimCard { get; set; }
        [StringLength(100)]
        public string Screen { get; set; }
        [StringLength(100)]
        public string MainCamera { get; set; }
        [StringLength(100)]
        public string FrontCamera { get; set; }
        [StringLength(10)]
        public string Battery { get; set; }
        [StringLength(10)]
        public string OS { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
