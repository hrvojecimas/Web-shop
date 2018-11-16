using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage="Password is required")]
        [StringLength(10,MinimumLength=3)]
        public string Password { get; set; }
    }
}