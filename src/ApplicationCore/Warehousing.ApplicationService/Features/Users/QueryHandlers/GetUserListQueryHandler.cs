using MediatR;
using Microsoft.EntityFrameworkCore;
using Warehousing.ApplicationService.Features.Suppliers.Queries;
using Warehousing.ApplicationService.Features.Users.Queries;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.Suppliers.QueryHandlers
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, ApiResponse<List<GetUserResponseVM>>>
    {
        #region Constructor
        private readonly IUserRepository _userRepository;
        public GetUserListQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        #endregion
        public async Task<ApiResponse<List<GetUserResponseVM>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var data = await _userRepository
                                   .FetchIQueryableEntity()
                                   .Select(x => new GetUserResponseVM
                                   {
                                       FirstName = x.FirstName,
                                       LastName = x.LastName,
                                       UserImage = x.UserImage,
                                       NationalCode = x.NationalCode,
                                       PersonalCode = x.PersonalCode,
                                       UserType = x.UserType,
                                       Gender = x.Gender
                                   })
                                   .ToListAsync(cancellationToken);

            return new ApiResponse<List<GetUserResponseVM>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
