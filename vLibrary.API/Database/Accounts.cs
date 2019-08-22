using System;
using System.Collections.Generic;

namespace vLibrary.API.Database
{
    public partial class Accounts
    {
        public Accounts()
        {
            Libraries = new HashSet<Libraries>();
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        public int AccountStatus { get; set; }

        public virtual LibraryCards LibraryCards { get; set; }
        public virtual Member Member { get; set; }
        public virtual ICollection<Libraries> Libraries { get; set; }
    }
}
