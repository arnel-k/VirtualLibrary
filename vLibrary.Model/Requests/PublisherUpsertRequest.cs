using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace vLibrary.Model.Requests
{
    public class PublisherUpsertRequest
    {
        [Required(ErrorMessage = "Publisher name is required !")]
        public string PublisherName { get; set; }
        public string Description { get; set; }
    }
}
