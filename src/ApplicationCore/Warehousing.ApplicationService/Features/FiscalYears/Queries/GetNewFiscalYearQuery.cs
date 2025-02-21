using MediatR;
using Warehousing.Common;
using Warehousing.Domain.Dtos;

namespace Warehousing.ApplicationService.Features.FiscalYears.Queries
{
    public class GetNewFiscalYearQuery :IRequest<ApiResponse<NewFiscalYearResponseDto>>
    {
        public int FiscalYearId { get; set; }
    }
}
