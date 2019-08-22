using System;
using System.Collections.Generic;

namespace vLibrary.API.Database
{
    public partial class Authors
    {
        public Authors()
        {
            BookAuthors = new HashSet<BookAuthors>();
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public bool IsDeleted { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BookAuthors> BookAuthors { get; set; }
    }
}
