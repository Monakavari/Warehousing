namespace Warehousing.Domain.Dtos
{
    public class CreateReturnedInvoiceRequestDto
    {
        public int InvoiceId { get; set; }
        public string UserId { get; set; }
        public int FiscalYearId { get; set; }
    }
}
