using Microsoft.AspNetCore.Http;
using Warehousing.ApplicationService.Features.Inventory.Commands.CreateExit;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Common.Enums;
using Warehousing.Common.Utilities.Extensions;
using Warehousing.Domain.Freamwork.Extensions;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Warehousing.ApplicationService.Features.Inventory.CommandHandlers
{
    public class CreateExitProductFromInventoryCommandHandler : MediatR.IRequestHandler<CreateExitProductFromInventoryCommand, ApiResponse>
    {
        #region Constructor
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        public CreateExitProductFromInventoryCommandHandler(IInventoryRepository inventoryRepository,
                                                            IUnitOfWork unitOfWork)
        {
            _inventoryRepository = inventoryRepository;
            _userId = _httpContextAccessor.GetUserId();
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(CreateExitProductFromInventoryCommand request, CancellationToken cancellationToken)
        {
            if (await _inventoryRepository.GetPhysicalStockForEachBranch(request.RefferenceInventoryId, cancellationToken) < request.MainProductCount)
                throw new AppException("موجودی انبار کمتر از تعداد درخواستی میباشد.");

            var getParentInfo = await _inventoryRepository.GetParentInfo(request.RefferenceInventoryId, cancellationToken);
            var operationTypeValue = (OperationTypeStatus)(request.BalanceStockRemove == "on" ? OperationTypeStatus.DecreasingBalance :
                                                          (request.BalanceStockRemove == null ||
                                                           request.BalanceStockRemove == "") ? OperationTypeStatus.ExitFromMainWarehouse : 0);

            var inventory = new Warehousing.Domain.Entities.Inventory
            {
                ProductId = request.ProductId,
                WarehouseId = request.WarehouseId,
                FiscalYearId = request.FiscalYearId,
                MainProductCount = request.MainProductCount,
                WastageProductCount = 0,
                ExpireDate = getParentInfo.ExpireDate,
                Description = request.Description,
                RefferenceId = request.RefferenceInventoryId,
                OperationType = operationTypeValue,
                OperationDate = PersianDate.ToMiladi(request.OperationDate),
                ProductLocationId = getParentInfo.ProductLocationId,
                CreatorUserId = _userId
            };
            await _inventoryRepository.AddAsync(inventory, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
