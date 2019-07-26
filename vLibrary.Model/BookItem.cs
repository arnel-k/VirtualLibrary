using System;
using System.Collections.Generic;
using System.Text;
using vLibrary.Model.Enums;

namespace vLibrary.Model
{
    //Not used
    public class BookItem : Entity
    {
        public DateTime PublicationDate { get; set; }
        public BookFormat BookFormat { get; set; }
        public BookStatus BookStatus { get; set; }
        public int Quantity { get; set; }
        public int LibraryId { get; set; }
        public Library Library { get; set; }
        public int RackId { get; set; }
        public Rack Rack { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<BookLeading> BookLeadings { get; set; }
    }
}
