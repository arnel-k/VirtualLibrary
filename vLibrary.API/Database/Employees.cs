using System;
using System.Collections.Generic;

namespace vLibrary.API.Database
{
    public partial class Employees
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public bool IsDeleted { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Picture { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
        public int AddressId { get; set; }
        public int LibraryId { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual Libraries Library { get; set; }
    }
}
