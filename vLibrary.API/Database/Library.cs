using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Api.Database
{

    public class Library : Entity
    {
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Member> Members { get; set; }

    }
}
