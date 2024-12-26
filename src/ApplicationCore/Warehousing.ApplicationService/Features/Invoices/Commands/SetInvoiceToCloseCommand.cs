using MediatR;
using Warehousing.Common;
using Warehousing.Common.DTOs;

namespace Warehousing.ApplicationService.Features.Invoices.Commands
{
    public class SetInvoiceToCloseCommand :IRequest<ApiResponse>
    {
        public int InvoiceId { get; set; }
        public int FiscalYearId { get; set; }
        public string UserId { get; set; }
        public List<InvoiceProductDto> InvoiceProducts { get; set; }
    }
}
