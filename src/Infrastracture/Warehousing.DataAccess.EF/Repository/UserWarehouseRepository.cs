using Microsoft.EntityFrameworkCore;
using Warehousing.DataAccess.EF.Context;
using Warehousing.DataAccess.EF.Repositories.Base;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;

namespace Warehousing.DataAccess.EF.Repository
{
    public class UserWarehouseRepository : BaseRepository<UserWarehouse>, IUserWarehouseRepository
    {
        #region Constructor

        private readonly WarehousingDbContext _dbContext;
        public UserWarehouseRepository(WarehousingDbContext context) : base(context)
        {
            _dbContext = context;
        }
        #endregion Constructor
        public async Task<List<int>> UserWarehouseList(int userWarehouseId, CancellationToken cancellationToken)
        {
            return await _dbContext.UserWarehouses
                                          .Where(x => x.Id == userWarehouseId)
                                          .Select(x => x.WarehouseId)
                                          .ToListAsync(cancellationToken);
        }
        public async Task<List<string>> GetUserIdInWarehouseList(string userId, CancellationToken cancellationToken)
        {
            return await _dbContext.UserWarehouses
                                          .Where(x => x.UserIdInWarehouse == userId)
                                          .Select(x => x.UserIdInWarehouse)
                                          .ToListAsync(cancellationToken);
        }
    }
}
