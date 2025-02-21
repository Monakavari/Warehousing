using MediatR;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Users.Commands.Create
{
    public class CreateUserAccessCommand : IRequest<ApiResponse>
    {
        public string? CreateInvoice { get; set; }
        public string? InvoiceList { get; set; }
        public string? AllProductInvoiced { get; set; }
        public string? InvoiceSeparation { get; set; }
        public string? WareHousingHandle { get; set; }
        public string? Inventory { get; set; }
        public string? RiallyStock { get; set; }
        public string? WastageRiallyStock { get; set; }
        public string? ProductFlow { get; set; }
        public string? ProductLocation { get; set; }
        public string? ProductPrice { get; set; }
        public string UserIdAccess { get; set; }
    }
}
