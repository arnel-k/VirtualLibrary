using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Model
{

    public class LibraryDto : Entity
    {
        public string Name { get; set; }
        public int AccountDtoId { get; set; }
        public AccountDto AccountDto { get; set; }

    }
}
