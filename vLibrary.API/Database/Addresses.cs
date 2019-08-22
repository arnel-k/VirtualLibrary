using System;
using System.Collections.Generic;

namespace vLibrary.API.Database
{
    public partial class Addresses
    {
        public Addresses()
        {
            Employees = new HashSet<Employees>();
            Member = new HashSet<Member>();
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public bool IsDeleted { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<Member> Member { get; set; }
    }
}
