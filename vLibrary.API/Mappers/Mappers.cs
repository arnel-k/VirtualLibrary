using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.API.Requests;

namespace vLibrary.API.Mappers
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Model.Author, Dtos.AuthorDto>();
            CreateMap<Model.Author, AuthorInsertRequest>().ReverseMap();
            CreateMap<Model.Author, AuthorUpdateRequest>().ReverseMap();
        }
    }
}
