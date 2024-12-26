using MediatR;
using Warehousing.ApplicationService.Features.Users.Queries;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.Users.QueryHandlers
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, ApiResponse<GetUserResponseVM>>
    {
        #region Constructor
        private readonly IUserRepository _UserRepository;
        public GetUserDetailQueryHandler(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        #endregion
        public async Task<ApiResponse<GetUserResponseVM>> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _UserRepository.GetByIdAsync(request.Id, cancellationToken);
            var mapper = UserProfile.Map(entity);

            return new ApiResponse<GetUserResponseVM>(true, ApiResponseStatusCode.Success, mapper, "عملیات با موفقیت انجام شد");
        }
    }
}
