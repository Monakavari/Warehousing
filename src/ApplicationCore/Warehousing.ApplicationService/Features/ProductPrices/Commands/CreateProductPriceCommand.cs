using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.ProductPrice.Commands
{
    public class CreateProductPriceCommand : IRequest<ApiResponse>
    {
        public int PurchasePrice { get; set; }
        //قیمت فروش به عمده فروش یا فروشگاه
        public int SalesPrice { get; set; }
        //قیمت روی جلد - قیمت مصرف کننده
        public int CoverPrice { get; set; }
        public int ProductId { get; set; }
        public int FiscalYearId { get; set; }
        public string ActionDate { get; set; }
    }
}
