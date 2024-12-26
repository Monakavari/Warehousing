using Microsoft.EntityFrameworkCore.Storage;
using Warehousing.DataAccess.EF.Context;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.DataAccess.EF.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Constractor

        public UnitOfWork(WarehousingDbContext context)
        {
            Context = context;
        }

        private WarehousingDbContext Context { get; }
        private bool _disposed = false;

        #endregion Constractor

        #region Transaction

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await Context.SaveChangesAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken)
        {
            await Context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task TransactionCommit(CancellationToken cancellationToken)
        {
            await Context.Database.CommitTransactionAsync(cancellationToken);
        }

        public async Task TransactionRollback(CancellationToken cancellationToken)
        {
            await Context.Database.RollbackTransactionAsync(cancellationToken);
        }

        #endregion Transaction

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion Dispose
    }
}
