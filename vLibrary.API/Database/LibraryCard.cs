using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Api.Database
{
    public class LibraryCard : Entity
    {
        public string CardNumber { get; set; }
        public DateTime IssuedAt { get; set; }
        public bool IsActive { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
