using MediatR;
using Warehousing.Common;
using Warehousing.Domain.Dtos;

namespace Warehousing.ApplicationService.Features.Invoices.Queries
{
    public class GetInvoiceItemsForPrintQuery : IRequest<ApiResponse<GetDetailPrintResponseDto>>
    {
        public int InvoiceId { get; set; }
    }
}
