using System.Linq;
using Warehousing.Domain.Entities;

namespace Warehousing.Domain.Dtos
{
    public class GetTotalPriceDto
    {
        public IQueryable<ProductPrice> ProductPriceList { get; set; }
        public IQueryable<Inventory> StockList { get; set; }
        public int ProductId { get; set; }
    }
}
