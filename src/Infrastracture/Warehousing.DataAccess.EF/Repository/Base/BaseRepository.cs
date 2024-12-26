using Microsoft.EntityFrameworkCore;
using Warehousing.DataAccess.EF.Context;
using Warehousing.Domain.Entities.Base;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.DataAccess.EF.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        #region Constractor

        protected WarehousingDbContext Context { get; }
        private DbSet<TEntity> _table;
        public BaseRepository(WarehousingDbContext context)
        {
            Context = context;
        }

        #endregion Constractor

        public IQueryable<TEntity> FetchIQueryableEntity()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public TEntity GetById(int id)
        {
            var result = Context.Set<TEntity>().Find(id);

            return result;
        }
        public TEntity GetByStringId(string id)
        {
            var result = Context.Set<TEntity>().Find(id);

            return result;
        }

        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var result = await Context.Set<TEntity>().FindAsync(id, cancellationToken);

            return result;
        }
        public async Task<TEntity> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var result = await Context.Set<TEntity>().FindAsync(id, cancellationToken);

            return result;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            var result = await Context.AddAsync(entity, cancellationToken);

            return result.Entity;
        }

        public async Task AddRangeAsync(IList<TEntity> entities, CancellationToken cancellationToken)
        {
            await Context.AddRangeAsync(entities);
        }

        public void DeleteEntity(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
                _table.Attach(entity);

            Context.Remove(entity);
        }

        public void DeleteById(int id)
        {
            var entity = GetById(id);
            DeleteEntity(entity);
        }
        public void DeleteById(string id)
        {
            var entity = GetByStringId(id);
            DeleteEntity(entity);
        }

        public void DeleteRange(IList<int> ids)
        {
            Context.RemoveRange(ids);
        }
        public void DeleteRange(IList<string> ids)
        {
            Context.RemoveRange(ids);
        }
        public void Update(TEntity entity)
        {
            _table.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        //public void LogicalDelete(int id)
        //{
        //    var entity = this.GetById(id);
        //    entity.IsDelete = true;
        //    this.Update(entity);
        //}

        //public void Update(TEntity entity)
        //{
        //    entity.UpdateDate = DateTime.Now;
        //    Context.Update(entity);
        //}
    }
}
