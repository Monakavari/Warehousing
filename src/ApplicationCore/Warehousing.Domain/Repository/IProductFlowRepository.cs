using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Warehousing.Domain.Dtos;

namespace Warehousing.Domain.Repository
{
    public interface IProductFlowRepository
    {
        Task<List<GetProductFlowResponseDto>> GetProductFlow(ProductFlowRequestDto request, CancellationToken cancellationToken);
    }
}
