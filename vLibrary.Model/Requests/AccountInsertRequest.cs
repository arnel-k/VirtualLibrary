using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vLibrary.Model.Enums;

namespace vLibrary.Model.Requests
{
    public class AccountInsertRequest
    {
        public Guid Guid { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        public Role Role { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}
