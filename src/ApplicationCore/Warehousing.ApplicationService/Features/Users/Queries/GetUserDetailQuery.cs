using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Users.Queries
{
    public class GetUserDetailQuery :MediatR.IRequest<ApiResponse<GetUserResponseVM>>
    {
        public string Id { get; set; }
    }
}
