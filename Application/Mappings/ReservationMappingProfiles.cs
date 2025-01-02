using Application.Dtos.ReservationDtos;
using AutoMapper;
using Domain.Entities.Transactions;

namespace Application.Mappings
{
    internal class ReservationMappingProfiles : Profile
    {
        public ReservationMappingProfiles()
        {
            CreateMap<Reservation, GetReservationDto>();
        }
    }
}
