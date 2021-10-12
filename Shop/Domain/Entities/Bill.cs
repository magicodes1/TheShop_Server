using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Bill
    {
        [Key]
        [Required]
        public int BillId { get; set; }
        public int PhoneNumber { get; set; }
        [Required]
        [StringLength(80)]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        public DateTime DayOfBillExport { get; set; }

        [Range(0,int.MaxValue)]
        public int TotalPrice { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public List<BillDetail> BillDetails { get; set; }
    }
}
