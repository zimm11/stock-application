using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockApplication.Models
{
    //[Table("Users")]
    public class AppUser : IdentityUser<int>
    {              
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        //[Required]
        //public string SecurityQuestion1 { get; set; }
        //[Required]
        //public string Answer1 { get; set; }
        //[Required]
        //public string SecurityQuestion2 { get; set; }
        //[Required]
        //public string Answer2 { get; set; }
        //[Required]
        //public string SecurityQuestion3 { get; set; }
        //[Required]
        //public string Answer3 { get; set; }
        public bool Locked { get; set; }
    }

    public class AppRole : IdentityRole<int>
    {
    }
}

