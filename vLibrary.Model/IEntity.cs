using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Model
{
    public interface IEntity
    {
        int Id { get; set; }
        Guid Guid { get; set; }
        bool IsDeleted { get; set; }
    }
}
