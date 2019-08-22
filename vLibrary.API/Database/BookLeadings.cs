using System;
using System.Collections.Generic;

namespace vLibrary.API.Database
{
    public partial class BookLeadings
    {
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public int? NotificationId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool Returned { get; set; }

        public virtual Books Book { get; set; }
        public virtual Member Member { get; set; }
        public virtual Notifications Notification { get; set; }
    }
}
