using System;
//using System.ComponentModel.DataAnotations;
namespace vLibrary.Model.Requests
{
    public class AuthorUpdateRequest
    { 
        //[Requied(ErrorMessage = "First name is required !")]
        //[MinLength(3)]
        //[MaxLength(50)]
        public string FName { get; set; }
        //[Required(ErrorMessage = "Last name is required !")]
        //[MinLength(3)]
        //[MaxLength(50)]
        public string LName { get; set; }
        public string Description { get; set; }
    }
}
