using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.API.Dtos
{
    public interface IEntity
    { 
        Guid Guid { get; set; }
        bool IsDeleted { get; set; }
    }
}
