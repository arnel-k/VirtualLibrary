using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Model
{
    public interface IEntity
    {
        Guid Guid { get; set; }
        bool IsDeleted { get; set; }
    }
}
