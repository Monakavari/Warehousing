using System.Threading.Tasks;
using System.Threading;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Entities;
using System.Collections.Generic;
using Warehousing.ApplicationService.ViewModels;

namespace Warehousing.Domain.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<bool> IsExistProductName(string productName, string productCode, CancellationToken cancellationToken);
        Task<List<GetDropDownListResponseDto>> ProductListDropDown(CancellationToken cancellationToken);
        Task<bool> IsExistProductCode(string productCode, CancellationToken cancellationToken);
    }
}
