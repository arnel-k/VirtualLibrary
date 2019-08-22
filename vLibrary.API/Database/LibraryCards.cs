using System;
using System.Collections.Generic;

namespace vLibrary.API.Database
{
    public partial class LibraryCards
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public bool IsDeleted { get; set; }
        public string CardNumber { get; set; }
        public DateTime IssuedAt { get; set; }
        public bool IsActive { get; set; }
        public int AccountId { get; set; }

        public virtual Accounts Account { get; set; }
    }
}
