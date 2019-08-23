using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Api.Database
{
    public class Publisher : Entity
    {
        public string PublisherName { get; set; }
        public string Description { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
