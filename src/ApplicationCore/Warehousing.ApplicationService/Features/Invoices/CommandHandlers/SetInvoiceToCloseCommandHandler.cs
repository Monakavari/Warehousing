using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Dtos;
using Warehousing.Common.DTOs;
using Microsoft.AspNetCore.Http;
using Warehousing.Domain.Freamwork.Extensions;
using Warehousing.ApplicationService.Features.Invoices.Commands.Create;
using Warehousing.ApplicationService.Services.Contracts;

namespace Warehousing.ApplicationService.Features.Invoices.CommandHandlers
{
    public class SetInvoiceToCloseCommandHandler : MediatR.IRequestHandler<SetInvoiceToCloseCommand, ApiResponse>
    {
        #region Constructor
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ICalculationService _calculationService;
        private readonly IInvoiceItemRepository _invoiceItemRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        private readonly IUnitOfWork _unitOfWork;
        public SetInvoiceToCloseCommandHandler(IInvoiceRepository invoiceRepository,
                                               IUnitOfWork unitOfWork,
                                               IInventoryRepository inventoryRepository,
                                               IInvoiceItemRepository invoiceItemRepository,
                                               ICalculationService calculationService)
        {
            _invoiceRepository = invoiceRepository;
            _inventoryRepository = inventoryRepository;
            _userId = _httpContextAccessor.GetUserId();
            _unitOfWork = unitOfWork;
            _invoiceItemRepository = invoiceItemRepository;
            _calculationService = calculationService;
        }
        #endregion Constructor
        public async Task<ApiResponse> Handle(SetInvoiceToCloseCommand request, CancellationToken cancellationToken)
        {
            if (request.InvoiceId == 0)
                   throw new AppException("فاکتور مورد نظر را انتخاب کنید.");

            if (await _invoiceRepository.GetInvoiceDate(request.InvoiceId, cancellationToken) > DateTime.Now.Date)
                   throw new AppException("فاکتور موقت فقط تا پایان روز صدور قابل نهایی شدن است.");

            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            //1= Set InvoiceStatus To Close
            var getOpenInvoice = _invoiceRepository.GetById(request.InvoiceId);
            getOpenInvoice.InvoiceStatus = Common.Enums.InvoiceStatus.Close;
            getOpenInvoice.ReturnrdInvoiceDateTime = DateTime.Now;
            getOpenInvoice.ModifierUserId = _userId;
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            //2= Inventory Operation
            var getproductInfoFromInvoiceItem = await _invoiceItemRepository.GetInvoiceItemForRegisterInventoryOperation(request.InvoiceId, cancellationToken);
            foreach (var item in getproductInfoFromInvoiceItem)
            {
                await _inventoryRepository.GetProductFromBranch(new GetProductFromBranchDto
                {
                    FiscalYearId = request.FiscalYearId,
                    UserId = request.UserId,
                    InvoiceId = request.InvoiceId,
                    WarehouseId = getOpenInvoice.WarehouseId,
                    InvoiceProducts = MappingInvoiceProducts(request),
                }, cancellationToken);
            }
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _unitOfWork.TransactionCommit(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
        private List<InvoiceProductDto> MappingInvoiceProducts(SetInvoiceToCloseCommand request)
        {
            var result = new List<InvoiceProductDto>();

            foreach (var item in request.InvoiceProducts)
            {
                result.Add(new InvoiceProductDto
                {
                    ProductCount = item.ProductCount,
                    ProductId = item.ProductId,
                    InvoiceId = item.InvoiceId,
                    CreatorUserId = item.CreatorUserId,
                    CoverPrice = 0,
                    SalePrice = 0,
                    PurchasePrice = 0,
                });
            }
            return result;
        }
    }
}
