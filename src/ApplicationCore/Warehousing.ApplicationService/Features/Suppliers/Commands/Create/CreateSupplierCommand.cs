using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Suppliers.Commands.Create
{
    public class CreateSupplierCommand : IRequest<ApiResponse>
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string SupplerTel { get; set; }
        public string SupplerWebsite { get; set; }
    }
}
