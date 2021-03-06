﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.Model;
using vLibrary.Model.Requests;


namespace vLibrary.API.Services
{
    public interface IAuthorService<T,TSearch> : IService<T,TSearch> where T: class
    {
    }
}
