using Application.Dtos;
using AutoMapper;
using Domain.Model;

namespace Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UpdateUserDto>();
            // Add other user-related mappings here } }
        }
    }
}
