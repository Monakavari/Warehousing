using Microsoft.EntityFrameworkCore;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.DataAccess.EF.Context;
using Warehousing.DataAccess.EF.Repositories.Base;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;

namespace Warehousing.DataAccess.EF.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        #region Constructor

        private readonly WarehousingDbContext _dbContext;
        public CustomerRepository(WarehousingDbContext context) : base(context)
        {
            _dbContext = context;
        }
        #endregion Constructor
        public async Task<bool> IsExistCustomerName(string customerName, string economicCode, CancellationToken cancellationToken)
        {
            return await _dbContext.Customers
                                       .Where(x => x.CustomerName == customerName ||
                                                   x.EconomicCode == economicCode)
                                       .AnyAsync(cancellationToken);
        }
        public async Task<List<GetDropDownListResponseDto>> CustomerListDropDown(int warehouseId,CancellationToken cancellationToken)
        {
            return await _dbContext.Customers
                                        .Where(x=>x.WarehouseId== warehouseId) 
                                        .Select(x => new GetDropDownListResponseDto
                                        {
                                            Id = x.Id,
                                            Name = x.CustomerName
                                        })
                                        .ToListAsync(cancellationToken);
        }
    }
}
