using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Countries.Commands.Create
{
    public class CreateCountryCommand : MediatR.IRequest<ApiResponse>
    {
        public string CountryName { get; set; }
    }
}
