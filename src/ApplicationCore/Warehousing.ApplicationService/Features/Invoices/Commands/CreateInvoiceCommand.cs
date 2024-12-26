using MediatR;
using System.ComponentModel.DataAnnotations;
using Warehousing.Common;
using Warehousing.Common.DTOs;
using Warehousing.Common.Enums;

namespace Warehousing.ApplicationService.Features.Invoices.Commands
{
    public class CreateInvoiceCommand : IRequest<ApiResponse>
    {
        public int WarehouseId { get; set; }
        public int FiscalYearId { get; set; }
        public int CustomerId { get; set; }
        public List<InvoiceProductDto> InvoiceProducts { get; set; }
        //public InvoiceType InvoiceType { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
       // public int InvoiceTotalPrice { get; set; }

    }
}
