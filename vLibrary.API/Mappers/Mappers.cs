using AutoMapper;
using vLibrary.Api.Database;
using vLibrary.Model;
using vLibrary.Model.Requests;
namespace vLibrary.API.Mappers
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<Author, AuthorInsertRequest>().ReverseMap();
            CreateMap<Author, AuthorUpdateRequest>().ReverseMap();
        }
    }
}
