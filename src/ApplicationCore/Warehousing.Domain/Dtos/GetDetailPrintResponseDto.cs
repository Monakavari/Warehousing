using System.Collections.Generic;
using System;
using Warehousing.Common.DTOs;

namespace Warehousing.Domain.Dtos
{
    public class GetDetailPrintResponseDto
    {
        public int InvoiceId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerTel { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int InvoiceTotalPrice { get; set; }
        public List<InvoiceItemForPrintDto> ItemList { get; set; }
    }
}
