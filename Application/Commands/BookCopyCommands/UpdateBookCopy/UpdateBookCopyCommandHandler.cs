using Application.Dtos.BookCopyDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Locations;
using MediatR;

namespace Application.Commands.BookCopyCommands.UpdateBookCopy
{
    internal class UpdateBookCopyCommandHandler(IGenericRepository<BookCopy, Guid> repository, IMapper mapper) : IRequestHandler<UpdateBookCopyCommand, OperationResult<GetBookCopyDto>>
    {
        private readonly IGenericRepository<BookCopy, Guid> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetBookCopyDto>> Handle(UpdateBookCopyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                BookCopy bookToUpdate = new BookCopy()
                {
                    CopyId = request.Dto.CopyId,
                    BookId = request.Dto.BookId,
                    Status = request.Dto.Status,
                    FileFormat = request.Dto.FileFormat,
                    FileSize = request.Dto.FileSize,
                    FilePath = request.Dto.FilePath,
                };

                var updatedBookCopy = await _repository.UpdateAsync(bookToUpdate);
                var mappedBookCopy = _mapper.Map<GetBookCopyDto>(updatedBookCopy);

                return OperationResult<GetBookCopyDto>.Success(mappedBookCopy);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred.", ex);
            }
        }
    }
}
