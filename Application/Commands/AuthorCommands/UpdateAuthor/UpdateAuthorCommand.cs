﻿using Application.Dtos.AuthorDtos;
using Application.Models;
using Domain.Entities.Core;
using MediatR;

namespace Application.Commands.AuthorCommands.UpdateAuthor
{
    public class UpdateAuthorCommand(UpdateAuthorDto authorToUpdate) : IRequest<OperationResult<GetAuthorDto>>
    {
        public UpdateAuthorDto NewAuthor { get; set; } = authorToUpdate;
    }
}
