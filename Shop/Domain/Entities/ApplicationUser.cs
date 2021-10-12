using Microsoft.AspNetCore.Identity;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public List<Bill> Bills { get; set; }
    }
}
