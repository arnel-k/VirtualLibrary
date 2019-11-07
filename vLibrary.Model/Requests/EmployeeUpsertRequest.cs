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
        public DateTime? BirthDate { get; set; }
        [Required(ErrorMessage = "Gender is required!")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "AddressGuid is required!")]
        public Guid AddressDtoGuid { get; set; }
        
        [Required(ErrorMessage = "Library is required!")]
        public Guid LibraryDtoGuid { get; set; }

        [Required(ErrorMessage = "Account is required!")]
        public Guid AccountDtoGuid { get; set; }
    }
}
