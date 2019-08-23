using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Api.Database
{
    public class Notification : Entity
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
