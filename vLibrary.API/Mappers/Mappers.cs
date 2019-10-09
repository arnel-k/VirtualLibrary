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
               .ForMember(dest => dest.RackDtoGuid, opt => opt.MapFrom(src => src.Rack.Guid))
               .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
               .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.PublisherName))
               .ForMember(dest => dest.RackNumber, opt => opt.MapFrom(src=>src.Rack.RackNumber))
               .ForMember(dest => dest.RackLocation, opt => opt.MapFrom(src=>src.Rack.LocationIdentification));


            CreateMap<Book, BookUpsertRequest>().ReverseMap();
            CreateMap<Book, BookInsertRequest>().ReverseMap();


            CreateMap<Library, LibraryDto>();
            CreateMap<Library, LibraryUpsertRequest>().ReverseMap();

            CreateMap<Publisher, PublisherDto>();
            CreateMap<Publisher, PublisherUpsertRequest>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryUpsertRequest>().ReverseMap();

            CreateMap<Rack, RackDto>();
            CreateMap<Rack, RackUpsertRequest>().ReverseMap();

            CreateMap<Member, MemberDto>();
            CreateMap<Member, MemberSearchRequest>();

            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.AddressDtoGuid, opt => opt.MapFrom(src => src.Address.Guid))
                .ForMember(dest => dest.LibraryDtoGuid, opt => opt.MapFrom(src => src.Library.Guid));
            CreateMap<Employee, EmployeeUpsertRequest>().ReverseMap();
            CreateMap<Employee, EmployeeInsertRequest>().ReverseMap();
            
        }
    }
}
