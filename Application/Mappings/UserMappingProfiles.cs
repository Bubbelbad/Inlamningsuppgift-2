using Application.Dtos;
using Application.Dtos.UserDtos;
using AutoMapper;
using Domain.Entities.Core;

namespace Application.Mappings
{
    public class UserMappingProfiles : Profile
    {
        public UserMappingProfiles()
        {
            CreateMap<User, UpdateUserDto>();
            CreateMap<User, GetUserDto>();
            // Add other user-related mappings here } }
        }
    }
}
