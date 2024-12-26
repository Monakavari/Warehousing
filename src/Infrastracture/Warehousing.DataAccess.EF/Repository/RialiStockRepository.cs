using Microsoft.EntityFrameworkCore;
using System.Linq;
using Warehousing.Common.Enums;
using Warehousing.DataAccess.EF.Context;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;

namespace Warehousing.DataAccess.EF.Repository
{
    public class RialiStockRepository : IRialiStockRepository
    {
        #region Constructor
        private readonly WarehousingDbContext _context;
        public RialiStockRepository(WarehousingDbContext context)
        {
            _context = context;
        }
        #endregion Constructor
        public async Task<List<GetMainRialiStockResponseDto>> GetMainRialiStock(int fiscalYearId, int warehouseId, CancellationToken cancellationToken)
        {
            //لیست همه قیمت ها
            var productPriceList = GetProductPriceList();
            //لیست همه تراکنش ها
            var stockList = GetProductStockList(fiscalYearId, warehouseId);

            return await _context.Products
                                    .Select(p => new GetMainRialiStockResponseDto
                                    {
                                        ProductId = p.Id,
                                        ProductName = p.ProductName,
                                        ProductCode = p.ProductCode,
                                        TotalPurchasePrice = GetTotalPurchasePrice(productPriceList, stockList, p.Id),
                                        TotalCoverPrice = GetTotalCoverPrice(productPriceList, stockList, p.Id),
                                        TotalSalePrice = GetTotalSalePrice(productPriceList, stockList, p.Id),
                                        TotalProductCount = GetTotalProductCount(stockList, p.Id)

                                    })
                                     .ToListAsync(cancellationToken);
        }
        public async Task<List<GetWastageRialiStockResponseDto>> GetWastageRialiStock(int fiscalYearId, int warehouseId, CancellationToken cancellationToken)
        {
            //لیست همه قیمت ها
            var wastageProductPriceList = GetProductPriceList();
            //لیست همه تراکنش ها
            var wastageStockList = GetWastageProductStockList(fiscalYearId, warehouseId);

            return await _context.Products
                                    .Select(p => new GetWastageRialiStockResponseDto
                                    {
                                        WastageProductId = p.Id,
                                        WastageProductName = p.ProductName,
                                        WastageProductCode = p.ProductCode,
                                        TotalWastagePurchasePrice = GetTotalPurchasePrice(wastageProductPriceList, wastageStockList, p.Id),
                                        TotalWastageCoverPrice = GetTotalCoverPrice(wastageProductPriceList, wastageStockList, p.Id),
                                        TotalWastageSalePrice = GetTotalSalePrice(wastageProductPriceList, wastageStockList, p.Id),
                                        TotalWastageProductCount = GetTotalProductCount(wastageStockList, p.Id)

                                    })
                                     .ToListAsync(cancellationToken);
        }

        private IQueryable<ProductPrice> GetProductPriceList()
        {
            return _context.ProductPrices
                        .Where(x => x.ActionDate <= DateTime.Now)
                        .OrderByDescending(o => o.ActionDate)
                        .AsQueryable();
        }
        private IQueryable<Inventory> GetProductStockList(int fiscalYearId, int warehouseId)
        {
            return _context.Inventories
                        .Where(i => i.FiscalYearId == fiscalYearId &&
                                    i.WarehouseId == warehouseId)
                        .AsQueryable();
        }
        private IQueryable<Inventory> GetWastageProductStockList(int fiscalYearId, int warehouseId)
        {
            return _context.Inventories
                        .Where(i => i.FiscalYearId == fiscalYearId &&
                                    i.WarehouseId == warehouseId &&
                                    i.OperationType == OperationTypeStatus.EnterToWastageWarehouse ||
                                    i.OperationType == OperationTypeStatus.ExitFromWastageWarehouse)
                        .AsQueryable();
        }
        public int GetTotalPurchasePrice(IQueryable<ProductPrice> productPriceList, IQueryable<Inventory> stockList, int productId)
        {
            return (productPriceList.Where(purchase => purchase.ProductId == productId)
                                    .Take(1)
                                    .Select(s => s.PurchasePrice)
                                    .DefaultIfEmpty()
                                    .Single())
                 * (stockList.Where(s => s.ProductId == productId)
                             .Sum(s => s.OperationType == OperationTypeStatus.EnterToMainWarehouse ? s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.ExitFromMainWarehouse ? -s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.EnterToWastageWarehouse ? -s.WastageProductCount :
                                       s.OperationType == OperationTypeStatus.ExitFromWastageWarehouse ? -s.WastageProductCount :
                                       s.OperationType == OperationTypeStatus.Returned ? s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.Sold ? -s.MainProductCount : 
                                       s.OperationType == OperationTypeStatus.IncreasingBalance ? s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.DecreasingBalance ? -s.MainProductCount:
                                       s.OperationType == OperationTypeStatus.TransferFromNewFiscalYear ? s.MainProductCount : 0));

        }
        public int GetTotalCoverPrice(IQueryable<ProductPrice> pricePriceList, IQueryable<Inventory> stockList, int productId)
        {
            return
                (pricePriceList.Where(purchase => purchase.ProductId == productId)
                        .Take(1)
                        .Select(s => s.CoverPrice)
                        .DefaultIfEmpty()
                        .Single())
                        *
                 (stockList.Where(s => s.ProductId == productId)
                           .Sum(s => s.OperationType == OperationTypeStatus.EnterToMainWarehouse ? s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.ExitFromMainWarehouse ? -s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.EnterToWastageWarehouse ? -s.WastageProductCount :
                                       s.OperationType == OperationTypeStatus.ExitFromWastageWarehouse ? -s.WastageProductCount :
                                       s.OperationType == OperationTypeStatus.Returned ? s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.Sold ? -s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.IncreasingBalance ? s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.DecreasingBalance ? -s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.TransferFromNewFiscalYear ? s.MainProductCount : 0));

        }
        public int GetTotalSalePrice(IQueryable<ProductPrice> pricePriceList, IQueryable<Inventory> stockList, int productId)
        {
            return (pricePriceList.Where(purchase => purchase.ProductId == productId)
                                  .Take(1)
                                  .Select(s => s.SalesPrice)
                                  .DefaultIfEmpty()
                                  .Single())
                 * (stockList.Where(s => s.ProductId == productId)
                            .Sum(s => s.OperationType == OperationTypeStatus.EnterToMainWarehouse ? s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.ExitFromMainWarehouse ? -s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.EnterToWastageWarehouse ? -s.WastageProductCount :
                                       s.OperationType == OperationTypeStatus.ExitFromWastageWarehouse ? -s.WastageProductCount :
                                       s.OperationType == OperationTypeStatus.Returned ? s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.Sold ? -s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.IncreasingBalance ? s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.DecreasingBalance ? -s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.TransferFromNewFiscalYear ? s.MainProductCount : 0));

        }
        private int GetTotalProductCount(IQueryable<Inventory> stockList, int productId)
        {
            return stockList.Where(s => s.ProductId == productId)
                            .Sum(s => s.OperationType == OperationTypeStatus.EnterToMainWarehouse ? s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.ExitFromMainWarehouse ? -s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.EnterToWastageWarehouse ? -s.WastageProductCount :
                                       s.OperationType == OperationTypeStatus.ExitFromWastageWarehouse ? -s.WastageProductCount :
                                       s.OperationType == OperationTypeStatus.Returned ? s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.Sold ? -s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.IncreasingBalance ? s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.DecreasingBalance ? -s.MainProductCount :
                                       s.OperationType == OperationTypeStatus.TransferFromNewFiscalYear ? s.MainProductCount : 0);

        }
    }
}
