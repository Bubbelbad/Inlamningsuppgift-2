using Application.Dtos.BookCopyDtos;
using AutoMapper;
using Domain.Entities.Locations;

namespace Application.Mappings
{
    public class BookCopyMappingProfiles : Profile
    {
        public BookCopyMappingProfiles()
        {
            CreateMap<BookCopy, GetBookCopyDto>();
        }
    }
}
