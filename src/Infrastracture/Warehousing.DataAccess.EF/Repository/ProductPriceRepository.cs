using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using Warehousing.Common.Utilities.Extensions;
using Warehousing.DataAccess.EF.Context;
using Warehousing.DataAccess.EF.Repositories.Base;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;

namespace Warehousing.DataAccess.EF.Repository
{
    public class ProductPriceRepository : BaseRepository<ProductPrice>, IProductPriceRepository
    {
        #region Constructor

        private readonly WarehousingDbContext _dbContext;
        public ProductPriceRepository(WarehousingDbContext context) : base(context)
        {
            _dbContext = context;
        }
        #endregion Constructor
        public async Task<bool> GetProductPrice(int productId, CancellationToken cancellationToken)
        {
            return await _dbContext.ProductPrices
                                       .Where(x => x.ProductId == productId &&
                                                   x.ActionDate >= DateTime.Now)
                                       .AnyAsync(cancellationToken);
        }
        public async Task<List<GetProductPriceResponseDto>> GetProductPriceList( CancellationToken cancellationToken)
        {
            var productPriceList = _dbContext.ProductPrices
                                                      .Where(x => x.ActionDate >= DateTime.Now)
                                                      .OrderByDescending(x => x.ActionDate)
                                                      .Take(1)
                                                      .AsEnumerable();

            return await _dbContext.Products
                                     .Select(x => new GetProductPriceResponseDto
                                     {
                                         ProductId = x.Id,
                                         ProductName = x.ProductName,
                                         ProductCode = x.ProductCode,
                                         CoverPrice = productPriceList
                                                            .Where(y => y.ProductId == x.Id)
                                                            .Select(x => x.CoverPrice)
                                                            .DefaultIfEmpty()
                                                            .SingleOrDefault(),

                                         PurchasePrice = productPriceList
                                                            .Where(y => y.ProductId == x.Id)
                                                            .Select(x => x.PurchasePrice)
                                                            .DefaultIfEmpty()
                                                            .SingleOrDefault(),

                                         SalesPrice = productPriceList
                                                            .Where(y => y.ProductId == x.Id)
                                                            .Select(x => x.SalesPrice)
                                                            .DefaultIfEmpty()
                                                            .SingleOrDefault(),

                                         ProductPriceId = productPriceList
                                                            .Where(y => y.ProductId == x.Id)
                                                            .Select(x => x.Id)
                                                            .DefaultIfEmpty()
                                                            .SingleOrDefault(),

                                         ActionDate = productPriceList
                                                            .Where(y => y.ProductId == x.Id)
                                                            .Select(x => PersianDate.ToShamsi(x.ActionDate))
                                                            .DefaultIfEmpty()
                                                            .SingleOrDefault(),

                                     }).ToListAsync(cancellationToken);

        }
        public async Task<List<GetProductPriceResponseDto>> GetProductPriceHistoryList(int productId, CancellationToken cancellationToken)
        {
            return await _dbContext.ProductPrices
                                        .Where(x => x.ProductId == productId)
                                        .Select(x => new GetProductPriceResponseDto
                                        {
                                            ActionDate = PersianDate.ToShamsi(x.ActionDate),
                                            CoverPrice = x.CoverPrice,
                                            FiscalYearId = x.FiscalYearId,
                                            ProductCode = x.Product.ProductCode,
                                            ProductName = x.Product.ProductName,
                                            ProductPriceId = x.Id,
                                            PurchasePrice = x.PurchasePrice,
                                            SalesPrice = x.SalesPrice
                                        })
                                        .ToListAsync(cancellationToken);
        }
        public async Task<bool> HasNotActionDateArrived(CancellationToken cancellationToken)
        {
            return await _dbContext.ProductPrices
                                               .Where(x => x.ActionDate.Date >= DateTime.Now.Date)
                                               .AnyAsync(cancellationToken);

        }
        public int GetSalesPrice(int productId)
        {
            int productSales =  _dbContext.ProductPrices
                                             .Where(p => p.ActionDate <= DateTime.Now &&
                                                         p.ProductId == productId)
                                             .OrderByDescending(o => o.ActionDate)
                                             .Take(1)
                                             .Select(s => s.SalesPrice)
                                             .DefaultIfEmpty()
                                             .Single();

            return productSales;
        }
        public int GetPurchasePrice(int productId)
        {
            int purchasePrice = _dbContext.ProductPrices
                                             .Where(p => p.ActionDate <= DateTime.Now &&
                                                         p.ProductId == productId)
                                             .OrderByDescending(o => o.ActionDate)
                                             .Take(1)
                                             .Select(s => s.PurchasePrice)
                                             .DefaultIfEmpty()
                                             .Single();

            return purchasePrice;
        }
        public int GetCoverPrice(int productId)
        {
            int coverPrice = _dbContext.ProductPrices
                                             .Where(p => p.ActionDate <= DateTime.Now &&
                                                         p.ProductId == productId)
                                             .OrderByDescending(o => o.ActionDate)
                                             .Take(1)
                                             .Select(s => s.CoverPrice)
                                             .DefaultIfEmpty()
                                             .Single();

            return coverPrice;
        }
    }
}
