using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using vLibrary.Model.Enums;

namespace vLibrary.Model.Requests
{
    public class EmployeeUpsertRequest
    {
        public Guid Guid { get; set; }
        [Required(ErrorMessage = "First name is required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required!")]
        public string LastName { get; set; }
        public byte[] Picture { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required!")]
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Gender is required!")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Street name is required!")]
        public string Street { get; set; }
        [Required(ErrorMessage = "City name is required!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Zip Code is required!")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Username is required!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "User Role is required!")]
        public Role Role { get; set; }
        [Required(ErrorMessage = "Account status is required!")]
        public AccountStatus AccountStatus { get; set; }

    }
}
