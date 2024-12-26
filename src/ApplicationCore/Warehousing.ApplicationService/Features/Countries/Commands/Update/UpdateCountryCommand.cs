using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Countries.Commands.Update
{
    public class UpdateCountryCommand : MediatR.IRequest<ApiResponse>
    {
        public int Id { get; set; }
        public string CountryName { get; set; }

    }
}
