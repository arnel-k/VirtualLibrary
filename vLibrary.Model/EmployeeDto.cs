using vLibrary.Model.Enums;
using System;

namespace vLibrary.Model
{
    public class EmployeeDto : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Picture { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public System.DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public Guid AddressDtoGuid { get; set; }
        public Guid LibraryDtoGuid { get; set; }
        
    }
}