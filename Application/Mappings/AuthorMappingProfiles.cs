using Application.Dtos;
using Application.Dtos.AuthorDtos;
using AutoMapper;
using Domain.Entities.Core;

namespace Application.Mappings
{
    public class AuthorMappingProfiles : Profile
    {
        public AuthorMappingProfiles()
        {
            CreateMap<Author, GetAuthorDto>();
            CreateMap<AddAuthorDto, Author>();
            CreateMap<UpdateAuthorDto, Author>();
        }
    }
}
