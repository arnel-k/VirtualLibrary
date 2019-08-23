using System;
using System.Collections.Generic;
using System.Text;
using vLibrary.Model.Enums;

namespace vLibrary.Model
{
    public class Book : Entity
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int NumberOfPages { get; set; }
        public string Subject { get; set; }
        public byte[] Image { get; set; }
        public DateTime PublicationDate { get; set; }
        public BookStatus BookStatus { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        //public int BookItemId { get; set; }
        //public BookItem BookItem { get; set; }
        public ICollection<Book_Author> Book_Authors { get; set; }
        public int LibraryId { get; set; }
        public Library Library { get; set; }
        public int RackId { get; set; }
        public Rack Rack { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        public ICollection<BookLeading> BookLeadings { get; set; }
    }
}
