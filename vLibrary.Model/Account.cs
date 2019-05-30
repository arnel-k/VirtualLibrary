using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Model
{

    public class Account : Entity
    {
        public string Password { get; set; }
        public AccountStatus AccountStatus { get; set; }
    }
}
