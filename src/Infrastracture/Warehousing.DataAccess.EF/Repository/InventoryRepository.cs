using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common.Enums;
using Warehousing.Common.Utilities.Extensions;
using Warehousing.DataAccess.EF.Context;
using Warehousing.DataAccess.EF.Repositories.Base;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.DataAccess.EF.Repository
{
    public class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
    {
        #region Constructor

        private readonly WarehousingDbContext _dbContext;
        public InventoryRepository(WarehousingDbContext context) : base(context)
        {
            _dbContext = context;
        }
        #endregion Constructor

        public async Task<Inventory> GetParentInfo(int referenceId, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Inventories
                                           .Where(x => x.Id == referenceId)
                                           .SingleOrDefaultAsync(cancellationToken);
            return result;
        }
        public async Task<List<GetProductStockResponseDto>> GetProductStockOfMainWarehouse(int warehouseId, int fiscalYearId, CancellationToken cancellationToken)

        {
            return await _dbContext.Products
                                     .Include(c => c.Inventories
                                                      .Where(i => i.WarehouseId == warehouseId &&
                                                                  i.FiscalYearId == fiscalYearId))
                                     .Select(x => new GetProductStockResponseDto
                                     {
                                         ProductId = x.Id,
                                         ProductCode = x.ProductCode,
                                         ProductName = x.ProductName,
                                         TotalProductCount = x.Inventories
                                                                 .Sum(s => s.OperationType == OperationTypeStatus.EnterToMainWarehouse ? s.MainProductCount :
                                                                           s.OperationType == OperationTypeStatus.ExitFromMainWarehouse ? -s.MainProductCount :
                                                                           s.OperationType == OperationTypeStatus.EnterToWastageWarehouse ? s.WastageProductCount :
                                                                           s.OperationType == OperationTypeStatus.ExitFromWastageWarehouse ? -s.WastageProductCount :
                                                                           s.OperationType == OperationTypeStatus.Returned ? s.MainProductCount :
                                                                           s.OperationType == OperationTypeStatus.Sold ? -s.MainProductCount :
                                                                           s.OperationType == OperationTypeStatus.IncreasingBalance ? s.MainProductCount :
                                                                           s.OperationType == OperationTypeStatus.DecreasingBalance ? -s.MainProductCount :
                                                                           s.OperationType == OperationTypeStatus.TransferFromNewFiscalYear ? s.MainProductCount : 0),

                                         TotalProductWaste = x.Inventories
                                                                  .Where(x => x.WastageProductCount > 0)
                                                                  .Sum(s => s.OperationType == OperationTypeStatus.EnterToWastageWarehouse ? s.WastageProductCount :
                                                                            s.OperationType == OperationTypeStatus.ExitFromWastageWarehouse ? -s.WastageProductCount : 0)

                                     })
                                     .ToListAsync(cancellationToken);
        }
        public async Task<List<GetDropDownListResponseDto>> GetWastageProductExpireDateForDropDown(GetProductExpireDateRequestForDropDown request, CancellationToken cancellationToken)
        {
            var getExpireList = await _dbContext.Inventories
                                         .Where(x => x.WarehouseId == request.WarehouseId &&
                                                     x.FiscalYearId == request.FiscalYearId &&
                                                     x.ProductId == request.ProductId &&
                                                     x.OperationType == OperationTypeStatus.EnterToWastageWarehouse)
                                        .Select(x => new GetDropDownListResponseDto
                                        {
                                            Id = x.Id, // inventoryId
                                            Name = PersianDate.ToShamsi(x.ExpireDate),

                                        })
                                        .ToListAsync(cancellationToken);

            var ZeroStock = new List<int>();
            foreach (var item in getExpireList)
            {
                if (await GetPhysicalWastageStockForEachBranch(item.Id, cancellationToken) == 0)
                    ZeroStock.Add(item.Id);
            }

            return getExpireList.Where(c => !ZeroStock.Contains(c.Id)).ToList();
        }
        public async Task<List<GetDropDownListResponseDto>> GetProductExpireDateForDropDown(GetProductExpireDateRequestForDropDown request, CancellationToken cancellationToken)
        {
            var getExpireList = await _dbContext.Inventories
                                       .Where(x => x.ProductId == request.ProductId &&
                                                   x.WarehouseId == request.WarehouseId &&
                                                   x.FiscalYearId == request.FiscalYearId &&
                                                   x.OperationType == OperationTypeStatus.EnterToMainWarehouse ||
                                                   x.OperationType == OperationTypeStatus.TransferFromNewFiscalYear)
                                                   .Select(x => new GetDropDownListResponseDto
                                                   {
                                                       Id = x.Id,
                                                       Name = PersianDate.ToShamsi(x.ExpireDate)
                                                   })
                                                   .ToListAsync(cancellationToken);

            var zeroStock = new List<int>();
            foreach (var item in getExpireList)
            {
                if (await GetPhysicalStockForEachBranch(item.Id, cancellationToken) == 0)
                {
                    zeroStock.Add(item.Id);
                }
            }

            return getExpireList
                           .Where(c => !zeroStock.Contains(c.Id))
                           .ToList();
        }
        public async Task<int> GetPhysicalStockForEachBranch(int inventoryId, CancellationToken cancellationToken)
        {
            var getStock = await _dbContext.Inventories
                                            .Where(x => x.Id == inventoryId ||
                                                        x.RefferenceId == inventoryId)
                                            .Select(x => x.Id)
                                            .ToListAsync(cancellationToken);
            return await _dbContext.Inventories
                                            .Where(e => getStock.Contains(e.Id) || e.Id == inventoryId)
                                            .SumAsync(s => s.OperationType == OperationTypeStatus.EnterToMainWarehouse ? s.MainProductCount :
                                                           s.OperationType == OperationTypeStatus.ExitFromMainWarehouse ? -s.MainProductCount :
                                                           s.OperationType == OperationTypeStatus.EnterToWastageWarehouse ? -s.WastageProductCount :
                                                           s.OperationType == OperationTypeStatus.ExitFromWastageWarehouse ? -s.WastageProductCount :
                                                           s.OperationType == OperationTypeStatus.Returned ? s.MainProductCount :
                                                           s.OperationType == OperationTypeStatus.Sold ? -s.MainProductCount :
                                                           s.OperationType == OperationTypeStatus.DecreasingBalance ? -s.MainProductCount :
                                                           s.OperationType == OperationTypeStatus.IncreasingBalance ? s.MainProductCount : 
                                                           s.OperationType == OperationTypeStatus.TransferFromNewFiscalYear ? s.MainProductCount : 0, cancellationToken);
        }
        public async Task<GetPhysicalStockAndLocationResponseDto> GetPhysicalStockAndLocationForEachBranch(int inventoryId, CancellationToken cancellationToken)
        {
            var physicalStockCount = await GetPhysicalStockForEachBranch(inventoryId, cancellationToken);

            var productLocation = await _dbContext.Inventories
                                                        .Where(c => c.Id == inventoryId)
                                                        .Include(x => x.ProductLocation)
                                                        .Select(x => x.ProductLocation)
                                                        .FirstOrDefaultAsync(cancellationToken);

            return new GetPhysicalStockAndLocationResponseDto
            {
                StockCount = physicalStockCount,
                ProductLocationAddress = productLocation?.ProductLocationAddress,
                ProductLocationId = productLocation?.Id
            };
        }
        public async Task<int> GetPhysicalWastageStockForEachBranch(int inventoryId, CancellationToken cancellationToken)
        {
            return await _dbContext.Inventories
                                            .Where(x => x.Id == inventoryId ||
                                                        x.RefferenceId == x.Id) //InventoryId
                                            .SumAsync(s => s.OperationType == OperationTypeStatus.EnterToWastageWarehouse ? s.WastageProductCount :
                                                           s.OperationType == OperationTypeStatus.ExitFromWastageWarehouse ? -s.WastageProductCount :
                                                           0, cancellationToken);

        }
        public async Task<List<GetProductStocksDto>> GetProductStocks(GetProductStocks request, CancellationToken cancellationToken)
        {
            var result = new List<GetProductStocksDto>();

            var inventories = await _dbContext.Inventories
                                                 .Where(i => request.ProductIds.Contains(i.ProductId) &&
                                                             i.FiscalYearId == request.FiscalYearId &&
                                                             i.WarehouseId == request.WarehouseId)
                                                 .ToListAsync(cancellationToken);

            result.AddRange(inventories
                    .Select(c => new GetProductStocksDto
                    {
                        ProductId = c.ProductId,
                        ProductCount = inventories
                            .Where(x => x.ProductId == c.ProductId)
                            .Sum(s => s.OperationType == OperationTypeStatus.EnterToMainWarehouse ? s.MainProductCount :
                                      s.OperationType == OperationTypeStatus.Returned ? s.MainProductCount :
                                      s.OperationType == OperationTypeStatus.EnterToWastageWarehouse ? -s.WastageProductCount :
                                      s.OperationType == OperationTypeStatus.ExitFromWastageWarehouse ? s.WastageProductCount :
                                      s.OperationType == OperationTypeStatus.ExitFromMainWarehouse ? -s.MainProductCount :
                                      s.OperationType == OperationTypeStatus.Sold ? -s.MainProductCount :
                                      s.OperationType == OperationTypeStatus.IncreasingBalance ? s.MainProductCount :
                                      s.OperationType == OperationTypeStatus.DecreasingBalance ? -s.MainProductCount :
                                      s.OperationType == OperationTypeStatus.TransferFromNewFiscalYear ? s.MainProductCount : 0)
                    }));

            return result;
        }
        public async Task GetProductFromBranch(GetProductFromBranchDto request, CancellationToken cancellationToken)
        {
            var expireDateList = await _dbContext.Inventories
                                               .Where(x => request.InvoiceProducts
                                               .Select(y => y.ProductId)
                                               .Contains(x.ProductId) &&
                                                         x.WarehouseId == request.WarehouseId &&
                                                         x.FiscalYearId == request.FiscalYearId &&
                                                        (x.OperationType == OperationTypeStatus.EnterToMainWarehouse ||
                                                         x.OperationType == OperationTypeStatus.TransferFromNewFiscalYear))
                                               .OrderBy(x => x.ExpireDate)
                                               .ToListAsync(cancellationToken);

            List<int> zeroStocks = new List<int>();
            foreach (var item in expireDateList)
            {
                if (await GetPhysicalStockForEachBranch(item.Id, cancellationToken) == 0)
                {
                    zeroStocks.Add(item.Id);
                }
            }
            // مشخص کردن همه سری انقضاهای دارای موجودی بر اساس تاریخ انقضای نزدیکتر
            var expireDateListWithStock = expireDateList.Where(x => !zeroStocks.Contains(x.Id)).ToList();
            int savedStock = request.InvoiceProducts.Select(x => x.ProductCount).SingleOrDefault();

            foreach (var item in expireDateListWithStock)
            {
                var getBranchStock = await GetPhysicalStockForEachBranch(item.Id, cancellationToken);

                if (savedStock <= getBranchStock)
                {
                    var inventory = new Inventory()
                    {
                        Description = "فروش",
                        OperationType = OperationTypeStatus.Sold,
                        OperationDate = DateTime.Now,
                        FiscalYearId = item.FiscalYearId,
                        WarehouseId = item.WarehouseId,
                        InvoiceId = item.InvoiceId,
                        CreatorUserId = "0",
                        WastageProductCount = 0,
                        MainProductCount = savedStock,
                        ProductId = item.ProductId,
                        ExpireDate = item.ExpireDate,
                        RefferenceId = item.Id,
                        ProductLocationId = await _dbContext.Inventories
                                                                  .Where(i => i.Id == item.Id)
                                                                  .Select(s => s.ProductLocation.Id)
                                                                  .SingleAsync(cancellationToken)
                    };
                    await _dbContext.Inventories.AddAsync(inventory, cancellationToken);
                    break;
                }
                else if (savedStock > getBranchStock)
                {
                    savedStock -= getBranchStock;
                    var inventory = new Inventory()
                    {
                        Description = "فروش",
                        OperationType = OperationTypeStatus.Sold,
                        OperationDate = DateTime.Now,
                        FiscalYearId = item.FiscalYearId,
                        WarehouseId = item.WarehouseId,
                        InvoiceId = item.InvoiceId,
                        CreatorUserId = "0",
                        WastageProductCount = 0,
                        MainProductCount = getBranchStock,
                        ProductId = item.ProductId,
                        ExpireDate = item.ExpireDate,
                        RefferenceId = item.Id,
                        ProductLocationId = await _dbContext.Inventories
                                                                 .Where(i => i.Id == item.Id)
                                                                 .Select(s => s.ProductLocation.Id)
                                                                 .SingleAsync(cancellationToken)
                    };
                    await _dbContext.Inventories.AddAsync(inventory, cancellationToken);
                }
            }
        }
        public async Task<List<Inventory>> GetInventorySoldProductsRecords(int invoiceId, CancellationToken cancellationToken)
        {
            return await _dbContext.Inventories
                                        .Where(x => x.InvoiceId == invoiceId)
                                        .ToListAsync(cancellationToken);
        }
        public async Task<List<ProductListExpireOrientedResponseDto>> GetProductListExpireOriented(ProductListExpireOrientedRequestDto request, CancellationToken cancellationToken)
        { 
            var expireDataList = await _dbContext.Inventories
                                                       .Where(x => x.WarehouseId == request.WarehouseId &&
                                                                   x.FiscalYearId == request.FiscalYearId &&
                                                                   x.OperationType == OperationTypeStatus.EnterToMainWarehouse ||     //Has no reference
                                                                   x.OperationType == OperationTypeStatus.TransferFromNewFiscalYear) //Has no reference
                                                       .OrderBy(x => x.ExpireDate)
                                                       .GroupBy(y => new { y.ProductId, y.Product.ProductName, y.Product.ProductCode, y.ExpireDate, y.Id })
                                                       .Select(z => new ProductListExpireOrientedResponseForPhysicalStockDto
                                                       {
                                                           ExpireDate = z.Key.ExpireDate,
                                                           ProductCode = z.Key.ProductCode,
                                                           ProductName = z.Key.ProductName,
                                                           ProductId = z.Key.ProductId,
                                                           InventoryId = z.Key.Id
                                                           //TotalProductCount = GetPhysicalStockForEachBranch(z.Key.InvoiceId, cancellationToken)
                                                       }).ToListAsync(cancellationToken);
            var zeroStock = new List<int>();
            foreach (var item in expireDataList)
            {
                if (await GetPhysicalStockForEachBranch(item.InventoryId, cancellationToken) == 0)
                {
                    zeroStock.Add(item.InventoryId);
                }
            }

            var result = expireDataList
                               .Where(e => !zeroStock.Contains(e.InventoryId))
                               .GroupBy(y => new { y.ProductId, y.ProductName, y.ProductCode, y.ExpireDate })
                               .Select(z => new ProductListExpireOrientedResponseDto
                               {
                                   ExpireDate = z.Key.ExpireDate,
                                   ProductCode = z.Key.ProductCode,
                                   ProductName = z.Key.ProductName,
                                   ProductId = z.Key.ProductId,
                                   TotalProductCount = z.Sum(e => e.TotalProductCount)
                               }).ToList();
            return result;
        }
        public async Task<List<TransferToNewFiscalYearDto>> TransferToNewFiscalYear(CloseFiscalYearDto request, CancellationToken cancellationToken)
        {

            var expireDataList = await _dbContext.Inventories
                                                       .Where(x => x.WarehouseId == request.WarehouseId &&
                                                                   x.FiscalYearId == request.FiscalYearId &&
                                                                   x.OperationType == OperationTypeStatus.EnterToMainWarehouse ||
                                                                   x.OperationType == OperationTypeStatus.TransferFromNewFiscalYear)
                                                       .OrderBy(x => x.ExpireDate)
                                                       .GroupBy(y => new { y.ProductId, y.ExpireDate, y.Id })
                                                       .Select(z => new TransferToNewFiscalYearDto
                                                       {
                                                           ExpireDate = z.Key.ExpireDate,
                                                           InventoryId = z.Key.Id,
                                                           ProductId = z.Key.ProductId,
                                                         //TotalProductCount = GetPhysicalStockForEachBranch(z.Key.InvoiceId, cancellationToken)
                                                       }).ToListAsync(cancellationToken);
            var zeroStock = new List<int>();
            foreach (var item in expireDataList)
            {
                if (await GetPhysicalStockForEachBranch(item.InventoryId, cancellationToken) == 0)
                {
                    zeroStock.Add(item.InventoryId);
                }
            }

             return expireDataList
                            .Where(e => !zeroStock.Contains(e.InventoryId))
                            .GroupBy(y => new { y.ProductId, y.ExpireDate })
                            .Select(z => new TransferToNewFiscalYearDto
                            {
                                ExpireDate = z.Key.ExpireDate,
                                ProductId = z.Key.ProductId,
                                TotalProductCount = z.Sum(e => e.TotalProductCount)
                            }).ToList();

          

            //var newFiscalYearId = await _dbContext.FiscalYears
            //                                              .Where(x => x.FiscalFlag == false &&
            //                                                          x.StartDate > lastEnddate.Date)
            //                                              .Select (x => x.Id)
            //                                              .SingleOrDefaultAsync (cancellationToken);

            
            //oldFiscal.FiscalFlag = false;
            //this._dbContext.FiscalYears.Update(oldFiscal);

            //var newFiscal = await _dbContext.FiscalYears
            //                                        .Where(x => x.Id == newFiscalYearId)
            //                                        .SingleOrDefaultAsync(cancellationToken);
            //newFiscal.FiscalFlag = true;
            //this._dbContext.FiscalYears.Update(newFiscal);

        }
    }
}

