using System;
using System.Collections.Generic;

namespace vLibrary.API.Database
{
    public partial class Notifications
    {
        public Notifications()
        {
            BookLeadings = new HashSet<BookLeadings>();
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<BookLeadings> BookLeadings { get; set; }
    }
}
