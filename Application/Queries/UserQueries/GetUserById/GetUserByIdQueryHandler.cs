using Application.Dtos.UserDtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;


namespace Application.Queries.UserQueries.GetUserById
{
    public class GetUserByIdQueryHandler(IGenericRepository<User, string> repository, IMapper mapper) : IRequestHandler<GetUserByIdQuery, OperationResult<GetUserDto>>
    {
        private readonly IGenericRepository<User, string> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OperationResult<GetUserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _repository.GetByIdAsync(request.Id.ToString());
                var mappedUser = _mapper.Map<GetUserDto>(user);
                return OperationResult<GetUserDto>.Success(mappedUser);
            }
            catch
            {
                throw new Exception("User not found");
            }
        }
    }
}
