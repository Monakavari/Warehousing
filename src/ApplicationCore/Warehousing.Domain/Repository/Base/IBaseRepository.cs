using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Warehousing.Domain.Repository.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FetchIQueryableEntity();

        TEntity GetById(int id);
        TEntity GetByStringId(string id);
        Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<TEntity> GetByIdAsync(string id, CancellationToken cancellationToken);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task AddRangeAsync(IList<TEntity> entity, CancellationToken cancellationToken);
        void DeleteEntity(TEntity entity);
        void DeleteRange(IList<int> ids);
        void DeleteRange(IList<string> ids);
        void DeleteById(int id);
        void DeleteById(string id);

        //void LogicalDelete(int id);

        //void Update(TEntity entity);
    }
}
