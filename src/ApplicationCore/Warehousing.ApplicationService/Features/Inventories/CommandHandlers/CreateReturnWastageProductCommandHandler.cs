using Warehousing.ApplicationService.Features.Inventories.Commands.Create;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using Warehousing.ApplicationService.VariableProfiles;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Warehousing.Common.Enums;
using Warehousing.Common.Utilities.Extensions;
using Microsoft.AspNetCore.Http;
using Warehousing.Domain.Freamwork.Extensions;

namespace Warehousing.ApplicationService.Features.Inventories.CommandHandlers
{
    public class CreateReturnWastageProductCommandHandler : MediatR.IRequestHandler<CreateReturnedWastageProductCommand, ApiResponse>
    {
        #region Constructor
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        public CreateReturnWastageProductCommandHandler(IInventoryRepository inventoryRepository,
                                                        IUnitOfWork unitOfWork)
        {
            _inventoryRepository = inventoryRepository;
            _userId = _httpContextAccessor.GetUserId();
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(CreateReturnedWastageProductCommand request, CancellationToken cancellationToken)
        {
            if (await _inventoryRepository.GetPhysicalWastageStockForEachBranch(request.ReturnedWastageInvRefferenceId, cancellationToken) < request.ReturnedWastageProductCount)
                throw new AppException("موجودی انبار کمتر از تعداد درخواستی میباشد.");

            var getParentInfo = await _inventoryRepository.GetParentInfo(request.ReturnedWastageInvRefferenceId, cancellationToken);
            var inventory = new Warehousing.Domain.Entities.Inventory
            {
                ProductId = request.ReturnedWastageProductId,
                WarehouseId = request.ReturnedWastageWarehouseId,
                FiscalYearId = request.ReturnedWastageFiscalYearId,
                MainProductCount = 0,
                WastageProductCount = request.ReturnedWastageProductCount,
                ExpireDate = getParentInfo.ExpireDate,
                Description = request.ReturnedWastageDescription,
                RefferenceId = request.ReturnedWastageInvRefferenceId,
                OperationType = OperationTypeStatus.ExitFromWastageWarehouse,
                OperationDate = PersianDate.ToMiladi(request.ReturnedWastageOperationDate),
                ProductLocationId = getParentInfo.ProductLocationId,
                CreatorUserId = _userId
            };
            await _inventoryRepository.AddAsync(inventory, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
