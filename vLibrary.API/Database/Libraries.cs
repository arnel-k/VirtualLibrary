using System;
using System.Collections.Generic;

namespace vLibrary.API.Database
{
    public partial class Libraries
    {
        public Libraries()
        {
            Books = new HashSet<Books>();
            Employees = new HashSet<Employees>();
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public int AccountId { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual ICollection<Books> Books { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
