using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Model
{

    public class Entity : IEntity
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public bool IsDeleted { get; set; }
       
    }
}
