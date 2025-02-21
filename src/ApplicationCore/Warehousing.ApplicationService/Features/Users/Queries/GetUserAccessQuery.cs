using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Users.Queries
{
    public class GetUserAccessQuery :IRequest<ApiResponse<List<string>>>
    {
        public string UserId { get; set; }
    }
}
