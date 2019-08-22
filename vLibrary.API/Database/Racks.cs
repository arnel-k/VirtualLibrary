using System;
using System.Collections.Generic;

namespace vLibrary.API.Database
{
    public partial class Racks
    {
        public Racks()
        {
            Books = new HashSet<Books>();
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public bool IsDeleted { get; set; }
        public int RackNumber { get; set; }
        public string LocationIdentification { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
