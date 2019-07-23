using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Model
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public ICollection<User> User { get; set; }
    }
}
