using Application.Dtos.GenreDtos;
using AutoMapper;
using Domain.Entities.Metadata;

namespace Application.Mappings
{
    public class GenreMappingProfiles : Profile
    {
        public GenreMappingProfiles()
        {
            CreateMap<Genre, GetGenreDto>();
            CreateMap<Genre, AddGenreDto>();
            CreateMap<GetGenreDto, Genre>();
            CreateMap<Genre, UpdateGenreDto>();
            CreateMap<UpdateGenreDto, Genre>();
        }
    }
}
