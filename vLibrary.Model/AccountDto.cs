using System;
using System.Collections.Generic;
using System.Text;
using vLibrary.Model;
using vLibrary.Model.Enums;

namespace vLibrary.Model

{

    public class AccountDto : Entity
    {

        public string Username { get; set; }
        public Role Role { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public string Token { get; set; }

    }
}
