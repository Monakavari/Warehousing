using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Warehousing.ApplicationService.ViewModels;

namespace Warehousing.Domain.Repository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<bool> IsExistCustomerName(string customerName, string economicCode, CancellationToken cancellationToken);
        Task<List<GetDropDownListResponseDto>> CustomerListDropDown(int warehouseId, CancellationToken cancellationToken);
    }
}
