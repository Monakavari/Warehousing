﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehousing.Domain.Dtos
{
    public class CloseFiscalYearDto
    {
        public int WarehouseId { get; set; }
        public string UserId { get; set; }
        public int FiscalYearId { get; set; }
    }
}
