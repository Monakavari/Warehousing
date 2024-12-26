using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Invoices.Commands
{
    public class CreateReturnedInvoiceCommand :IRequest<ApiResponse>
    {
        public int InvoiceId { get; set; }
        public string UserId { get; set; }
        public int FiscalYearId { get; set; }
    }
}
