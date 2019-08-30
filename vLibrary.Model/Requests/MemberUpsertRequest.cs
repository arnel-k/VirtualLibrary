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
        [Required(ErrorMessage="Address is required!")]
        public int AddressDtoId { get; set; }
        public AddressDto AddressDto { get; set; }
        [Required(ErrorMessage="Account details are required!")]
        public int AccountDtoId { get; set; }
        public AccountDto AccountDto { get; set; }
    }
}