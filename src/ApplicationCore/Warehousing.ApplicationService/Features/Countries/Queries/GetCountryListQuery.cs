using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Countries.Queries
{
    public class GetCountryListQuery : MediatR.IRequest<ApiResponse<List<GetCountryResponseVM>>>
    {

    }
}
