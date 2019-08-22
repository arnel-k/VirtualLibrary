using System;
using System.Collections.Generic;

namespace vLibrary.API.Database
{
    public partial class Member
    {
        public Member()
        {
            BookLeadings = new HashSet<BookLeadings>();
            Payments = new HashSet<Payments>();
        }

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
        public DateTime DateOfMemberShip { get; set; }
        public int NumberOfBooksLoaned { get; set; }
        public int AddressId { get; set; }
        public int AccountId { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual Addresses Address { get; set; }
        public virtual ICollection<BookLeadings> BookLeadings { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
    }
}
