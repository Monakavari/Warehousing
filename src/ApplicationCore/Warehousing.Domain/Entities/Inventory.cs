using System;
using System.ComponentModel.DataAnnotations.Schema;
using Warehousing.Common.Enums;
using Warehousing.Domain.Entities.Base;

namespace Warehousing.Domain.Entities
{
    public class Inventory :BaseEntity
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int FiscalYearId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductLocationId { get; set; }

        //تعداد تراکنش در انبار اصلی
        public int MainProductCount { get; set; }

        //تعداد تراکنش در انبار ضایعات
        public int WastageProductCount { get; set; }

        //تاریخ انقضا
        public DateTime ExpireDate { get; set; }

        //تاریخ ورود کالا به انبار
        public DateTime OperationDate { get; set; }
        public string Description { get; set; }
        public int RefferenceId { get; set; }
        public OperationTypeStatus OperationType { get; set; }
        public Product Product { get; set; }
        public FiscalYear FiscalYear { get; set; }
        public Warehouse Warehouse { get; set; }
        public Invoice Invoice { get; set; }

        [ForeignKey("ProductLocationId")]
        public virtual ProductLocation ProductLocation { get; set; }
    }
}
