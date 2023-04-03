using CQRS.Application.User.Commands.CreateUser;
using CQRS.Application.User.Queries.GetUser;
using CQRS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CQRS_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<User> GetAsync(int id)
        {
            var result = await _mediator.Send(new GetUserQuery(id));
            return result;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task CreateAsync([FromBody] CreateUserCommand command)
        {
            await _mediator.Send(command);
        }

    }
}
