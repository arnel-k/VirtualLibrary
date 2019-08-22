using System;
using System.Collections.Generic;
using System.Text;
using vLibrary.Model.Enums;

namespace vLibrary.Model.Requests
{
    public class MemberInsertRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Picture { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
