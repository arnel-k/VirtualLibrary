using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using vLibrary.Model.Enums;

namespace vLibrary.Model.Requests
{
    public class AccountUpsertRequest
    {
        public Guid Guid { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage="Password is required")]
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get;  set; }
        public Role Role { get; set; }
        public AccountStatus AccountStatus { get; set; }
    }
}
