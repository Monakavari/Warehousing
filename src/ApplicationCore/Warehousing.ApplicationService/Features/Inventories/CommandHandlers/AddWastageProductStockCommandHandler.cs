using Warehousing.ApplicationService.Features.Inventory.Commands.Create;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common.Enums;
using Warehousing.Common.Utilities.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Http;
using Warehousing.Domain.Freamwork.Extensions;

namespace Warehousing.ApplicationService.Features.Inventory.CommandHandlers
{
    public class AddWastageProductStockCommandHandler : MediatR.IRequestHandler<AddWastageProductStockCommand, ApiResponse>
    {
        #region Constructor
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        public AddWastageProductStockCommandHandler(IInventoryRepository inventoryRepository,
                                                    IUnitOfWork unitOfWork)
        {
            _inventoryRepository = inventoryRepository;
            _userId = _httpContextAccessor.GetUserId();
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(AddWastageProductStockCommand request, CancellationToken cancellationToken)
        {
            //for register wastage must check <main> stock warehouse count
            if (await _inventoryRepository.GetPhysicalStockForEachBranch(request.WastageInvRefferenceId, cancellationToken) < request.WastageProductCount)
                throw new AppException("موجودی انبار کمتر از تعداد درخواستی میباشد.");

            var getParentInfo = await _inventoryRepository.GetParentInfo(request.WastageInvRefferenceId, cancellationToken);
            var inventory = new Warehousing.Domain.Entities.Inventory
            {
                ProductId = request.WastageProductId,
                WarehouseId = request.WastageWarehouseId,
                FiscalYearId = request.WastageFiscalYearId,
                WastageProductCount = request.WastageProductCount,
                MainProductCount = 0,
                ExpireDate = getParentInfo.ExpireDate,
                Description = request.WastageDescription,
                RefferenceId = request.WastageInvRefferenceId, // InventoryId
                OperationType = OperationTypeStatus.EnterToWastageWarehouse,
                OperationDate = PersianDate.ToMiladi(request.WastageOperationDate),
                ProductLocationId = getParentInfo.ProductLocationId,
                CreatorUserId = _userId
            };
            await _inventoryRepository.AddAsync(inventory, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
