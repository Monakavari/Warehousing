using Microsoft.EntityFrameworkCore;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.DataAccess.EF.Context;
using Warehousing.DataAccess.EF.Repositories.Base;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;

namespace Warehousing.DataAccess.EF.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        #region Constructor

        private readonly WarehousingDbContext _dbContext;
        public ProductRepository(WarehousingDbContext context) : base(context)
        {
            _dbContext = context;
        }
        #endregion Constructor
        public async Task<bool> IsExistProductName(string productName, string productCode, CancellationToken cancellationToken)
        {
            return await _dbContext.Products
                                       .Where(x => x.ProductName == productName ||
                                                   x.ProductCode == productCode)
                                       .AnyAsync(cancellationToken);
        }
        public async Task<bool> IsExistProductCode(string productCode, CancellationToken cancellationToken)
        {
            return await _dbContext.Products
                                       .Where(x => x.ProductCode == productCode)
                                       .AnyAsync(cancellationToken);
        }
        public async Task<List<GetDropDownListResponseDto>> ProductListDropDown(CancellationToken cancellationToken)
        {
            return await _dbContext.Products
                                        .Select(x => new GetDropDownListResponseDto
                                        {
                                            Id = x.Id,
                                            Name = x.ProductName
                                        })
                                        .ToListAsync(cancellationToken);
        }
    }
}
