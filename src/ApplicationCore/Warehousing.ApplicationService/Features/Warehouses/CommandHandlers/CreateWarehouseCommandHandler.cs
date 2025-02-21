using Warehousing.ApplicationService.Features.Warehouse.Commands.Create;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Warehousing.Domain.Freamwork.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Warehousing.ApplicationService.Features.Warehouse.CommandHandlers
{
    public class CreateWarehouseCommandHandler : MediatR.IRequestHandler<CreateWarehouseCommand, ApiResponse>
    {
        #region Constructor
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        public CreateWarehouseCommandHandler(IWarehouseRepository warehouseRepository,
                                             IUnitOfWork unitOfWork)
        {
            _warehouseRepository = warehouseRepository;
            _userId = _httpContextAccessor.GetUserId();
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
        {
            if (await _warehouseRepository.IsExistWarehouseName(request.WarehouseName, cancellationToken))
                throw new AppException("عنوان نمی تواند تکراری باشد");

            var warehouse = new Warehousing.Domain.Entities.Warehouse
            {
                WarehouseName = request.WarehouseName,
                WarehouseAddress = request.WarehouseAddress,
                WarehouseTel = request.WarehouseTel
            };

            await _warehouseRepository.AddAsync(warehouse, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
