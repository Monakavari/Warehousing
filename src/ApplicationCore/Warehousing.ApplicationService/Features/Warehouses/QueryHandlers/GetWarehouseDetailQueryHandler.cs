using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using MediatR;
using Warehousing.ApplicationService.ViewModels;
using Azure.Core;
using System.Threading;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.DataAccess.EF.Repository;
using Warehousing.ApplicationService.Features.Warehouse.Queries;

namespace Warehousing.ApplicationService.Features.Warehouse.QueryHandlers
{
    public class GetWarehouseDetailQueryHandler : MediatR.IRequestHandler<GetWarehouseDetailQuery, ApiResponse<GetWarehouseResponseVM>>
    {
        #region Constructor
        private readonly IWarehouseRepository _warehouseRepository;
        public GetWarehouseDetailQueryHandler(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        #endregion
        public async Task<ApiResponse<GetWarehouseResponseVM>> Handle(GetWarehouseDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _warehouseRepository.GetByIdAsync(request.Id, cancellationToken);
            var mapper = WarehouseProfile.Map(entity);

            return new ApiResponse<GetWarehouseResponseVM>(true, ApiResponseStatusCode.Success, mapper, "عملیات با موفقیت انجام شد");
        }
    }
}
