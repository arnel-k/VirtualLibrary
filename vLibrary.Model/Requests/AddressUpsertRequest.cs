using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace vLibrary.Model.Requests
{
    public class AddressUpsertRequest
    {
        public Guid Guid { get; set; }
        [Required(ErrorMessage = "Street required !")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Street { get; set; }
        [Required(ErrorMessage = "City required !")]
        [MinLength(3)]
        [MaxLength(50)]
        public string City { get; set; }
        
        [Required(ErrorMessage = "Zip Code required !")]
        [MinLength(3)]
        [MaxLength(50)]
        public string ZipCode { get; set; }
    }
}
