
using Application.Dtos.PublisherDtos;
using AutoMapper;
using Domain.Entities.Metadata;

namespace Application.Mappings
{
    public class PublisherMappingProfiles : Profile
    {
        public PublisherMappingProfiles()
        {
            CreateMap<Publisher, GetPublisherDto>();
        }
    }
}
