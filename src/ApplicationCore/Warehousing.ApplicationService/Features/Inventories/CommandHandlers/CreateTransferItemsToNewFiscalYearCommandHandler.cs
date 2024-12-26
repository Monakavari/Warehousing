using Warehousing.ApplicationService.Features.Inventories.Commands.Create;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using Warehousing.Common.Enums;

namespace Warehousing.ApplicationService.Features.Inventories.CommandHandlers
{
    public class CreateTransferItemsToNewFiscalYearCommandHandler : MediatR.IRequestHandler<TransferItemsToNewFiscalYearRequestCommand, ApiResponse>
    {
        #region Constructor
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IFiscalYearRepository _fiscalYearRepository;
        private readonly IProductLocationRepository _productLocationRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateTransferItemsToNewFiscalYearCommandHandler(IInventoryRepository inventoryRepository,
                                                                IUnitOfWork unitOfWork,
                                                                IFiscalYearRepository fiscalYearRepository,
                                                                IProductLocationRepository productLocationRepository)
        {
            _inventoryRepository = inventoryRepository;
            _unitOfWork = unitOfWork;
            _fiscalYearRepository = fiscalYearRepository;
            _productLocationRepository = productLocationRepository;
        }
        #endregion

        public async Task<ApiResponse> Handle(TransferItemsToNewFiscalYearRequestCommand request, CancellationToken cancellationToken)
        {
            var data = _inventoryRepository.TransferToNewFiscalYear(new CloseFiscalYearDto 
            {
                FiscalYearId = request.FiscalYearId,
                UserId = request.UserId,
                WarehouseId = request.WarehouseId,
            
            }, cancellationToken);

            var lastEndDate = await _fiscalYearRepository.GetLastEndDate(cancellationToken);
            var currentFiscal = await _fiscalYearRepository.GetCurrentFiscalYear(request.FiscalYearId, cancellationToken);
            currentFiscal.FiscalFlag = false;
            
            var newFiscal = await _fiscalYearRepository.GetCurrentFiscalYear(request.FiscalYearId, cancellationToken);
            newFiscal.FiscalFlag = true;

            foreach (var item in data)
            {
                var inventory = new Warehousing.Domain.Entities.Inventory()
                {
                    OperationType = OperationTypeStatus.TransferFromNewFiscalYear,
                    Description = "اسناد انتقالی سال مالی",
                    InvoiceId = 0,
                    OperationDate = DateTime.Now,
                    ProductId = item.ProductId,
                    MainProductCount = item.TotalProductCount,
                    ExpireDate = item.ExpireDate,
                    RefferenceId = 0,
                    CreatorUserId = request.UserId,
                    WarehouseId = request.WarehouseId,
                    WastageProductCount = 0,
                    ProductLocationId = await _productLocationRepository.GetProductLocationId(request.WarehouseId, cancellationToken),
                    FiscalYearId = newFiscal.Id
                };

                await _inventoryRepository.AddAsync(inventory, cancellationToken);
            }
                await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
