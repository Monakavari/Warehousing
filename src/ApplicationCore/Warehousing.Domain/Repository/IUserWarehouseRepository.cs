using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.Domain.Repository
{
    public interface IUserWarehouseRepository : IBaseRepository<UserWarehouse>
    {
        Task<List<int>> UserWarehouseList(int userWarehouseId, CancellationToken cancellationToken);
        Task<List<string>> GetUserIdInWarehouseList(string userId, CancellationToken cancellationToken);
    }
}
