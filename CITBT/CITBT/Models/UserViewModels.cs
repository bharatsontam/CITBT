using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CITBT.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }
    }

    public class UserDetailsViewModel : UserViewModel
    {
        public UserDetailsViewModel()
        {
            this.SelectedRoles = new List<string>();
        }
        [Required]
        [Display(Name = "Roles")]
        public IList<string> SelectedRoles { get; set; }
    }

    public class EditUserDetailsViewModel : UserDetailsViewModel
    {
        public EditUserDetailsViewModel()
        {
            this.AvailableRoles = new List<string> { "Admin", "User", "EventOrganizer", "Tester" };
        }
        [Display(Name = "Available Roles")]
        public IList<string> AvailableRoles { get; set; }
    }

    public class CreateUserViewModel : EditUserDetailsViewModel
    {
        public CreateUserViewModel()
        {
            this.SelectedRoles = new List<string>();
        }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password must match with password")]
        public string ConfirmPassword { get; set; }
    }
}