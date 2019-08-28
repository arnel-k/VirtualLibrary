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
            //Author
            CreateMap<Author, AuthorDto>();
            CreateMap<Author, AuthorInsertRequest>().ReverseMap();
            CreateMap<Author, AuthorUpdateRequest>().ReverseMap();
            //Address
            CreateMap<Address, AddressDto>();
            CreateMap<Address, AddressUpsertRequest>().ReverseMap();

            CreateMap<Book, BookDto>().ForMember(dest => dest.PublisherDtoGuid, opt => opt.MapFrom(src => src.Publisher.Guid))
               .ForMember(dest => dest.LibraryDtoGuid, opt => opt.MapFrom(src => src.Library.Guid))
               .ForMember(dest => dest.CategoryDtoGuid, opt => opt.MapFrom(src => src.Category.Guid))
               .ForMember(dest => dest.RackDtoGuid, opt => opt.MapFrom(src => src.Rack.Guid));
            CreateMap<Book, BookUpsertRequest>().ReverseMap();
            CreateMap<Book, BookInsertRequest>().ReverseMap();

            CreateMap<Library, LibraryDto>().ForMember(dest => dest.AccountDtoId, opt => opt.MapFrom(src => src.Account.Guid));
            CreateMap<Library, LibraryUpsertRequest>().ReverseMap();

            CreateMap<Publisher, PublisherDto>();
            CreateMap<Publisher, PublisherUpsertRequest>();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryUpsertRequest>().ReverseMap();

            CreateMap<Rack, RackDto>();
            CreateMap<Rack, RackUpsertRequest>();
            
        }
    }
}
