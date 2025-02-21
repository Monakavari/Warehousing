using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading;
using Warehousing.Common;
using Warehousing.Common.DTOs;
using Warehousing.Common.Enums;
using Warehousing.Common.Utilities.Extensions;
using Warehousing.DataAccess.EF.Context;
using Warehousing.DataAccess.EF.Repositories.Base;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;

namespace Warehousing.DataAccess.EF.Repository
{
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        #region Constructor
        private readonly WarehousingDbContext _dbContext;
        public InvoiceRepository(WarehousingDbContext context) : base(context)
        {
            _dbContext = context;
        }
        #endregion Constructor
        public string CreateInvoiceNo()
        {
            string invoiceNo = "1";
            if (_dbContext.Invoices.Count() > 0)
            {
                invoiceNo = _dbContext.Invoices
                             .OrderByDescending(x => x.Id)
                             .Select(x => x.Id)
                             .First() + 1 + "";
            }

            return invoiceNo;
        }
        public async Task<GetProductItemInfoResponseDto> GetProductItemInfo(GetProductItemInfoRequestDto request, CancellationToken cancellationToken)
        {
            var data = await _dbContext.Products
                                     .Where(p => p.ProductCode == request.ProductCode)
                                     .Include(p => p.Inventories
                                        .Where(i => i.ProductId == p.Id &&
                                                    i.WarehouseId == request.WarehouseId))
                                     .Include(p => p.ProductPrices
                                        .Where(pp => pp.ProductId == p.Id &&
                                                     pp.ActionDate <= DateTime.Now)
                                                                             )
                                     .Select(p => new GetProductItemInfoResponseDto
                                     {
                                         ProductId = p.Id,
                                         ProductName = p.ProductName,
                                         ProductStock = ProductStockSum(p.Inventories),
                                         CoverPrice = p.ProductPrices.OrderByDescending(pp => pp.ActionDate)
                                                                     .Take(1)
                                                                     .DefaultIfEmpty()
                                                                     .Select(x => x.CoverPrice)
                                                                     .SingleOrDefault(),
                                         PurchasePrice = p.ProductPrices.OrderByDescending(pp => pp.ActionDate)
                                                                     .Take(1)
                                                                     .DefaultIfEmpty()
                                                                     .Select(x => x.PurchasePrice)
                                                                     .SingleOrDefault(),
                                         SalesPrice = p.ProductPrices.OrderByDescending(pp => pp.ActionDate)
                                                                     .Take(1)
                                                                     .DefaultIfEmpty()
                                                                     .Select(x => x.SalesPrice)
                                                                     .SingleOrDefault(),
                                         TotalRowPrice = request.ProductRequestedCount * (p.ProductPrices.OrderByDescending(pp => pp.ActionDate)
                                                                     .Take(1)
                                                                     .DefaultIfEmpty()
                                                                     .Select(x => x.SalesPrice)
                                                                     .SingleOrDefault())
                                     }).SingleOrDefaultAsync(cancellationToken);
            return data;
        }
        private int ProductStockSum(ICollection<Inventory> inventories)
        {
            return inventories.Sum(s => s.OperationType == OperationTypeStatus.EnterToMainWarehouse ? s.MainProductCount :
                                          s.OperationType == OperationTypeStatus.ExitFromMainWarehouse ? -s.MainProductCount :
                                          s.OperationType == OperationTypeStatus.EnterToWastageWarehouse ? -s.WastageProductCount :
                                          s.OperationType == OperationTypeStatus.ExitFromWastageWarehouse ? -s.WastageProductCount :
                                          s.OperationType == OperationTypeStatus.Returned ? s.MainProductCount :
                                          s.OperationType == OperationTypeStatus.Sold ? -s.MainProductCount :
                                          s.OperationType == OperationTypeStatus.IncreasingBalance ? s.MainProductCount :
                                          s.OperationType == OperationTypeStatus.DecreasingBalance ? -s.MainProductCount :
                                          s.OperationType == OperationTypeStatus.TransferFromNewFiscalYear ? s.MainProductCount : 0);
        }
        public async Task<List<GetInvoiceFullInfoResponseDto>> GetSoldAndReturnedInvoiceListForAnyWarehouse(GetInvoiceFullInfoRequestDto request, CancellationToken cancellationToken)
        {
            var qurey = await _dbContext.Invoices
                                            .Where(x => x.WarehouseId == request.WarehouseId &&
                                                        x.FiscalYearId == request.FiscalYearId &&
                                                        (PersianDate.ToMiladi(request.FromDate) >= x.CreateDate.Date &&
                                                         PersianDate.ToMiladi(request.ToDate) <= x.CreateDate.Date))
                                            .Select(s => new GetInvoiceFullInfoResponseDto
                                            {
                                                FiscalYearId = s.FiscalYearId,
                                                CustomerAddress = s.Customer.CustomerAddress,
                                                CustomerId = s.CustomerId,
                                                CustomerName = s.Customer.CustomerName,
                                                CustomerTel = s.Customer.CustomerTel,
                                                InvoiceDate = s.CreateDate,
                                                InvoiceId = s.Id,
                                                InvoiceNo = s.InvoiceNo,
                                                InvoiceStatus = StringExtentions.GetDisplayValue(s.InvoiceStatus),
                                                InvoiceType = StringExtentions.GetDisplayValue(s.InvoiceType),
                                                TotalInvoicePrice = s.InvoiceTotalPrice,
                                                ReturnInvoiceDateTime = (DateTime)(s.ReturnrdInvoiceDateTime == null ?
                                                                         DateTime.MinValue : s.ReturnrdInvoiceDateTime)
                                            })
                                            .OrderByDescending(x => x.InvoiceId)
                                            .ToListAsync(cancellationToken);
            return qurey;
        }
        public async Task<DateTime> GetInvoiceDate(int invoiceId, CancellationToken cancellationToken)
        {
            return await _dbContext.Invoices
                                             .Where(x => x.Id == invoiceId)
                                             .Select(x => x.CreateDate.Date)
                                             .SingleOrDefaultAsync(cancellationToken);


        }
        public async Task<GetDetailPrintResponseDto> GetInvoiceDetailListInfoForPrint(int invoiceId, CancellationToken cancellationToken)
        {
            return await _dbContext.Invoices
                                       .Where(x => x.Id == invoiceId)
                                       .Select(y => new GetDetailPrintResponseDto
                                       {
                                           CustomerAddress = y.Customer.CustomerAddress,
                                           CustomerName = y.Customer.CustomerName,
                                           CustomerTel = y.Customer.CustomerTel,
                                           InvoiceId = y.Id,
                                           InvoiceNo = y.InvoiceNo,
                                           InvoiceTotalPrice = y.InvoiceTotalPrice,
                                           InvoiceDate = y.CreateDate,
                                           ItemList = _dbContext.InvoiceItems
                                                                    .Where(x => x.InvoiceId == invoiceId)
                                                                    .Select(y => new InvoiceItemForPrintDto
                                                                    {
                                                                        ProductCount = y.ProductCount,
                                                                        ProductId = y.ProductId,
                                                                        ProductCode = y.Product.ProductCode,
                                                                        ProductName = y.Product.ProductName
                                                                    })
                                                                    .ToList()

                                       })
                                       .SingleOrDefaultAsync(cancellationToken);


        }
        public async Task<List<GetAllInvoicedProductResponseDto>> GetAllInvoicedProduct(GetAllInvoicedProductRequestDto request, CancellationToken cancellationToken)
        {
            return await _dbContext.Inventories
                                              .Where(x => x.WarehouseId == request.WarehouseId &&
                                                          x.FiscalYearId == request.FiscalYearId &&
                                                          x.OperationDate <= PersianDate.ToMiladi(request.FromDate) &&
                                                          x.OperationDate >= PersianDate.ToMiladi(request.ToDate) &&
                                                          x.OperationType == OperationTypeStatus.Sold)
                                              .GroupBy(y => new { y.ProductId, y.Product.ProductName, y.Product.ProductCode, y.ExpireDate })
                                              .Select(z => new GetAllInvoicedProductResponseDto
                                              {
                                                  ExpireDate = z.Key.ExpireDate,
                                                  ProductCode = z.Key.ProductCode,
                                                  ProductName = z.Key.ProductName,
                                                  ProductId = z.Key.ProductId,
                                                  ProductCount = z.Sum(p => p.MainProductCount)
                                              })
                                              .ToListAsync(cancellationToken);
        }
        public async Task<List<ItemReportOfAnyInvoiceResponseDto>> GetSeparatedInvoiceItemsReportListForPacking(ItemReportOfAnyInvoiceRequestDto request, CancellationToken cancellationToken)
        {
            return await _dbContext.InvoiceItems
                                      .Where(x => x.Invoice.WarehouseId == request.WarehouseId &&
                                                  x.Invoice.FiscalYearId == request.FiscalYearId &&
                                                  x.CreateDate <= PersianDate.ToMiladi(request.FromDate) &&
                                                  x.CreateDate >= PersianDate.ToMiladi(request.ToDate))
                                      // .GroupBy(s => new {s.ProductId,s.Product.ProductName,s.InvoiceId,s.Invoice.InvoiceNo,s.ProductCount })
                                      .Select(y => new ItemReportOfAnyInvoiceResponseDto
                                      {
                                          InvoiceId = y.InvoiceId,
                                          invoiceNo = y.Invoice.InvoiceNo,
                                          ProductCount = y.ProductCount,
                                          ProductId = y.ProductId,
                                          ProductName = y.Product.ProductName,
                                      })
                                      .ToListAsync(cancellationToken);
        }
    }
}
