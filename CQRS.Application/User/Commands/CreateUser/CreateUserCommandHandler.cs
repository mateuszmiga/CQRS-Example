using CQRS.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.User.Commands.CreateUser
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly Repository repository;

        public CreateUserCommandHandler(Repository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await repository.Create(request.Login);
            return Unit.Value;
        }
    }
}
