using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Model
{

    public class Library : Entity
    {
        public string Name { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public ICollection<BookItem> BookItems { get; set; }
        //public ICollection<User> User { get; set; }

    }
}
