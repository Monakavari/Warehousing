using MediatR;
using Warehousing.Common;
using Warehousing.Domain.Dtos;

namespace Warehousing.ApplicationService.Features.Invoices.Queries
{
    public class GetItemReportOfAnyInvoiceListQuery :IRequest<ApiResponse<List<ItemReportOfAnyInvoiceResponseDto>>>
    {
        public int WarehouseId { get; set; }
        public int FiscalYearId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
