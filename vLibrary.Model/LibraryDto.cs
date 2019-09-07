using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Model
{

    public class LibraryDto : Entity
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
    }
}
