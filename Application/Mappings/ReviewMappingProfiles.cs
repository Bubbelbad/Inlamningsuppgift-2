
using Application.Dtos.ReviewDtos;
using AutoMapper;
using Domain.Entities.Metadata;

namespace Application.Mappings
{
    public class ReviewMappingProfiles : Profile
    {
        public ReviewMappingProfiles()
        {
            CreateMap<Review, AddReviewDto>();
            CreateMap<Review, GetReviewDto>();

        }
    }
}
