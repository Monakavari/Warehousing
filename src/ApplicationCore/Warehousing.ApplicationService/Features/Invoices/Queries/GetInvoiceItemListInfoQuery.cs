using MediatR;
using Warehousing.Common;
using Warehousing.Domain.Dtos;

namespace Warehousing.ApplicationService.Features.Invoices.Queries
{
    public class GetInvoiceItemListInfoQuery :IRequest<ApiResponse<List<InvoiceItemInfoResponseDto>>>
    {
        public int InvoiceId { get; set; }
    }
}
