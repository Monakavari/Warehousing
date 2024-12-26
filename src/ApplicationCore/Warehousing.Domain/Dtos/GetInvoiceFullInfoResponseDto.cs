using System;
using Warehousing.Common.Enums;

namespace Warehousing.Domain.Dtos
{
    public class GetInvoiceFullInfoResponseDto
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int TotalInvoicePrice { get; set; }
        public string CustomerName { get; set; }
        public string CustomerTel { get; set; }
        public string CustomerAddress { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceType { get; set; }
        public int FiscalYearId { get; set; }
        public string InvoiceStatus { get; set; }
        public DateTime ReturnInvoiceDateTime { get; set; }
    }
}
