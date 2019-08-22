using System;
using System.Collections.Generic;

namespace vLibrary.API.Database
{
    public partial class Publishers
    {
        public Publishers()
        {
            Books = new HashSet<Books>();
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public bool IsDeleted { get; set; }
        public string PublisherName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
