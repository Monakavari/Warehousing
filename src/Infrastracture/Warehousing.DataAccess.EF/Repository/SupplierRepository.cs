using Microsoft.EntityFrameworkCore;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.DataAccess.EF.Context;
using Warehousing.DataAccess.EF.Repositories.Base;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;

namespace Warehousing.DataAccess.EF.Repository
{
    public class SupplierRepository :BaseRepository<Supplier>,ISupplierRepository
    {
        #region Constructor

        private readonly WarehousingDbContext _dbContext;
        public SupplierRepository(WarehousingDbContext context) : base(context)
        {
            _dbContext = context;
        }
        #endregion Constructor

        public async Task<bool> IsExistSupplierName(string supplierName, CancellationToken cancellationToken)
        {
            return await _dbContext.Suppliers
                                       .Where(x => x.SupplierName == supplierName)
                                       .AnyAsync(cancellationToken);
        }
        public async Task<List<GetDropDownListResponseDto>> SupplierListDropDown(CancellationToken cancellationToken)
        {
            return await _dbContext.Suppliers
                                        .Select(x => new GetDropDownListResponseDto
                                        {
                                            Id = x.Id,
                                            Name = x.SupplierName
                                        })
                                        .ToListAsync(cancellationToken);
        }
    }
}
