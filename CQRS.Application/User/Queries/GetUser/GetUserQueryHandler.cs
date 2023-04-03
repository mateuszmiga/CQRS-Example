using CQRS.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.User.Queries.GetUser
{        
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Domain.Entities.User>
    {
        private readonly Repository repository;

        public GetUserQueryHandler(Repository repository)
        {
            this.repository = repository;
        }

        async Task<Domain.Entities.User> IRequestHandler<GetUserQuery, Domain.Entities.User>.Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await repository.Get(request.Id);
        }
    }
}
