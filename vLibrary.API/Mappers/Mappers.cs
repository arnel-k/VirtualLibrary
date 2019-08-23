using AutoMapper;
using vLibrary.Model;
using vLibrary.Model.Requests;
namespace vLibrary.API.Mappers
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Model.Author, AuthorDto>();
            CreateMap<Model.Author, AuthorInsertRequest>().ReverseMap();
            CreateMap<Model.Author, AuthorUpdateRequest>().ReverseMap();
        }
    }
}
