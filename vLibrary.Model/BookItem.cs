using System;
using System.Collections.Generic;
using System.Text;
using vLibrary.Model.Enums;

namespace vLibrary.Model
{
    public class BookItem : Entity
    {
        public DateTime Borrowed { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PublicationDate { get; set; }
        public BookFormat BookFormat { get; set; }
        public BookStatus BookStatus { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
