using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Transactions;
using MediatR;

namespace Application.Commands.ReservationCommands.DeleteReservation
{
    internal class DeleteReservationCommandHandler(IGenericRepository<Reservation, int> repository, IMapper mapper) : IRequestHandler<DeleteReservationCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<Reservation, int> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<bool>> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var deletionSuccessful = await _repository.DeleteAsync(request.Id);
                if (deletionSuccessful is false)
                {
                    return OperationResult<bool>.Failure("Operation failed");
                }
                return OperationResult<bool>.Success(deletionSuccessful);
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.Failure(ex.Message);
            }
        }
    }
}
