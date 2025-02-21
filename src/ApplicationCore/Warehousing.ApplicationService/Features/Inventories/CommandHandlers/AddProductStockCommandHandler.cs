using Microsoft.AspNetCore.Http;
using Warehousing.ApplicationService.Features.Inventory.Commands.Create;
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
    public class AddProductStockCommandHandler : MediatR.IRequestHandler<AddProductStockCommand, ApiResponse>
    {
        #region Constructor
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        public AddProductStockCommandHandler(IInventoryRepository inventoryRepository,
                                              IUnitOfWork unitOfWork)
        {
            _inventoryRepository = inventoryRepository;
            _userId = _httpContextAccessor.GetUserId();
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(AddProductStockCommand request, CancellationToken cancellationToken)
        {
            var operationTypeValue = (OperationTypeStatus)(request.AddBalanceStock == "on" ? OperationTypeStatus.IncreasingBalance :
                                                          (request.AddBalanceStock == null ||
                                                           request.AddBalanceStock == "") ? OperationTypeStatus.EnterToMainWarehouse : 0);

            //(byte)(model.BalanceStockAdd == "on" ? 7 : (model.BalanceStockAdd == "" || model.BalanceStockAdd == null) ? 1 : 0);
            var mapper = new Domain.Entities.Inventory
            {
                ProductId = request.ProductId,
                WarehouseId = request.WarehouseId,
                FiscalYearId = request.FiscalYearId,
                MainProductCount = request.MainProductCount,
                WastageProductCount = 0,
                ExpireDate = PersianDate.ToMiladi(request.ExpireDate),
                Description = request.Description,
                RefferenceId = 0,
                OperationType = operationTypeValue,
                OperationDate = PersianDate.ToMiladi(request.OperationDate),
                ProductLocationId = request.ProductLocationId,
                CreatorUserId = _userId
            };
            await _inventoryRepository.AddAsync(mapper, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
