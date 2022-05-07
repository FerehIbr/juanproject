using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace juanproject.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(255)]
        public string FullName { get; set; }
    }
}
