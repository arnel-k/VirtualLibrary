using System;
using System.Collections.Generic;
using System.Text;
using vLibrary.Api.Database.Enums;

namespace vLibrary.Api.Database
{
    public class Member : Entity
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
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public ICollection<BookLeading> BookLeadings { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
