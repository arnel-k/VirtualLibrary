using System;
using System.Collections.Generic;
using System.Text;

namespace vLibrary.Api.Database
{
    public interface IEntity
    {
        int Id { get; set; }
        Guid Guid { get; set; }
        bool IsDeleted { get; set; }
    }
}
