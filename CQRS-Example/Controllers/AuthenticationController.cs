using CQRS.Application.User.Commands.SignIn;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <response code="200">Successfully signed in.</response>
        /// <response code="401">Username or password is not valid.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInUserAsync([FromBody] SignInCommand command)
        {
            var response = await _mediator.Send(command);

            if (response.AccessToken == null)
            {
                return Unauthorized();
            }

            return Ok(response);
        }
    }
}
