using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Model
{
    public class Book : Entity
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int NumberOfPages { get; set; }
        public string Subject { get; set; }
        public ICollection<BookItem> BookItems { get; set; }
        public ICollection<Publisher> Publishers { get; set; }

        public ICollection<Book_Author> Book_Authors { get; set; }
    }
}
