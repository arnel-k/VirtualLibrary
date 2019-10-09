using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Model
{
    public class AddressDto : Entity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
