using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.UserQueries.GetDetailedUserById
{
    public class GetDetailedUserByIdQuery(Guid id) : IRequest<OperationResult<User>>
    {
        public Guid Id { get; set; } = id;
    }
}
