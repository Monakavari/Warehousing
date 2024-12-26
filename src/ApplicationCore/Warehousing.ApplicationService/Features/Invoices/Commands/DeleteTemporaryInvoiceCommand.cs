using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Invoices.Commands
{
    public class DeleteTemporaryInvoiceCommand :IRequest<ApiResponse>
    {
        public int InvoiceId { get; set; }
    }
}
