﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.Model;
using vLibrary.Model.Requests;


namespace vLibrary.API.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> Get(AuthorsSearchRequest request);
        Task<AuthorDto> Insert(AuthorInsertRequest request);
        Task<AuthorDto> Update(Guid guid, AuthorUpdateRequest request);
        Task<AuthorDto> Delete(Guid guid);
        Task<AuthorDto> GetById(Guid guid);
    }
}
