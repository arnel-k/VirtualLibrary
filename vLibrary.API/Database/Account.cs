using System;
using System.Collections.Generic;
using System.Text;
using vLibrary.Api.Database;
using vLibrary.Api.Database.Enums;

namespace vLibrary.Api.Database
{

    public class Account : Entity
    {
        
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Role Role { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public LibraryCard LibraryCard { get; set; }
        public Member Member { get; set; }

        
    }
}
