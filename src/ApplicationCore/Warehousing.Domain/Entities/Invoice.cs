using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Warehousing.Common.Enums;
using Warehousing.Domain.Entities.Base;

namespace Warehousing.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public Invoice()
        {
            InvoiceItems = new List<InvoiceItem>();
            Inventories = new List<Inventory>();
        }
        public int WarehouseId { get; set; }
        public int FiscalYearId { get; set; }
        public int CustomerId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime? ReturnrdInvoiceDateTime { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
        public int InvoiceTotalPrice { get; set; }

        [ForeignKey("WarehouseId")]
        public virtual Warehouse Warehouse { get; set; }
        public virtual Customer Customer { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
    }
}
