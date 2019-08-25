using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Model
{
    public class LibraryCardDto : Entity
    {
        public string CardNumber { get; set; }
        public DateTime IssuedAt { get; set; }
        public bool IsActive { get; set; }
        public int AccountDtoId { get; set; }
        public AccountDto AccountDto { get; set; }
    }
}
