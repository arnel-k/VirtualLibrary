using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace vLibrary.Api.Database
{
    public class Book_Author
    {
        //TODO: FINISH BOOK_AUTHOR
        
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public Guid AuthorGuid { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
        public Guid BookGuid { get; set; }
    }
}
