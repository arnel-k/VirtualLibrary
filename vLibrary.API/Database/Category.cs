using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Api.Database
{
    public class Category : Entity
    {
        public string CategoryName { get; set; }
        public ICollection<Book> Books{ get; set; }
    }
}
