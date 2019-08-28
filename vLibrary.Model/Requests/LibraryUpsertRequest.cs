using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace vLibrary.Model.Requests
{
    public class LibraryUpsertRequest
    {
        [Required(ErrorMessage = "Library name is required !")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Account is required !")]
        public int AccountDtoId { get; set; }
    }
}
