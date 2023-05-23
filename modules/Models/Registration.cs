using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace modules.Models
{
    public class Registration
    {
        [Required]
        public int id { get; set; }



        [Required(ErrorMessage = "UserName is required")]
        [StringLength(20, ErrorMessage = "UserName must be between 2 and 20 characters", MinimumLength = 2)]
        public string UserName { get; set; }



        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "Password must be between 8 and 50 characters", MinimumLength = 8)]
        public string Password { get; set; }



        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }



        [Required(ErrorMessage = "MobileNumber is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "MobileNumber must be a 10-digit number")]
        public string MobileNumber { get; set; }
    }
}