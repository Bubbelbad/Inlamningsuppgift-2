using Application.Dtos.BookDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Locations;
using MediatR;

namespace Application.Commands.BookCopyCommands.AddBookCopy
{
    internal class AddBookCopyCommandHandler(IGenericRepository<BookCopy, Guid> repository, IMapper mapper) : IRequestHandler<AddBookCopyCommand, OperationResult<GetBookDto>>
    {
        private readonly IGenericRepository<BookCopy, Guid> _repository = repository;
        public readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetBookDto>> Handle(AddBookCopyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                BookCopy bookCopyToCreate = new()
                {
                    CopyId = Guid.NewGuid(),
                    BookId = request.Dto.BookId,
                    BranchId = request.Dto.BranchId,
                    Status = request.Dto.Status
                };

                var createdBookCopy = await _repository.AddAsync(bookCopyToCreate);
                var mappedBookCopy = _mapper.Map<GetBookDto>(createdBookCopy);

                return OperationResult<GetBookDto>.Success(mappedBookCopy);
            }
            catch (Exception ex)
            {
                throw new Exception("Book copy not added", ex);

            }
        }
    }
}
