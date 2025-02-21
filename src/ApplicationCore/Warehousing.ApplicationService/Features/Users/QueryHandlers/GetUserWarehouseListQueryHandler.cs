using MediatR;
using Warehousing.ApplicationService.Features.Users.Queries;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Warehousing.ApplicationService.Features.Users.QueryHandlers
{
    public class GetUserWarehouseListQueryHandler : IRequestHandler<GetUserWarehouseListQuery, ApiResponse<List<int>>>
    {
        #region Constructor
        private readonly IUserWarehouseRepository _UserWarehouseRepository;
        public GetUserWarehouseListQueryHandler(IUserWarehouseRepository userWarehouseRepository)
        {
            _UserWarehouseRepository = userWarehouseRepository;
        }
        #endregion
        public async Task<ApiResponse<List<int>>> Handle(GetUserWarehouseListQuery request, CancellationToken cancellationToken)
        {
            var data = await _UserWarehouseRepository.UserWarehouseList(request.UserWarehouseId, cancellationToken);
            return new ApiResponse<List<int>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
