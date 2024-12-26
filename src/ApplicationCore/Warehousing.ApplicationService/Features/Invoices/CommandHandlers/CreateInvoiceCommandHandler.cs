using Warehousing.ApplicationService.Features.Invoices.Commands;
using Warehousing.ApplicationService.Services.Contracts;
using Warehousing.Common;
using Warehousing.Common.DTOs;
using Warehousing.Common.Enums;
using Warehousing.Common.Utilities.Extensions;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.Invoices.CommandHandlers
{
    public class CreateInvoiceCommandHandler : MediatR.IRequestHandler<CreateInvoiceCommand, ApiResponse>
    {
        #region Constructor
        private readonly ICalculationService _calculationService;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IProductRepository _productRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateInvoiceCommandHandler(ICalculationService calculationService,
                                           IInvoiceRepository invoiceRepository,
                                           IUnitOfWork unitOfWork,
                                           IInventoryRepository inventoryRepository,
                                           IProductRepository productRepository)
        {
            _calculationService = calculationService;
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
            _inventoryRepository = inventoryRepository;
            _productRepository = productRepository;
        }
        #endregion Constructor
        public async Task<ApiResponse> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var productStocksList = await _inventoryRepository
                    .GetProductStocks(new GetProductStocks
                    {
                        FiscalYearId = request.FiscalYearId,
                        WarehouseId = request.WarehouseId,
                        ProductIds = request.InvoiceProducts.Select(x => x.ProductId).ToList()
                    }, cancellationToken);

            foreach (var item in request.InvoiceProducts)
            {
                var stock = productStocksList.Find(c => c.ProductId == item.ProductId);
                if (stock is not null && stock.ProductCount < item.ProductCount)
                {
                    var orginalProduct = _productRepository.GetById(item.ProductId).ProductName;
                    throw new AppException($"موجودی کالای {orginalProduct},{item.ProductCount}میباشد");
                }
            }

            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            var invoice = new Invoice()
            {
                CreatorUserId = "0",
                CustomerId = request.CustomerId,
                InvoiceType = InvoiceType.Sold,
                InvoiceStatus = request.InvoiceStatus,
                WarehouseId = request.WarehouseId,
                InvoiceTotalPrice = _calculationService.CalculateInvoicePrice(request.InvoiceProducts),
                InvoiceNo = PersianDate.ToShamsi(DateTime.Now).Replace("/", "") + _invoiceRepository.CreateInvoiceNo(),
                InvoiceItems = MappingInvoiceItem(request)
            };

            await _invoiceRepository.AddAsync(invoice, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (request.InvoiceStatus == InvoiceStatus.Close)
            {
                //کسر از موجودی
                await _inventoryRepository.GetProductFromBranch(new GetProductFromBranchDto
                {
                    FiscalYearId = request.FiscalYearId,
                    WarehouseId = request.WarehouseId,
                    InvoiceId = invoice.Id,
                    UserId = "0",
                    InvoiceProducts = MappingInvoiceProducts(request),
                }, cancellationToken);
            }
            await _unitOfWork.SaveChangesAsync(cancellationToken);
           await _unitOfWork.TransactionCommit(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
        private List<InvoiceItem> MappingInvoiceItem(CreateInvoiceCommand request)
        {
            var result = new List<InvoiceItem>();

            foreach (var item in request.InvoiceProducts)
            {
                
                result.Add(new InvoiceItem
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
        private List<InvoiceProductDto> MappingInvoiceProducts(CreateInvoiceCommand request)
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


