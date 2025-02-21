using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.Domain.Repository
{
    public interface IProductLocationRepository: IBaseRepository<ProductLocation>
    {
        Task<bool> IsExistProductLocationAddress(string productLocationAddress,int warehouseId, CancellationToken cancellationToken);
        Task<List<GetDropDownListResponseDto>> ProductLocationListDropDown(int warehouseId, CancellationToken cancellationToken);
        Task<int> GetProductLocationId(int warehouseId, CancellationToken cancellationToken);
        Task<ProductLocationResponseDto> GetProductLocationById(int id, CancellationToken cancellationToken);
    }
}
