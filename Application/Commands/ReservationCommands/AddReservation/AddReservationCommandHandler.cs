using Application.Dtos.ReservationDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using Domain.Entities.Locations;
using Domain.Entities.Transactions;
using MediatR;

namespace Application.Commands.ReservationCommands.AddReservation
{
    internal class AddReservationCommandHandler(IGenericRepository<Reservation, int> reservationRepository,
                                                IGenericRepository<User, string> userRepository,
                                                IGenericRepository<BookCopy, Guid> bookRepository, IMapper mapper) : IRequestHandler<AddReservationCommand, OperationResult<GetReservationDto>>
    {
        private readonly IGenericRepository<Reservation, int> _reservationRepository = reservationRepository;
        private readonly IGenericRepository<User, string> _userRepository = userRepository;
        private readonly IGenericRepository<BookCopy, Guid> _bookRepository = bookRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetReservationDto>> Handle(AddReservationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve the book copy
                var bookCopy = await _bookRepository.GetByIdAsync(request.Dto.CopyId);
                if (bookCopy is null || bookCopy.Status == "Reserved")
                {
                    return OperationResult<GetReservationDto>.Failure("Book copy is not available");
                }

                //Retrieve the user
                var user = await _userRepository.GetByIdAsync(request.Dto.UserId);
                if (user is null)
                {
                    return OperationResult<GetReservationDto>.Failure("User not found");
                }

                // Create a new reservation record
                Reservation reservation = new()
                {
                    Status = "Reserved",
                    ReservationDate = DateTime.Now,
                    CopyId = request.Dto.CopyId,
                    UserId = request.Dto.UserId
                };

                // Change the bookCopy status
                var successfulUpdate = await _bookRepository.UpdateAsync(bookCopy);
                if (successfulUpdate is null)
                {
                    return OperationResult<GetReservationDto>.Failure("Operation failed");
                }

                // Save the reservation
                var successfulReservation = await _reservationRepository.AddAsync(reservation);
                if (successfulReservation is null)
                {
                    return OperationResult<GetReservationDto>.Failure("Operation failed");
                }

                var mappedReservation = _mapper.Map<GetReservationDto>(successfulReservation);
                return OperationResult<GetReservationDto>.Success(mappedReservation);
            }
            catch (Exception ex)
            {
                return OperationResult<GetReservationDto>.Failure("Operation failed", ex.Message);
            }
        }
    }
}
