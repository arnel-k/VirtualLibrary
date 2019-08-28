using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace vLibrary.Model.Requests
{
    public class RackUpsertRequest
    {
        [Required(ErrorMessage = "Rack number  is required !")]
        public int RackNumber { get; set; }
        [Required(ErrorMessage = "Location  is required !")]
        public string LocationIdentification { get; set; }
    }
}
