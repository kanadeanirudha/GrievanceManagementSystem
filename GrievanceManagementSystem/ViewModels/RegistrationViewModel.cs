using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrievanceManagementSystem.ViewModels
{
    public class RegistrationViewModel: BaseViewModel
    {
        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [MaxLength(100, ErrorMessage = "Email Address can not exceed 100 characters.")]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ReTypePassword { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [MaxLength(50, ErrorMessage = "First Name can not exceed 50 characters.")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string EnrollmentNumber { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public int DepartmentID { get; set; }
    }
}