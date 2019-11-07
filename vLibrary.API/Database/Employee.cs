using System;
using System.Collections.Generic;
using System.Text;
using vLibrary.Api.Database.Enums;

namespace vLibrary.Api.Database
{
    public class Employee : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public byte[] Picture { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int LibraryId { get; set; }
        public Library Library { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
