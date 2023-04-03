using MediatR;

namespace CQRS.Application.User.Commands.SignIn
{
    public class SignInCommand : IRequest<Token>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
