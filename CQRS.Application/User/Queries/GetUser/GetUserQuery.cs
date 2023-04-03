using CQRS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.User.Queries.GetUser
{
    public class GetUserQuery : IRequest<Domain.Entities.User>
    {
        public int Id { get; private set; }

        public GetUserQuery(int id)
        {
            Id = id;
        }
        
    }
}
