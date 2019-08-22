using System;
using System.Collections.Generic;

namespace vLibrary.API.Database
{
    public partial class Books
    {
        public Books()
        {
            BookAuthors = new HashSet<BookAuthors>();
            BookLeadings = new HashSet<BookLeadings>();
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public bool IsDeleted { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public int NumberOfPages { get; set; }
        public string Subject { get; set; }
        public byte[] Image { get; set; }
        public DateTime PublicationDate { get; set; }
        public int BookStatus { get; set; }
        public int PublisherId { get; set; }
        public int LibraryId { get; set; }
        public int RackId { get; set; }
        public int CategoryId { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Libraries Library { get; set; }
        public virtual Publishers Publisher { get; set; }
        public virtual Racks Rack { get; set; }
        public virtual ICollection<BookAuthors> BookAuthors { get; set; }
        public virtual ICollection<BookLeadings> BookLeadings { get; set; }
    }
}
