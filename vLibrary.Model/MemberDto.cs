using System;
using System.Collections.Generic;
using System.Text;
using vLibrary.Model.Enums;

namespace vLibrary.Model
{ 
    public class MemberDto : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Picture { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfMemberShip { get; set; }
        public int NumberOfBooksLoaned { get; set; }
        public int AddressDtoId { get; set; }
        public AddressDto AddressDto { get; set; }

        public int AccountDtoId { get; set; }
        public AccountDto AccountDto { get; set; }

        
    }
}
