using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Api.Database
{
    public class BookLeading 
    {
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int? NotificationId { get; set; }
        public Notification Notification { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool Returned { get; set; }
    }
}
