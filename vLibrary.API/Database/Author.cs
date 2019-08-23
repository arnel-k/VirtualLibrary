using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Model
{

    public class Author : Entity
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Description { get; set; }

        public ICollection<Book_Author> Book_Authors { get; set; }
    }
}
