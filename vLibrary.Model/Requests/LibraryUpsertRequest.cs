using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace vLibrary.Model.Requests
{
    public class LibraryUpsertRequest
    {
        public Guid Guid { get; set; }
        [Required(ErrorMessage = "Library name is required !")]
        public string Name { get; set; }
     
    }
}
