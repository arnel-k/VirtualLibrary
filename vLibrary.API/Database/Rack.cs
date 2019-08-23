using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Api.Database
{
    public class Rack : Entity
    {
        public int RackNumber { get; set; }
        public string LocationIdentification { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
