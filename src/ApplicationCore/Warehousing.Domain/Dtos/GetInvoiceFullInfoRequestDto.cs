﻿namespace Warehousing.Domain.Dtos
{
    public class GetInvoiceFullInfoRequestDto
    {
        public int WarehouseId { get; set; }
        public int FiscalYearId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
