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
        public byte[] Image { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int BookItemId { get; set; }
        public BookItem BookItem { get; set; }
        public ICollection<Book_Author> Book_Authors { get; set; }
    }
}
