using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Entities;

namespace Warehousing.Domain.Repository
{
    public interface IRialiStockRepository
    {
        Task<List<GetMainRialiStockResponseDto>> GetMainRialiStock(int fiscalYearId, int warehouseId, CancellationToken cancellationToken);
        Task<List<GetWastageRialiStockResponseDto>> GetWastageRialiStock(int fiscalYearId, int warehouseId, CancellationToken cancellationToken);
        int GetTotalPurchasePrice(IQueryable<ProductPrice> productPriceList, IQueryable<Inventory> stockList, int productId);
        int GetTotalCoverPrice(IQueryable<ProductPrice> pricePriceList, IQueryable<Inventory> stockList, int productId);
        int GetTotalSalePrice(IQueryable<ProductPrice> pricePriceList, IQueryable<Inventory> stockList, int productId);
    }
}
