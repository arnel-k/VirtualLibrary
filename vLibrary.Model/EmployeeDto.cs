using vLibrary.Model.Enums;
using System;
namespace vLibrary.Model{
    public class Employee : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Picture { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public System.DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

        public Guid AddressGuid { get; set; }
        public AddressDto AddressDto { get; set; }
        public Guid LibraryGuid { get; set; }
        public LibraryDto LibraryDto { get; set; }
    }   
}