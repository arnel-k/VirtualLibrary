using System;
using System.ComponentModel.DataAnnotations;


namespace vLibrary.Model.Requests
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
