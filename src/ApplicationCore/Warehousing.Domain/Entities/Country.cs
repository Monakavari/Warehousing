using System.Collections.Generic;
using Warehousing.Domain.Entities.Base;

namespace Warehousing.Domain.Entities
{
    public class Country : BaseEntity
    {
        public Country()
        {
            Products = new List<Product>();
        }
        public string CountryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
