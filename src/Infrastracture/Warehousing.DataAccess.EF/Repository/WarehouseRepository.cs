using Microsoft.EntityFrameworkCore;
using System.Linq;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.DataAccess.EF.Context;
using Warehousing.DataAccess.EF.Repositories.Base;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;

namespace Warehousing.DataAccess.EF.Repository
{
    public class WarehouseRepository : BaseRepository<Warehouse>, IWarehouseRepository
    {
        #region Constructor

        private readonly WarehousingDbContext _dbContext;
        public WarehouseRepository(WarehousingDbContext context) : base(context)
        {
            _dbContext = context;
        }
        #endregion Constructor

        public async Task<bool> IsExistWarehouseName(string warehouseName, CancellationToken cancellationToken)
        {
            return await _dbContext.Warehouses
                                       .Where(x => x.WarehouseName == warehouseName)
                                       .AnyAsync(cancellationToken);
        }
        public async Task<List<GetDropDownListResponseDto>> WarehouseListDropDown(CancellationToken cancellationToken)
        {
            return await _dbContext.Warehouses
                                        .Select(x => new GetDropDownListResponseDto
                                        {
                                            Id = x.Id,
                                            Name = x.WarehouseName
                                        })
                                        .ToListAsync(cancellationToken);
        }
        public async Task<List<GetDropDownListResponseDto>> WarehouseUserOrientedListDropDown(string UserIdInWarehouse, CancellationToken cancellationToken)
        {
            //لیست انبارهایی که کاربر دسترسی دارد  
            var userWarehouseIdList = await _dbContext.UserWarehouses
                                                        .Where(w => w.UserIdInWarehouse == UserIdInWarehouse)
                                                        .Select(w => w.WarehouseId)
                                                        .ToListAsync(cancellationToken);
            return await _dbContext.Warehouses
                                        .Where(u => userWarehouseIdList
                                        .Contains(u.Id))
                                        .Select(x => new GetDropDownListResponseDto
                                        {
                                            Id = x.Id,
                                            Name = x.WarehouseName
                                        })
                                        .ToListAsync(cancellationToken);
        }
    }
}

