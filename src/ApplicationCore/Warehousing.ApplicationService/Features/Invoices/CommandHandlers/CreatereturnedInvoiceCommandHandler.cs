using Warehousing.ApplicationService.Services.Contracts;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using Warehousing.DataAccess.EF.Repository;
using Warehousing.Common.Enums;
using Warehousing.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Warehousing.Domain.Freamwork.Extensions;
using Warehousing.ApplicationService.Features.Invoices.Commands.Create;

namespace Warehousing.ApplicationService.Features.Invoices.CommandHandlers
{
    public class CreatereturnedInvoiceCommandHandler : MediatR.IRequestHandler<CreateReturnedInvoiceCommand, ApiResponse>
    {
        #region Constructor
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        private readonly IUnitOfWork _unitOfWork;
        public CreatereturnedInvoiceCommandHandler(IInvoiceRepository invoiceRepository,
                                                   IUnitOfWork unitOfWork,
                                                   IInventoryRepository inventoryRepository)
        {
            _invoiceRepository = invoiceRepository;
            _inventoryRepository = inventoryRepository;
            _userId = _httpContextAccessor.GetUserId();
            _unitOfWork = unitOfWork;
        }
        #endregion Constructor
        public async Task<ApiResponse> Handle(CreateReturnedInvoiceCommand request, CancellationToken cancellationToken)
        {
            if (request.InvoiceId == 0)
                throw new AppException("اینویس مورد نظر را انتخاب کنید.");

            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            var getReturnedInvoice = _invoiceRepository.GetById(request.InvoiceId);
            getReturnedInvoice.InvoiceType = Common.Enums.InvoiceType.Returned;
            getReturnedInvoice.ReturnrdInvoiceDateTime = DateTime.Now;
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            List<Warehousing.Domain.Entities.Inventory> getSoldProductTochangeThemAsReturned = await _inventoryRepository.GetInventorySoldProductsRecords(request.InvoiceId, cancellationToken);

            foreach (var item in getSoldProductTochangeThemAsReturned)
            {
                var inventory = new Warehousing.Domain.Entities.Inventory()
                {
                    OperationDate = DateTime.Now,
                    OperationType = OperationTypeStatus.Returned,
                    Description = "مرجوعی",
                    FiscalYearId = request.FiscalYearId,
                    InvoiceId = request.InvoiceId,
                    CreatorUserId = _userId,
                    ExpireDate = item.ExpireDate,
                    RefferenceId = item.RefferenceId,
                    WarehouseId = item.WarehouseId,
                    ProductLocationId = item.ProductLocationId,
                    MainProductCount = item.MainProductCount,
                    ProductId = item.ProductId
                };

                await _inventoryRepository.AddAsync(inventory, cancellationToken);
            }
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _unitOfWork.TransactionCommit(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
