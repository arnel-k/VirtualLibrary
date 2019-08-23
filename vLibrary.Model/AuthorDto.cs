using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Model
{

    public class AuthorDto : Entity
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Description { get; set; }
    }
}
