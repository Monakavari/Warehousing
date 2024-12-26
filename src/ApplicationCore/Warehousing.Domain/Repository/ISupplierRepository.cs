using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.Domain.Repository
{
    public interface ISupplierRepository :IBaseRepository<Supplier>
    {
        Task<bool> IsExistSupplierName(string supplierName, CancellationToken cancellationToken);
        Task<List<GetDropDownListResponseDto>> SupplierListDropDown(CancellationToken cancellationToken);
    }
}
