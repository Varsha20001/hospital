using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace modules.Models
{
    public class User
    {
        [Required]
        public int ID { get; set; }



        [Required(ErrorMessage = "UserName is required")]
        [StringLength(50, ErrorMessage = "UserName cannot be longer than 50 characters")]
        public string UserName { get; set; }



        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "Password cannot be longer than 50 characters")]
        public string Password { get; set; }



        [Range(0, 1, ErrorMessage = "IsActive must be either 0 or 1")]
        public int? IsActive { get; set; }
    }
}