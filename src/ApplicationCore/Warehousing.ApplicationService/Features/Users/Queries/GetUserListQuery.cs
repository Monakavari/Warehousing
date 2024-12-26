using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Users.Queries
{
    public class GetUserListQuery :MediatR.IRequest<ApiResponse<List<GetUserResponseVM>>>
    {
    }
}
