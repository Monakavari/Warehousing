using System;

namespace Warehousing.Domain.Dtos
{
    public class NewFiscalYearResponseDto
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string FiscalYearDescription { get; set; }
        //True = سال مالی باز می باشد
        //False = سال مالی بسته می باشد
        public bool FiscalFlag { get; set; }
    }
}
