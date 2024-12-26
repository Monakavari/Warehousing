using System;
using System.Collections.Generic;
using Warehousing.Domain.Entities.Base;

namespace Warehousing.Domain.Entities
{
    public class FiscalYear : BaseEntity
    {
        public FiscalYear()
        {
            Inventories = new List<Inventory>();
            ProductPrices = new List<ProductPrice>();
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FiscalYearDescription { get; set; }
        //True = سال مالی باز می باشد
        //False = سال مالی بسته می باشد
        public bool FiscalFlag { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<ProductPrice> ProductPrices { get; set; }
    }
}
