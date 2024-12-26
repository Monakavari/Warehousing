using Microsoft.EntityFrameworkCore;
using Warehousing.ApplicationService.Features.Warehouse.Queries;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.Warehouse.QueryHandlers
{
    public class GetWarehouseListQueryHandler : MediatR.IRequestHandler<GetWarehouseListQuery,ApiResponse<List<GetWarehouseResponseVM>>>
    {
        #region Constructor
        private readonly IWarehouseRepository _warehouseRepository;
        public GetWarehouseListQueryHandler(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        #endregion
        public async Task<ApiResponse<List<GetWarehouseResponseVM>>> Handle(GetWarehouseListQuery request, CancellationToken cancellationToken)
        {
            var data = await _warehouseRepository
                                    .FetchIQueryableEntity()
                                    .Select(x => new GetWarehouseResponseVM
                                    {
                                        Id = x.Id,
                                        WarehouseName = x.WarehouseName,
                                        WarehouseAddress = x.WarehouseAddress,
                                        WarehouseTel = x.WarehouseTel
                                    })
                                    .ToListAsync(cancellationToken);

            return new ApiResponse<List<GetWarehouseResponseVM>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }

    }
}
