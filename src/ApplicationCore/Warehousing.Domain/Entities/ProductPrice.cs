using System;
using Warehousing.Domain.Entities.Base;

namespace Warehousing.Domain.Entities
{
    public class ProductPrice :BaseEntity
    {
        //قیمت خرید از تولیدکننده
        //-2,147,483,648 to 2,147,483,647
        public int PurchasePrice { get; set; }
        //قیمت فروش به عمده فروش یا فروشگاه
        public int SalesPrice { get; set; }
        //قیمت روی جلد - قیمت مصرف کننده
        public int CoverPrice { get; set; }
        public int ProductId { get; set; }
        public int FiscalYearId { get; set; }
        public DateTime ActionDate { get; set; }
        public Product Product { get; set; }
        public FiscalYear FiscalYear { get; set; }
    }
}
