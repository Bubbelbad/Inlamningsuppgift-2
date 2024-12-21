using Application.Dtos.BookCopyDtos;
using AutoMapper;
using Domain.Entities.Core;

namespace Application.Mappings
{
    public class BookCopyMappingProfiles : Profile
    {
        public BookCopyMappingProfiles()
        {
            CreateMap<Book, GetBookCopyDto>();
        }
    }
}
