using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Countries.Commands.Delete
{
    public class DeleteCountryCommand : MediatR.IRequest<ApiResponse>
    {
        public int Id { get; set; }
    }
}
