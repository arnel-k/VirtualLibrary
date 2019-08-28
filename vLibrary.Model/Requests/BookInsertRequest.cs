using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using vLibrary.Model.Enums;

namespace vLibrary.Model.Requests
{
    public class BookInsertRequest
    {
        public Guid Guid { get; set; }
        [Required(ErrorMessage = "ISBN is required !")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Title is required !")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Number of pages is required !")]
        public int NumberOfPages { get; set; }
        [Required(ErrorMessage = "Subject is required !")]
        public string Subject { get; set; }
        public byte[] Image { get; set; }

        public DateTime PublicationDate { get; set; }
        [Required(ErrorMessage = "Book status is required !")]
        public BookStatus BookStatus { get; set; }
        [Required(ErrorMessage = "Publisher is required !")]
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "Library is required !")]
        public int LibraryId { get; set; }

        [Required(ErrorMessage = "Rack is required !")]
        public int RackId { get; set; }

        [Required(ErrorMessage = "Category is required !")]
        public int CategoryId { get; set; }
    }
}
