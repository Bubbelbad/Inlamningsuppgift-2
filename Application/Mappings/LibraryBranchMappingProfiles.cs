using Application.Dtos.LibraryBranchDtos;
using AutoMapper;
using Domain.Entities.Locations;

namespace Application.Mappings
{
    public class LibraryBranchMappingProfiles : Profile
    {
        public LibraryBranchMappingProfiles()
        {
            CreateMap<LibraryBranch, GetLibraryBranchDto>();
        }
    }
}
