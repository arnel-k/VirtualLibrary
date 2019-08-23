using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vLibrary.API.Requests
{
    public class AuthorUpdateRequest
    { 
        [Required(ErrorMessage = "First name is required !")]
        [MinLength(3)]
        [MaxLength(50)]
        public string FName { get; set; }
        [Required(ErrorMessage = "Last name is required !")]
        [MinLength(3)]
        [MaxLength(50)]
        public string LName { get; set; }
        public string Description { get; set; }
    }
}
