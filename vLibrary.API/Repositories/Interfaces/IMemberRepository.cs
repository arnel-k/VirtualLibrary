﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace vLibrary.API.Repositories.Interfaces
{
    public interface IMemberRepository<T> : IRepository<T> where T : class
    {

    }
}
