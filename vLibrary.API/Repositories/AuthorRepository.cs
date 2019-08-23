﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.API.Context;
using vLibrary.API.Repositories.Interfaces;
using vLibrary.Model;

namespace vLibrary.API.Repositories
{
    public class AuthorRepository : Repository<Model.Author>, IAuthorRepository<Model.Author>
    {
        private readonly LibraryContext _ctx;
        public AuthorRepository(LibraryContext ctx ):base(ctx)
        {
            _ctx = ctx;
        }

        public new async Task<Author> GetById(Guid guid)
        {
            var entity = await _ctx.Authors.FirstOrDefaultAsync(x => x.Guid == guid);
            return entity;
        }
    }
}