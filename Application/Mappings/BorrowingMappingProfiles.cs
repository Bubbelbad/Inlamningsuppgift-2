using Application.Dtos.BorrowingDtos;
using AutoMapper;
using Domain.Entities.Transactions;

namespace Application.Mappings
{
    public class BorrowingMappingProfiles : Profile
    {
        public BorrowingMappingProfiles()
        {
            CreateMap<Borrowing, GetBorrowingDto>();
        }
    }
}
