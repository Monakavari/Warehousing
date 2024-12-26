using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest<ApiResponse>
    {
        public string Id { get; set; }
    }
}
