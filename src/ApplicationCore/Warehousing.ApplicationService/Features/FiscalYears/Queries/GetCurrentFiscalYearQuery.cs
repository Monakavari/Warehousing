using MediatR;
using Warehousing.Common;
using Warehousing.Domain.Dtos;

namespace Warehousing.ApplicationService.Features.FiscalYears.Queries
{
    public class GetCurrentFiscalYearQuery :IRequest<ApiResponse<CurrentFiscalYearResponseDto>>
    {
    }
}
