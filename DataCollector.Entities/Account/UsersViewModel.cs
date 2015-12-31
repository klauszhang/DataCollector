using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataCollector.Entities
{
    public class CreateUserViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "You must provide an user name. ")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must enter a password.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmedPassword { get; set; }
    }
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "You must provide an user name. ")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class DeleteUserViewModel
    {
        [Display(Name = "User Id")]
        public string Id { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }

    public class SearchUserViewMode
    {
        [Display(Name ="Search User Name")]
        public string UserName { get; set; }
        
    }

    public class DetailUserViewMode
    {
        public int AccessFailedCount { get; set; }
        public bool Deleted { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Id { get; set; }
        public int MyProperty { get; set; }
    }
}