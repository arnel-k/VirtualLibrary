using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vLibrary.API.Database
{
    public partial class BookAuthors
    {
        
        public int AuthorId { get; set; }
        
        public int BookId { get; set; }

        public  Authors Author { get; set; }
        public  Books Book { get; set; }
    }
}
