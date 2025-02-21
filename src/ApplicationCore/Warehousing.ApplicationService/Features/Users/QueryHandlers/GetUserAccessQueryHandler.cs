using Microsoft.AspNetCore.Identity;
using Warehousing.ApplicationService.Features.Users.Queries;
using Warehousing.Common;
using Warehousing.Domain.Entities;

namespace Warehousing.ApplicationService.Features.Users.QueryHandlers
{
    public class GetUserAccessQueryHandler : MediatR.IRequestHandler<GetUserAccessQuery, ApiResponse<List<string>>>
    {
        #region Constructor
        private readonly UserManager<ApplicationUsers> _userManager;
        public GetUserAccessQueryHandler(UserManager<ApplicationUsers> userManager)
        {
            _userManager = userManager;
        }
        #endregion
        public async Task<ApiResponse<List<string>>> Handle(GetUserAccessQuery request, CancellationToken cancellationToken)
        {
            var getUser = await _userManager.FindByIdAsync(request.UserId);
            var roles = await _userManager.GetRolesAsync(getUser);
            var data = roles.ToList();

            return new ApiResponse<List<string>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد.");
        }
    }
}
