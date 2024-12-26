using MediatR;
using Warehousing.Common;
using Warehousing.Domain.Dtos;

namespace Warehousing.ApplicationService.Features.Invoices.Queries
{
    public class GetProductItemInfoDetailQuery :IRequest<ApiResponse<GetProductItemInfoResponseDto>>
    {
        public int WarehouseId { get; set; }
        public int FiscalYearId { get; set; }
        public string ProductCode { get; set; }
    }
}
