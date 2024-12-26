using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.Domain.Repository
{
    public interface IProductPriceRepository : IBaseRepository<ProductPrice>
    {
        Task<bool> GetProductPrice(int productId, CancellationToken cancellationToken);
        Task<List<GetProductPriceResponseDto>> GetProductPriceList(CancellationToken cancellationToken);
        Task<List<GetProductPriceResponseDto>> GetProductPriceHistoryList(int productId, CancellationToken cancellationToken);
        Task<bool> HasNotActionDateArrived(CancellationToken cancellationToken);
        int GetSalesPrice(int productId);
    }
}
