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
            // Add other user-related mappings here } }
        }
    }
}
