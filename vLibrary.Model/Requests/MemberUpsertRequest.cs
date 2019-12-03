using System;
using System.ComponentModel.DataAnnotations;
using vLibrary.Model.Enums;

namespace vLibrary.Model.Requests{
    public class MemberUpsertRequests{
        [Required(ErrorMessage="First name is required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage="Last name is required!")]
        public string LastName { get; set; }
        public byte[] Picture { get; set; }
        [Required(ErrorMessage="Email is required!")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        [Required(ErrorMessage="Date of membership is required!")]
        public DateTime DateOfMemberShip { get; set; }
        [Required(ErrorMessage="Number of books loaned")]
        public int NumberOfBooksLoaned { get; set; }
        [Required(ErrorMessage = "Street name is required!")]
        public string Street { get; set; }
        [Required(ErrorMessage = "City is required!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Zip code is required!")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Username is required!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Accountstatus is required!")]
        public AccountStatus AccountStatus { get; set; }
    }
}