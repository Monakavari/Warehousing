using System;
using System.ComponentModel.DataAnnotations;

namespace Warehousing.Domain.Entities.Base
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            IsActive = true;
            IsDelete = false;
            CreateDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public string CreatorUserId { get; set; }
        public string? ModifierUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public string Log { get; set; }

       // public virtual ApplicationUsers User { get; set; }
    }
}
