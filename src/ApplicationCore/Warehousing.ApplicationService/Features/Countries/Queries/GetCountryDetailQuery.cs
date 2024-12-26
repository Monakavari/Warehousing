using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Countries.Queries
{
    public class GetCountryDetailQuery : MediatR.IRequest<ApiResponse<GetCountryResponseVM>>
    {
        public int Id { get; set; }
    }
}
