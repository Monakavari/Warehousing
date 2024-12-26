using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehousing.ApplicationService.Features.Users.Commands.Create;
using Warehousing.ApplicationService.Features.Users.Commands.Delete;
using Warehousing.ApplicationService.Features.Users.Commands.Update;
using Warehousing.ApplicationService.Features.Users.Queries;
using Warehousing.WebApi.Infrastructure;

namespace Warehousing.WebApi.Controllers
{
    public class UserController : BaseController
    {
        #region Constructor
        public UserController(IMediator mediator) : base(mediator)
        {
        }
        #endregion Constructor

        #region Queries
        [HttpGet("id")]
        public async Task<IActionResult> GetUserById(string id, CancellationToken cancellationToken)
        {
            var command = new GetUserDetailQuery { Id = id };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var command = new GetUserListQuery();
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        #endregion Queries

        #region Command
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteUser(string id, CancellationToken cancellationToken)
        {
            var command = new DeleteUserCommand { Id = id };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        #endregion Command
    }
}
