﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vLibrary.API.Services
{
    public interface IBookService<T,TSearch> : IService<T,TSearch> where T :class
    {
    }
}
