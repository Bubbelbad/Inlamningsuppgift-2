
using Application.Commands.ReservationCommands.AddReservation;
using Application.Dtos.ReservationDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Transactions;
using MediatR;

namespace Application.Commands.ReservationCommands.UpdateReservation
{
    internal class UpdateReservationCommandHandler(IGenericRepository<Reservation, int> repository, IMapper mapper) : IRequestHandler<UpdateReservationCommand, OperationResult<GetReservationDto>>
    {
        private readonly IGenericRepository<Reservation, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetReservationDto>> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Reservation reservation = new()
                {
                    Id = request.Dto.Id,
                    Status = request.Dto.Status,
                    CopyId = request.Dto.CopyId,
                    UserId = request.Dto.UserId,
                };

                var updatedReservation = await _repository.UpdateAsync(reservation);
                if (updatedReservation is null)
                {
                    return OperationResult<GetReservationDto>.Failure("Operation failed");
                }
                var mappedReservation = _mapper.Map<GetReservationDto>(updatedReservation);
                return OperationResult<GetReservationDto>.Success(mappedReservation);
            }
            catch (Exception ex)
            {
                return OperationResult<GetReservationDto>.Failure(ex.Message);
            }
        }
    }
}
