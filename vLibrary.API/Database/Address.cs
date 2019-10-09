using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Api.Database
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public ICollection<Member> Member { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
