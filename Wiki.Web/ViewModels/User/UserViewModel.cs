using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wiki.Web.ViewModels.User
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Display(Name = "User Email")]
        [Required(ErrorMessage = "User email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "User Password")]
        [Required(ErrorMessage = "User password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}