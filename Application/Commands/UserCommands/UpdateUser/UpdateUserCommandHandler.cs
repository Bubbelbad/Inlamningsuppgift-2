﻿using Application.Interfaces.RepositoryInterfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities.Core;
using MediatR;

namespace Application.Commands.UserCommands.UpdateUser
{
    public class UpdateUserCommandHandler(IGenericRepository<User, string> repository, IMapper mapper) : IRequestHandler<UpdateUserCommand, OperationResult<User>>
    {
        private readonly IGenericRepository<User, string> _repository = repository;
        private readonly IMapper _mapper = mapper;


        public async Task<OperationResult<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User userToUpdate = new()
                {
                    Id = request.UserToUpdate.Id,
                    UserName = request.UserToUpdate.UserName,
                    // Do I need to hash the PasswordHash here? Probably.
                    PasswordHash = request.UserToUpdate.Password
                };

                var updatedUser = await _repository.UpdateAsync(userToUpdate);
                var mappedUser = _mapper.Map<User>(updatedUser);
                return OperationResult<User>.Success(mappedUser);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving object from collection.", ex);
            }
        }
    }
}
