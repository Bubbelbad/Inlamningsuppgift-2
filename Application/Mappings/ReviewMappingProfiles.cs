
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
            CreateMap<AddReviewDto, GetReviewDto>();
            CreateMap<Review, GetBookReviewsDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
        }
    }
}
