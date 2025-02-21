using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.DataAccess.EF.Context;
using Warehousing.DataAccess.EF.Repositories.Base;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;

namespace Warehousing.DataAccess.EF.Repository
{
    public class ProductLocationRepository : BaseRepository<ProductLocation>, IProductLocationRepository
    {
        #region Constructor

        private readonly WarehousingDbContext _dbContext;
        public ProductLocationRepository(WarehousingDbContext context) : base(context)
        {
            _dbContext = context;
        }
        #endregion Constructor
        public async Task<bool> IsExistProductLocationAddress(string productLocationAddress, int warehouseId, CancellationToken cancellationToken)
        {
            return await _dbContext.ProductLocations
                                          .Where(x => x.ProductLocationAddress == productLocationAddress ||
                                                      x.WarehouseId == warehouseId)
                                          .AnyAsync(cancellationToken);
        }
        public async Task<List<GetDropDownListResponseDto>> ProductLocationListDropDown(int warehouseId, CancellationToken cancellationToken)
        {
            return await _dbContext.ProductLocations
                                          .Where(x => x.WarehouseId == warehouseId)
                                          .Select(x => new GetDropDownListResponseDto
                                          {
                                              Id = x.Id,
                                              Name = x.ProductLocationAddress
                                          })
                                          .ToListAsync(cancellationToken);
        }
        public async Task<int> GetProductLocationId(int warehouseId, CancellationToken cancellationToken)
        {
            return await _dbContext.ProductLocations
                                         .Where(p => p.ProductLocationAddress.Contains("عمومی") &&
                                                     p.WarehouseId == warehouseId)
                                         .Select(s => s.Id)
                                         .SingleOrDefaultAsync(cancellationToken);
        }
        public async Task<ProductLocationResponseDto> GetProductLocationById(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.ProductLocations
                                           .Where(p => p.Id == id)
                                           .Select(y => new ProductLocationResponseDto
                                           {
                                               WareHouseId = y.WarehouseId,
                                               ProductLocationAddress = y.ProductLocationAddress,
                                               ProductLocationId = y.Id
                                           })
                                           .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
