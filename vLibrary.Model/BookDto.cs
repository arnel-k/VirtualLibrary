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
        public Guid PublisherDtoGuid { get; set; }
        public string RackNumber { get; set; }
        public string CategoryName { get; set; }
        public string PublisherName { get; set; }
        public Guid LibraryDtoGuid { get; set; }
        public Guid RackDtoGuid { get; set; }
        public Guid CategoryDtoGuid { get; set; }
        public string RackLocation { get; set; }



    }
}
