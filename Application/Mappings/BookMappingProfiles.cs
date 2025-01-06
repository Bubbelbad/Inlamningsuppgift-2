using Domain.Entities.Core;
using AutoMapper;
using Application.Dtos.BookDtos;

namespace Application.Mappings
{
    public class BookMappingProfiles : Profile
    {
        public BookMappingProfiles()
        {
            CreateMap<Book, GetBookDto>();
            CreateMap<Book, AddBookDto>();
            CreateMap<Book, UpdateBookDto>();

            // For Testing:
            CreateMap<AddBookDto, Book>()
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId));

            // Add other user-related mappings here } }
        }
    }
}
