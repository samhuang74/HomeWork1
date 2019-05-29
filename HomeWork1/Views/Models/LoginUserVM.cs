using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeWork1.Views.Models
{
    public class LoginUserVM
    {
        [Display(Name = "帳號")]
        [Required]
        public string Id { get; set; }

        [Display(Name = "密碼")]
        [Required]
        public string Pwd { get; set; }

        public string Dep { get; set; }

        public string Email { get; set; }

        public string DisplayName { get; set; }

        public string DisplayEName { get; set; }        
    }
}