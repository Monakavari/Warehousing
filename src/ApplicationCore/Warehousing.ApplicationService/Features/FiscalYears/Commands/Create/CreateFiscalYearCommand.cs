using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.FiscalYear.Commands.Create
{
    public class CreateFiscalYearCommand : IRequest<ApiResponse>
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string FiscalYearDescription { get; set; }
        //True = سال مالی باز می باشد
        //False = سال مالی بسته می باشد
        public bool FiscalFlag { get; set; }
    }
}
