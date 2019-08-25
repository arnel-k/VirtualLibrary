using System;
using System.Collections.Generic;
using System.Text;
using vLibrary.Model.Enums;

namespace vLibrary.Model
{
    public class BookDto : Entity
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int NumberOfPages { get; set; }
        public string Subject { get; set; }
        public byte[] Image { get; set; }
        public DateTime PublicationDate { get; set; }
        public BookStatus BookStatus { get; set; }
        public int PublisherDtoId { get; set; }
        public PublisherDto PublisherDto { get; set; }
        public int LibraryDtoId { get; set; }
        public LibraryDto LibraryDto { get; set; }
        public int RackDtoId { get; set; }
        public RackDto RackDto { get; set; }
        public int CategoryDtoId { get; set; }
        public CategoryDto CategoryDto { get; set; }
    }
}
