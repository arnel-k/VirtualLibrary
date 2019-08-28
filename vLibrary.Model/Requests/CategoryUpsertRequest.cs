using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace vLibrary.Model.Requests
{
    public class CategoryUpsertRequest
    {
        [Required(ErrorMessage = "Category  is required !")]
        public string CategoryName { get; set; }
    }
}
